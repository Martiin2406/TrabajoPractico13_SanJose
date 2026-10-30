using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using S7.Net;
using System.Globalization;  //Por el idioma de windows usa coma para float, y el float lleva punto, asi lo normaliza todo a uno

namespace TrabajoPractico13
{
    public partial class Form1 : Form
    {
        private const string TITULO = "TP13 - Control de temperatura de horno";

        // Cada cuánto se lee el DB (en milisegundos).
        // El Timer de Windows no baja de ~15 ms y cada lectura al PLC es un pedido por la red,
        // así que 100 ms es un valor razonable (10 lecturas por segundo).
        private const int INTERVALO_LECTURA_MS = 100;

        private readonly System.Windows.Forms.Timer tmrLectura = new System.Windows.Forms.Timer();

        // Funciona como un "mutex": evita que una lectura y una escritura usen el PLC al mismo tiempo
        private readonly System.Threading.SemaphoreSlim accesoPLC = new System.Threading.SemaphoreSlim(1, 1);

        private bool leyendo = false;               // true mientras hay una lectura en curso
        private bool setpointCargado = false;       // el setpoint se trae del PLC una sola vez al conectar
        private string ultimoSetpointEscrito = "";  // para no escribir el mismo valor dos veces

        public Form1()
        {
            InitializeComponent();

            // Lectura periódica: cada INTERVALO_LECTURA_MS se ejecuta tmrLectura_Tick
            tmrLectura.Interval = INTERVALO_LECTURA_MS;
            tmrLectura.Tick += tmrLectura_Tick;
            tmrLectura.Start();

            // Escritura por evento: el setpoint se manda al presionar Enter o al salir del campo
            txtSetpoint.KeyDown += txtSetpoint_KeyDown;
            txtSetpoint.Leave += txtSetpoint_Leave;
            txtSetpoint.TextChanged += txtSetpoint_TextChanged;

            FormClosed += Form1_FormClosed;
            MostrarSinConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm_DatosPLC = new DatosPLC();
            frm_DatosPLC.ShowDialog(this);
        }

        // =====================================================================
        //  LECTURA: se ejecuta cada INTERVALO_LECTURA_MS
        // =====================================================================
        private async void tmrLectura_Tick(object sender, EventArgs e)
        {
            Plc plc = DatosPLC.plc;
            if (plc == null || !plc.IsConnected)
            {
                MostrarSinConexion();
                return;
            }
            if (leyendo) return;     // la lectura anterior todavía no terminó

            leyendo = true;
            try
            {
                byte[] datos;
                await accesoPLC.WaitAsync();
                try
                {
                    // >>> AQUÍ SE LEE EL DB <<<
                    // Un solo pedido trae todos los bytes del DB, desde el byte 0
                    // hasta la última variable (es más rápido que leer variable por variable)
                    datos = await plc.ReadBytesAsync(DataType.DataBlock, MapaDB.NumeroDB, 0, MapaDB.BytesALeer());
                }
                finally
                {
                    accesoPLC.Release();
                }

                MostrarDatos(datos);
                PonerTitulo(TITULO + "  [conectado a " + plc.IP + " - DB" + MapaDB.NumeroDB + "]");
            }
            catch (Exception ex)
            {
                MostrarSinConexion();
                PonerTitulo(TITULO + "  [error de lectura: " + ex.Message + "]");
            }
            finally
            {
                leyendo = false;
            }
        }

