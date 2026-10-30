"""
=====================================================================
 TP Automatización Industrial - PLC S7-1200 + IoT
 PASARELA (gateway) entre el PLC y la página web
=====================================================================

 ¿Por qué hace falta este programa?
 ----------------------------------
 Un navegador web solo sabe hablar HTTP. El PLC S7-1200 habla el
 protocolo S7 (ISO-on-TCP, puerto 102). Este programa hace de
 "traductor" entre los dos:

     [ Navegador ]  <--- HTTP / JSON --->  [ servidor.py ]  <--- S7 (TCP 102) --->  [ PLC ]
       index.html                           Flask + snap7                           DB1 "DB_IoT"

 Uso:
     python servidor.py              -> se conecta al PLC real
     python servidor.py --simular    -> NO necesita PLC (simula el DB en la PC)

 Después abrir en el navegador:  http://localhost:5000
"""

import sys
import threading
import time

from flask import Flask, jsonify, request, send_from_directory

# ---------------------------------------------------------------------
# 1) CONFIGURACIÓN DE LA CONEXIÓN CON EL PLC
# ---------------------------------------------------------------------
PLC_IP   = "192.168.0.1"   # IP del PLC (la que figura en TIA Portal)
PLC_RACK = 0               # S7-1200: siempre rack 0
PLC_SLOT = 1               # S7-1200: slot 1 (la CPU)

DB_NUMERO = 1              # Número del DB en TIA Portal  -> DB1 "DB_IoT"
DB_TAMANO = 12             # Cantidad de bytes del DB (offset 0 a 11)

# ---------------------------------------------------------------------
# 2) MAPA DEL DB  (TIENE QUE COINCIDIR CON LA COLUMNA "Offset" DE TIA)
# ---------------------------------------------------------------------
# nombre_en_la_web : (tipo, byte, bit)
#
# Equivale a lo que en C sería un struct "empaquetado":
#   struct DB_IoT {
#       uint8_t  bits_estado;    // byte 0: bit0 Bomba, bit1 Alarma, bit2 NivelAlto
#       uint8_t  relleno;        // byte 1: lo agrega TIA para alinear el INT
#       int16_t  nivel;          // byte 2-3  (¡BIG-ENDIAN!)
#       ...
#   };
VARIABLES = {
    # ---- PLC -> WEB (solo lectura, monitoreo) ----
    "bomba_marcha":   ("BOOL", 0, 0),    # DB_IoT.Bomba_Marcha     DBX0.0
    "alarma":         ("BOOL", 0, 1),    # DB_IoT.Alarma           DBX0.1
    "nivel_alto":     ("BOOL", 0, 2),    # DB_IoT.Nivel_Alto       DBX0.2
    "nivel":          ("INT",  2, None), # DB_IoT.Nivel            DBW2
    "contador":       ("INT",  4, None), # DB_IoT.Contador_Ciclos  DBW4
    "analogica_ai0":  ("INT",  6, None), # DB_IoT.Analogica_AI0    DBW6

    # ---- WEB -> PLC (comandos) ----
    "web_marcha":     ("BOOL", 8, 0),    # DB_IoT.Web_Marcha       DBX8.0
    "web_parada":     ("BOOL", 8, 1),    # DB_IoT.Web_Parada       DBX8.1
    "web_reset":      ("BOOL", 8, 2),    # DB_IoT.Web_Reset        DBX8.2
    "web_setpoint":   ("INT", 10, None), # DB_IoT.Web_Setpoint     DBW10
}

# Por seguridad, la web SOLO puede escribir estas variables.
# (Nunca dejar que un cliente externo escriba cualquier dirección del PLC)
ESCRIBIBLES = {"web_marcha", "web_parada", "web_reset", "web_setpoint"}


# ---------------------------------------------------------------------
# 3) FUNCIONES DE CONVERSIÓN BYTES <-> VALORES
# ---------------------------------------------------------------------
# Las escribimos "a mano" para que se vea qué pasa con los bits.
# (snap7.util trae get_bool / get_int / set_bool / set_int que hacen lo mismo)

def leer_bool(datos, byte, bit):
    # Igual que en C:  (datos[byte] >> bit) & 1
    return bool((datos[byte] >> bit) & 1)

def leer_int(datos, byte):
    # INT de Siemens = 16 bits con signo, BIG-ENDIAN (byte alto primero).
    # Un microcontrolador ARM/AVR es little-endian: ¡ojo al portar código!
    valor = (datos[byte] << 8) | datos[byte + 1]
    if valor >= 0x8000:          # bit de signo -> número negativo
        valor -= 0x10000
    return valor

def int_a_bytes(valor):
    valor &= 0xFFFF              # complemento a 2 en 16 bits
    return bytearray([valor >> 8, valor & 0xFF])


# ---------------------------------------------------------------------
# 4) ACCESO AL PLC REAL (librería snap7)
# ---------------------------------------------------------------------
class PLCReal:
    def __init__(self):
        import snap7                     # solo se necesita en modo real
        self.cliente = snap7.client.Client()

    def conectar(self):
        if not self.cliente.get_connected():
            self.cliente.connect(PLC_IP, PLC_RACK, PLC_SLOT)

    def leer_db(self):
        self.conectar()
        # >>> AQUÍ SE LEE EL DB DEL PLC <<<
        # Lee DB_TAMANO bytes del DB1 empezando en el byte 0
        return self.cliente.db_read(DB_NUMERO, 0, DB_TAMANO)

    def escribir_db(self, byte_inicio, datos):
        self.conectar()
        # >>> AQUÍ SE ESCRIBE EN EL DB DEL PLC <<<
        self.cliente.db_write(DB_NUMERO, byte_inicio, datos)

    def desconectar(self):
        self.cliente.disconnect()


