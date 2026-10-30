using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using S7.Net;

namespace TrabajoPractico13
{
    public partial class DatosPLC : Form
    {
        // Tipos de datos de Siemens que se pueden elegir para cada variable
        //   Bool  = 1 bit          Byte  = 8 bits
        //   Int   = 16 bits c/s    Word  = 16 bits s/s
        //   DInt  = 32 bits c/s    DWord = 32 bits s/s
        //   Real  = 32 bits coma flotante (IEEE 754)
        private readonly string[] tiposDeDato = { "Bool", "Byte", "Int", "Word", "DInt", "DWord", "Real" };

        // Conexión con el PLC. Es "static" para que siga existiendo cuando se cierra
        // esta ventana y el Form principal la pueda usar como DatosPLC.plc
        public static Plc plc;

        public DatosPLC()
        {
            InitializeComponent();

            CargarTipos(cmbTipoTempActual);
            CargarTipos(cmbTipoTiempoRestante);
            CargarTipos(cmbTipoSetpoint);
            CargarTipos(cmbTipoCaldera);
            CargarTipos(cmbTipoMarcha);
            CargarTipos(cmbTipoAlarma);
            CargarTipos(cmbTipoCmdMarcha);
            CargarTipos(cmbTipoCmdParada);

            // Mostrar en pantalla el mapa del DB actual (ver MapaDB.cs)
            txtDB.Text = MapaDB.NumeroDB.ToString();
            PonerVariable(cmbTipoMarcha,         txtByteMarcha,         txtBitMarcha,         MapaDB.Marcha);
            PonerVariable(cmbTipoCaldera,        txtByteCaldera,        txtBitCaldera,        MapaDB.Caldera);
            PonerVariable(cmbTipoAlarma,         txtByteAlarma,         txtBitAlarma,         MapaDB.Alarma);
            PonerVariable(cmbTipoTempActual,     txtByteTempActual,     txtBitTempActual,     MapaDB.TempActual);
            PonerVariable(cmbTipoTiempoRestante, txtByteTiempoRestante, txtBitTiempoRestante, MapaDB.TiempoRestante);
            PonerVariable(cmbTipoCmdMarcha,      txtByteCmdMarcha,      txtBitCmdMarcha,      MapaDB.CmdMarcha);
            PonerVariable(cmbTipoCmdParada,      txtByteCmdParada,      txtBitCmdParada,      MapaDB.CmdParada);
            PonerVariable(cmbTipoSetpoint,       txtByteSetpoint,       txtBitSetpoint,       MapaDB.Setpoint);

            FormClosing += DatosPLC_FormClosing;

            // Si la ventana se vuelve a abrir con el PLC ya conectado, mostrar ese estado
            if (plc != null && plc.IsConnected)
            {
                txtIP.Text = plc.IP;
                txtRack.Text = plc.Rack.ToString();
                txtSlot.Text = plc.Slot.ToString();
                MostrarEstado(true, "Estado: conectado a " + plc.IP);
            }
        }

        private void CargarTipos(ComboBox combo)
        {
            combo.Items.AddRange(tiposDeDato);
        }

        private void PonerVariable(ComboBox tipo, TextBox byteDB, TextBox bitDB, VariablePLC variable)
        {
            // El bit solo tiene sentido para variables Bool: para el resto se deshabilita
            tipo.SelectedIndexChanged += (sender, e) =>
            {
                bool esBool = tipo.Text == "Bool";
                bitDB.Enabled = esBool;
                if (!esBool) bitDB.Text = "-";
                else if (bitDB.Text == "-") bitDB.Text = "0";
            };

            tipo.Text = variable.Tipo;
            byteDB.Text = variable.Byte.ToString();
            if (variable.Tipo == "Bool") bitDB.Text = variable.Bit.ToString();
        }

        // Pasa lo que está escrito en pantalla a la variable del mapa.
        // Devuelve false si algún número no es válido.
        private bool GuardarVariable(ComboBox tipo, TextBox byteDB, TextBox bitDB, VariablePLC variable)
        {
            int nroByte;
            int nroBit = 0;
            if (!int.TryParse(byteDB.Text, out nroByte) || nroByte < 0)
                return false;
            if (tipo.Text == "Bool" && (!int.TryParse(bitDB.Text, out nroBit) || nroBit < 0 || nroBit > 7))
                return false;

            variable.Tipo = tipo.Text;
            variable.Byte = nroByte;
            variable.Bit = nroBit;
            return true;
        }

