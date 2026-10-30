# TP: Monitoreo y control de un S7-1200 desde una página web (IoT)

## Objetivo
Leer y escribir variables de un DB del PLC S7-1200 desde una aplicación web
(HTML + JavaScript), sin usar el HMI de Siemens. Monitorear variables
**BOOL** e **INT** y enviar comandos **BOOL** e **INT** de vuelta al PLC.

## Arquitectura

```
 [ Navegador (PC / celular) ]  --HTTP/JSON-->  [ servidor.py ]  --protocolo S7, TCP 102-->  [ S7-1200 ]
        web/index.html                          Flask + snap7                               DB1 "DB_IoT"
```

El navegador no puede hablar el protocolo S7. `servidor.py` hace de
**pasarela (gateway)**: es el mismo rol que cumple un ESP32 o una Raspberry
Pi en una instalación IoT real.

## Archivos

| Archivo | Qué es |
|---|---|
| `plc/OB1_logica.scl` | Programa del PLC (SCL, parecido a C) |
| `servidor.py` | Pasarela PLC ⇄ web. Buscar `>>> AQUÍ SE LEE / ESCRIBE EL DB <<<` |
| `web/index.html` | Página de monitoreo. Buscar `>>> AQUÍ SE PIDEN / ENVÍAN ... <<<` |
| `requirements.txt` | Librerías de Python necesarias |

## 1. Preparar el PLC en TIA Portal

### 1.1 Crear el DB1 "DB_IoT"
Agregar un bloque de datos global, número **1**, nombre **DB_IoT**, y declarar
las variables **en este orden exacto**:

| Nombre | Tipo | Offset | Dirección | Sentido |
|---|---|---|---|---|
| Bomba_Marcha | Bool | 0.0 | DBX0.0 | PLC → Web |
| Alarma | Bool | 0.1 | DBX0.1 | PLC → Web |
| Nivel_Alto | Bool | 0.2 | DBX0.2 | PLC → Web |
| Nivel | Int | 2.0 | DBW2 | PLC → Web |
| Contador_Ciclos | Int | 4.0 | DBW4 | PLC → Web |
| Analogica_AI0 | Int | 6.0 | DBW6 | PLC → Web |
| Web_Marcha | Bool | 8.0 | DBX8.0 | Web → PLC |
| Web_Parada | Bool | 8.1 | DBX8.1 | Web → PLC |
| Web_Reset | Bool | 8.2 | DBX8.2 | Web → PLC |
| Web_Setpoint | Int | 10.0 | DBW10 | Web → PLC (valor inicial 70) |

Tamaño total: 12 bytes. Compilar y verificar que la columna **Offset** coincida
con la tabla (es la misma tabla que está en `VARIABLES` dentro de `servidor.py`).

> **Firmware V2.x / V3.0:** los DB tienen direccionamiento **estándar** y no
> existe la opción PUT/GET, así que no hay nada más que configurar.
> **Firmware V4.x o superior:** desmarcar *"Acceso optimizado al bloque"* en
> las propiedades del DB y, en la CPU, activar *Protección → "Permitir acceso
> vía comunicación PUT/GET"*.

### 1.2 Marcas de ciclo
Propiedades de la CPU → *Marcas de sistema y de ciclo* → activar marcas de ciclo
en **MB0** (`%M0.5` = 1 Hz).

### 1.3 Programa
Copiar el contenido de `plc/OB1_logica.scl` en el OB1 (creado en lenguaje SCL).
Si su versión de TIA no permite SCL en OB1, crear una FC en SCL y llamarla desde OB1.

### 1.4 Red
- PLC: por ejemplo `192.168.0.1 / 255.255.255.0`
- PC: misma red, por ejemplo `192.168.0.10 / 255.255.255.0`
- Probar con `ping 192.168.0.1`
- Protección de la CPU: sin protección / acceso completo.

## 2. Preparar la PC