        // Pasa los valores leídos a los controles de la pantalla
        private void MostrarDatos(byte[] datos)
        {
            pilMarcha.Encendido = MapaDB.Marcha.LeerDe(datos) != 0;

            bool caldera = MapaDB.Caldera.LeerDe(datos) != 0;
            pilCaldera.Encendido = caldera;
            diagrama.LlamaEncendida = caldera;

            // Con la alarma de sobretemperatura activa, la temperatura se muestra en rojo
            bool alarma = MapaDB.Alarma.LeerDe(datos) != 0;
            txtTempActual.ForeColor = alarma ? Color.Red : Color.Lime;
            txtTempActual.Text = MapaDB.TempActual.LeerDe(datos).ToString("0.0");

            // El PLC entrega el tiempo restante en segundos -> se muestra como mm:ss
            int segundos = Math.Max(0, (int)MapaDB.TiempoRestante.LeerDe(datos));
            txtTiempoRestante.Text = string.Format("{0:00}:{1:00}", segundos / 60, segundos % 60);

            // Al conectar, el campo de setpoint muestra el valor que ya tiene el PLC
            if (!setpointCargado)
            {
                txtSetpoint.Text = MapaDB.Setpoint.LeerDe(datos).ToString("0.##");
                ultimoSetpointEscrito = txtSetpoint.Text;
                txtSetpoint.BackColor = Color.White;
                setpointCargado = true;
            }
        }

        private void MostrarSinConexion()
        {
            pilMarcha.Encendido = false;
            pilCaldera.Encendido = false;
            diagrama.LlamaEncendida = false;
            txtTempActual.ForeColor = Color.Lime;
            txtTempActual.Text = "----";
            txtTiempoRestante.Text = "--:--";
            setpointCargado = false;
            PonerTitulo(TITULO + "  [sin conexión]");
        }

        private void PonerTitulo(string titulo)
        {
            if (Text != titulo) Text = titulo;   // solo si cambió, para que no parpadee
        }

        // =====================================================================
        //  ESCRITURA DEL SETPOINT: se ejecuta por evento (no por el timer)
        // =====================================================================
        private void txtSetpoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // evita el "beep" de Windows
                EscribirSetpoint(true);
            }
        }

        private void txtSetpoint_Leave(object sender, EventArgs e)
        {
            EscribirSetpoint(false);
        }

        // Fondo amarillo = valor modificado que todavía no se mandó al PLC
        private void txtSetpoint_TextChanged(object sender, EventArgs e)
        {
            txtSetpoint.BackColor = txtSetpoint.Text == ultimoSetpointEscrito ? Color.White : Color.LightYellow;
        }

        private async void EscribirSetpoint(bool avisarErrores)
        {
            if (txtSetpoint.Text == ultimoSetpointEscrito) return;     // no cambió

            Plc plc = DatosPLC.plc;
            if (plc == null || !plc.IsConnected)
            {
                if (avisarErrores)
                    MessageBox.Show("No hay conexión con el PLC.\nConectarse desde \"Datos PLC\".", TITULO,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se acepta coma o punto decimal (ver comentario del using System.Globalization)
            double valor;
            string texto = txtSetpoint.Text.Trim().Replace(',', '.');
            if (!double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
            {
                if (avisarErrores)
                    MessageBox.Show("El setpoint debe ser un número. Ejemplo: 250 o 250,5", TITULO,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VariablePLC sp = MapaDB.Setpoint;
            string textoEscrito = txtSetpoint.Text;
            try
            {
                await accesoPLC.WaitAsync();
                try
                {
                    // >>> AQUÍ SE ESCRIBE EL SETPOINT EN EL DB <<<
                    if (sp.Tipo == "Bool")
                        await plc.WriteBitAsync(DataType.DataBlock, MapaDB.NumeroDB, sp.Byte, sp.Bit, valor != 0);
                    else
                        await plc.WriteBytesAsync(DataType.DataBlock, MapaDB.NumeroDB, sp.Byte, sp.ABytes(valor));
                }
                finally
                {
                    accesoPLC.Release();
                }

                ultimoSetpointEscrito = textoEscrito;
                txtSetpoint_TextChanged(this, EventArgs.Empty);    // vuelve el fondo a blanco
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo escribir el setpoint.\n\n" + ex.Message, TITULO,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Al cerrar el programa: detener el timer y cerrar la conexión con el PLC
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrLectura.Stop();
            if (DatosPLC.plc != null) DatosPLC.plc.Close();
        }
    }
}