        // Al cerrar la ventana se guarda el mapa del DB para que lo use el Form principal
        private void DatosPLC_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nroDB;
            bool ok = int.TryParse(txtDB.Text, out nroDB) && nroDB > 0;

            ok &= GuardarVariable(cmbTipoMarcha,         txtByteMarcha,         txtBitMarcha,         MapaDB.Marcha);
            ok &= GuardarVariable(cmbTipoCaldera,        txtByteCaldera,        txtBitCaldera,        MapaDB.Caldera);
            ok &= GuardarVariable(cmbTipoAlarma,         txtByteAlarma,         txtBitAlarma,         MapaDB.Alarma);
            ok &= GuardarVariable(cmbTipoTempActual,     txtByteTempActual,     txtBitTempActual,     MapaDB.TempActual);
            ok &= GuardarVariable(cmbTipoTiempoRestante, txtByteTiempoRestante, txtBitTiempoRestante, MapaDB.TiempoRestante);
            ok &= GuardarVariable(cmbTipoCmdMarcha,      txtByteCmdMarcha,      txtBitCmdMarcha,      MapaDB.CmdMarcha);
            ok &= GuardarVariable(cmbTipoCmdParada,      txtByteCmdParada,      txtBitCmdParada,      MapaDB.CmdParada);
            ok &= GuardarVariable(cmbTipoSetpoint,       txtByteSetpoint,       txtBitSetpoint,       MapaDB.Setpoint);

            if (!ok)
            {
                MessageBox.Show("Hay datos inválidos en el mapa del DB.\n" +
                                "El número de DB y los bytes deben ser enteros positivos, y el bit de 0 a 7.",
                                "Datos PLC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;     // no deja cerrar la ventana hasta corregirlo
                return;
            }
            MapaDB.NumeroDB = nroDB;
        }

        // "async" permite esperar la conexión sin congelar la ventana
        // (si el PLC no responde, el intento puede tardar varios segundos)
        private async void btnConectar_Click(object sender, EventArgs e)
        {
            // Si ya está conectado, el mismo botón sirve para desconectar
            if (plc != null && plc.IsConnected)
            {
                plc.Close();
                MostrarEstado(false, "Estado: desconectado");
                return;
            }

            // 1) Validar los datos ingresados
            IPAddress ip;
            if (!IPAddress.TryParse(txtIP.Text.Trim(), out ip))
            {
                MessageBox.Show("La IP ingresada no es válida.\nEjemplo: 192.168.0.1", "Datos PLC",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIP.Focus();
                return;
            }

            short rack, slot;
            if (!short.TryParse(txtRack.Text, out rack) || !short.TryParse(txtSlot.Text, out slot))
            {
                MessageBox.Show("Rack y Slot deben ser números.\nPara el S7-1200: Rack = 0, Slot = 1", "Datos PLC",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Crear el objeto PLC e intentar abrir la conexión (TCP, puerto 102)
            plc = new Plc(CpuType.S71200, ip.ToString(), rack, slot);

            btnConectar.Enabled = false;
            lblTilde.Visible = false;
            lblEstado.ForeColor = Color.DarkGoldenrod;
            lblEstado.Text = "Estado: conectando a " + ip + " ...";

            try
            {
                await plc.OpenAsync();
                MostrarEstado(true, "Estado: conectado a " + ip);
            }
            catch (Exception ex)
            {
                MostrarEstado(false, "Estado: error de conexión");
                MessageBox.Show("No se pudo conectar con el PLC.\n\n" + ex.Message +
                                "\n\nRevisar: cable de red, IP de la PC en la misma red, Rack/Slot.",
                                "Datos PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) btnConectar.Enabled = true;
            }
        }

        // Actualiza el tilde, el texto de estado y el texto del botón
        private void MostrarEstado(bool conectado, string texto)
        {
            if (IsDisposed) return;   // la ventana se cerró mientras se esperaba la conexión

            lblTilde.Visible = conectado;
            lblEstado.Text = texto;
            lblEstado.ForeColor = conectado ? Color.ForestGreen : Color.Firebrick;
            btnConectar.Text = conectado ? "Desconectar" : "Conectar";
        }
    }
}
