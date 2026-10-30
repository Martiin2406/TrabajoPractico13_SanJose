using System;
using System.Linq;

namespace TrabajoPractico13
{
    // Una variable dentro del DB: de qué tipo es y en qué dirección está.
    // Ejemplo: Tipo = "Bool", Byte = 0, Bit = 1   ->   DB1.DBX0.1
    //          Tipo = "Real", Byte = 2             ->   DB1.DBD2
    public class VariablePLC
    {
        public string Tipo;
        public int Byte;
        public int Bit;

        public VariablePLC(string tipo, int nroByte, int nroBit)
        {
            Tipo = tipo;
            Byte = nroByte;
            Bit = nroBit;
        }

        // Cuántos bytes ocupa la variable en el DB
        public int Tamano()
        {
            switch (Tipo)
            {
                case "Bool":
                case "Byte":  return 1;
                case "Int":
                case "Word":  return 2;
                case "DInt":
                case "DWord":
                case "Real":  return 4;
                default: throw new ArgumentException("Tipo de dato desconocido: " + Tipo);
            }
        }

        // Saca el valor de la variable de los bytes leídos del DB.
        // El PLC guarda los números en BIG-ENDIAN (byte más significativo primero),
        // las funciones de S7.Net.Types hacen esa conversión.
        public double LeerDe(byte[] datosDB)
        {
            byte[] b = datosDB.Skip(Byte).Take(Tamano()).ToArray();

            switch (Tipo)
            {
                case "Bool":  return (datosDB[Byte] >> Bit) & 1;      // igual que en C
                case "Byte":  return b[0];
                case "Int":   return S7.Net.Types.Int.FromByteArray(b);
                case "Word":  return S7.Net.Types.Word.FromByteArray(b);
                case "DInt":  return S7.Net.Types.DInt.FromByteArray(b);
                case "DWord": return S7.Net.Types.DWord.FromByteArray(b);
                case "Real":  return S7.Net.Types.Real.FromByteArray(b);
                default: throw new ArgumentException("Tipo de dato desconocido: " + Tipo);
            }
        }

        // Convierte un valor en los bytes que hay que escribir en el DB (no sirve para Bool)
        public byte[] ABytes(double valor)
        {
            switch (Tipo)
            {
                case "Byte":  return new[] { (byte)valor };
                case "Int":   return S7.Net.Types.Int.ToByteArray((short)valor);
                case "Word":  return S7.Net.Types.Word.ToByteArray((ushort)valor);
                case "DInt":  return S7.Net.Types.DInt.ToByteArray((int)valor);
                case "DWord": return S7.Net.Types.DWord.ToByteArray((uint)valor);
                case "Real":  return S7.Net.Types.Real.ToByteArray((float)valor);
                default: throw new ArgumentException("No se puede convertir a bytes el tipo " + Tipo);
            }
        }
    }

    // Mapa del DB del horno. Es "static": hay uno solo para todo el programa.
    // Se edita desde la ventana Datos PLC y lo usa el Form principal para leer y escribir.
    // Los valores iniciales coinciden con el DB de ejemplo (columna "Offset" de TIA Portal).
    public static class MapaDB
    {
        public static int NumeroDB = 1;

        //                                                     tipo  byte bit
        public static VariablePLC Marcha         = new VariablePLC("Bool", 0, 0);
        public static VariablePLC Caldera        = new VariablePLC("Bool", 0, 1);
        public static VariablePLC Alarma         = new VariablePLC("Bool", 0, 2);
        public static VariablePLC TempActual     = new VariablePLC("Real", 2, 0);
        public static VariablePLC TiempoRestante = new VariablePLC("Int",  6, 0);
        public static VariablePLC CmdMarcha      = new VariablePLC("Bool", 8, 0);
        public static VariablePLC CmdParada      = new VariablePLC("Bool", 8, 1);
        public static VariablePLC Setpoint       = new VariablePLC("Real", 10, 0);

        // Cantidad de bytes a leer para que entren todas las variables (desde el byte 0)
        public static int BytesALeer()
        {
            VariablePLC[] todas = { Marcha, Caldera, Alarma, TempActual, TiempoRestante, CmdMarcha, CmdParada, Setpoint };
            return todas.Max(v => v.Byte + v.Tamano());
        }
    }
}