# ---------------------------------------------------------------------
# 5) PLC SIMULADO (para practicar en casa sin PLC)
#    Imita la misma lógica que está en plc/OB1_logica.scl
# ---------------------------------------------------------------------
class PLCSimulado:
    def __init__(self):
        self.db = bytearray(DB_TAMANO)
        self.db[10:12] = int_a_bytes(70)          # setpoint inicial 70 %
        threading.Thread(target=self._ciclo, daemon=True).start()

    def leer_db(self):
        return bytearray(self.db)

    def escribir_db(self, byte_inicio, datos):
        self.db[byte_inicio:byte_inicio + len(datos)] = datos

    def _bit(self, byte, bit, valor=None):
        if valor is None:
            return leer_bool(self.db, byte, bit)
        if valor:
            self.db[byte] |= (1 << bit)
        else:
            self.db[byte] &= ~(1 << bit)

    def _ciclo(self):
        while True:
            time.sleep(1)                         # "marca de ciclo" de 1 Hz
            nivel = leer_int(self.db, 2)
            contador = leer_int(self.db, 4)
            setpoint = max(0, min(100, leer_int(self.db, 10)))
            self.db[10:12] = int_a_bytes(setpoint)

            if self._bit(8, 0):                   # Web_Marcha
                if not self._bit(0, 1):
                    self._bit(0, 0, True)
                self._bit(8, 0, False)            # el PLC "consume" el pulso
            if self._bit(8, 1):                   # Web_Parada
                self._bit(0, 0, False)
                self._bit(8, 1, False)
            if self._bit(8, 2):                   # Web_Reset
                if nivel < 90:
                    self._bit(0, 1, False)
                self._bit(8, 2, False)

            if self._bit(0, 0):
                nivel += 2
                if nivel >= setpoint:
                    self._bit(0, 0, False)
                    contador += 1
            elif nivel > 0:
                nivel -= 1

            if nivel >= 95:
                self._bit(0, 1, True)
                self._bit(0, 0, False)
            self._bit(0, 2, nivel >= 90)

            self.db[2:4] = int_a_bytes(nivel)
            self.db[4:6] = int_a_bytes(contador)
            self.db[6:8] = int_a_bytes(13824 + (int(time.time() * 3000) % 2000))


# ---------------------------------------------------------------------
# 6) SERVIDOR WEB (Flask)
# ---------------------------------------------------------------------
app = Flask(__name__, static_folder="web")
plc = None
candado = threading.Lock()   # snap7 no admite dos pedidos a la vez


@app.route("/")
def pagina_principal():
    return send_from_directory("web", "index.html")


@app.route("/api/estado")
def api_estado():
    """La página llama acá cada 500 ms. Devuelve TODO el DB como JSON."""
    try:
        with candado:
            datos = plc.leer_db()
    except Exception as e:
        return jsonify({"conectado": False, "error": str(e)})

    respuesta = {"conectado": True, "bytes_crudos": list(datos)}
    for nombre, (tipo, byte, bit) in VARIABLES.items():
        if tipo == "BOOL":
            respuesta[nombre] = leer_bool(datos, byte, bit)
        else:
            respuesta[nombre] = leer_int(datos, byte)
    return jsonify(respuesta)


@app.route("/api/escribir", methods=["POST"])
def api_escribir():
    """La página manda: {"nombre": "web_marcha", "valor": true}"""
    pedido = request.get_json()
    nombre = pedido.get("nombre")
    valor = pedido.get("valor")

    if nombre not in ESCRIBIBLES:
        return jsonify({"ok": False, "error": "Variable no permitida"}), 403

    tipo, byte, bit = VARIABLES[nombre]
    try:
        with candado:
            if tipo == "BOOL":
                # El PLC no permite escribir un solo bit por este medio:
                # leemos el byte completo, cambiamos el bit y lo escribimos.
                # (lectura-modificación-escritura, igual que con un registro
                #  de periféricos en un microcontrolador)
                actual = plc.leer_db()[byte]
                if valor:
                    actual |= (1 << bit)
                else:
                    actual &= ~(1 << bit)
                plc.escribir_db(byte, bytearray([actual]))
            else:
                valor = int(valor)
                if not -32768 <= valor <= 32767:
                    return jsonify({"ok": False, "error": "Fuera de rango INT"}), 400
                plc.escribir_db(byte, int_a_bytes(valor))
    except Exception as e:
        return jsonify({"ok": False, "error": str(e)}), 500

    return jsonify({"ok": True})


if __name__ == "__main__":
    if "--simular" in sys.argv:
        print("*** MODO SIMULACIÓN: no se usa el PLC real ***")
        plc = PLCSimulado()
    else:
        print(f"Conectando al PLC {PLC_IP} (rack {PLC_RACK}, slot {PLC_SLOT}) ...")
        plc = PLCReal()

    # host="0.0.0.0" permite entrar desde un celular en la misma red WiFi
    app.run(host="0.0.0.0", port=5000, debug=False)