Instalar Python 3 (marcar *"Add Python to PATH"*). En una consola, dentro de la carpeta del TP:

```bash
pip install -r requirements.txt
```

Editar la IP del PLC al principio de `servidor.py` (`PLC_IP = "192.168.0.1"`).

## 3. Ejecutar

Sin PLC (para practicar en casa):
```bash
python servidor.py --simular
```

Con el PLC real:
```bash
python servidor.py
```

Abrir el navegador en **http://localhost:5000**. Desde un celular conectado a la
misma red: `http://<IP-de-la-PC>:5000`.

## 4. Cómo viaja un dato (seguir el código)

**Lectura (monitoreo), cada 500 ms:**
1. `index.html` → función `leerPLC()` → `fetch("/api/estado")`
2. `servidor.py` → `api_estado()` → `plc.leer_db()` → `db_read(1, 0, 12)`: lee 12 bytes del DB1
3. `leer_bool()` / `leer_int()` convierten bytes en valores
4. Se devuelve un JSON: `{"bomba_marcha": true, "nivel": 54, ...}`
5. `leerPLC()` enciende los "LEDs" y escribe los números en pantalla

**Escritura (comando):**
1. Clic en MARCHA → `escribir('web_marcha', true)` → `POST /api/escribir`
2. `servidor.py` → `api_escribir()` → verifica que la variable esté en `ESCRIBIBLES`
3. Lee el byte 8, pone en 1 el bit 0 y escribe el byte → `db_write(1, 8, ...)`
4. En el PLC, el OB1 ve `Web_Marcha = TRUE`, arranca la bomba y **borra** el bit

## 5. Actividades

1. Ejecutar en modo `--simular` y relacionar cada indicador de la página con su dirección del DB.
2. En el panel *"Datos crudos"*, observar el byte 0 al arrancar/parar la bomba. ¿Qué bit cambia?
3. Enviar setpoint 300. Observar los bytes 10 y 11. Calcular a mano: 300 = 0x012C → byte 10 = 1, byte 11 = 44. ¿Por qué el byte alto va primero? (big-endian)
4. Enviar setpoint 98. ¿Qué sucede? ¿Cómo se sale de la alarma?
5. Conectar al PLC real y girar un potenciómetro en AI0. Verificar el valor (0 a 27648).
6. **Agregar una variable nueva** al DB (por ejemplo `Web_Luz : Bool` en DBX8.3 que maneje `%Q0.2`):
   - declararla en TIA,
   - agregarla a `VARIABLES` y a `ESCRIBIBLES` en `servidor.py`,
   - agregar un botón en `index.html`.
7. Mostrar la temperatura escalada: convertir `Analogica_AI0` a 0–100 °C en JavaScript.
8. Desconectar el cable de red con la página abierta. ¿Qué muestra? ¿Qué debería hacer el PLC si pierde la comunicación con la web? (concepto de *watchdog* / *heartbeat*).

## 6. Preguntas para discutir

- ¿Por qué los comandos de la web están en bytes **distintos** a los del estado?
- ¿Por qué el PLC limita el setpoint aunque la página ya lo valida?
- `servidor.py` escribe un bit leyendo y reescribiendo el byte entero. ¿Qué
  problema podría aparecer si el PLC modifica otro bit de ese byte justo en el medio?
- ¿Qué riesgos tiene dejar esta página accesible desde Internet sin contraseña?

## Anexo: otras formas de hacerlo
- **Servidor web propio del S7-1200 (páginas definidas por el usuario, AWP):**
  el HTML se carga dentro del PLC y las variables se insertan con
  `:="DB_IoT".Nivel:`. No necesita PC, pero es más difícil de depurar.
- **Node-RED** con el nodo `node-red-contrib-s7`: misma idea que `servidor.py`, programando con bloques.
- **MQTT:** la pasarela publica los datos en un broker y cualquier cliente IoT se suscribe.
