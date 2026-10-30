namespace TrabajoPractico13
{
    partial class DatosPLC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConexion = new System.Windows.Forms.GroupBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblRack = new System.Windows.Forms.Label();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblTilde = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpVariables = new System.Windows.Forms.GroupBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.lblDBAyuda = new System.Windows.Forms.Label();
            this.lblColVariable = new System.Windows.Forms.Label();
            this.lblColSentido = new System.Windows.Forms.Label();
            this.lblColTipo = new System.Windows.Forms.Label();
            this.lblColByte = new System.Windows.Forms.Label();
            this.lblColBit = new System.Windows.Forms.Label();
            this.lblVarTempActual = new System.Windows.Forms.Label();
            this.lblSentidoTempActual = new System.Windows.Forms.Label();
            this.cmbTipoTempActual = new System.Windows.Forms.ComboBox();
            this.txtByteTempActual = new System.Windows.Forms.TextBox();
            this.txtBitTempActual = new System.Windows.Forms.TextBox();
            this.lblVarTiempoRestante = new System.Windows.Forms.Label();
            this.lblSentidoTiempoRestante = new System.Windows.Forms.Label();
            this.cmbTipoTiempoRestante = new System.Windows.Forms.ComboBox();
            this.txtByteTiempoRestante = new System.Windows.Forms.TextBox();
            this.txtBitTiempoRestante = new System.Windows.Forms.TextBox();
            this.lblVarSetpoint = new System.Windows.Forms.Label();
            this.lblSentidoSetpoint = new System.Windows.Forms.Label();
            this.cmbTipoSetpoint = new System.Windows.Forms.ComboBox();
            this.txtByteSetpoint = new System.Windows.Forms.TextBox();
            this.txtBitSetpoint = new System.Windows.Forms.TextBox();
            this.lblVarCaldera = new System.Windows.Forms.Label();
            this.lblSentidoCaldera = new System.Windows.Forms.Label();
            this.cmbTipoCaldera = new System.Windows.Forms.ComboBox();
            this.txtByteCaldera = new System.Windows.Forms.TextBox();
            this.txtBitCaldera = new System.Windows.Forms.TextBox();
            this.lblVarMarcha = new System.Windows.Forms.Label();
            this.lblSentidoMarcha = new System.Windows.Forms.Label();
            this.cmbTipoMarcha = new System.Windows.Forms.ComboBox();
            this.txtByteMarcha = new System.Windows.Forms.TextBox();
            this.txtBitMarcha = new System.Windows.Forms.TextBox();
            this.lblVarAlarma = new System.Windows.Forms.Label();
            this.lblSentidoAlarma = new System.Windows.Forms.Label();
            this.cmbTipoAlarma = new System.Windows.Forms.ComboBox();
            this.txtByteAlarma = new System.Windows.Forms.TextBox();
            this.txtBitAlarma = new System.Windows.Forms.TextBox();
            this.lblVarCmdMarcha = new System.Windows.Forms.Label();
            this.lblSentidoCmdMarcha = new System.Windows.Forms.Label();
            this.cmbTipoCmdMarcha = new System.Windows.Forms.ComboBox();
            this.txtByteCmdMarcha = new System.Windows.Forms.TextBox();
            this.txtBitCmdMarcha = new System.Windows.Forms.TextBox();
            this.lblVarCmdParada = new System.Windows.Forms.Label();
            this.lblSentidoCmdParada = new System.Windows.Forms.Label();
            this.cmbTipoCmdParada = new System.Windows.Forms.ComboBox();
            this.txtByteCmdParada = new System.Windows.Forms.TextBox();
            this.txtBitCmdParada = new System.Windows.Forms.TextBox();
            this.grpConexion.SuspendLayout();
            this.grpVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConexion
            // 
            this.grpConexion.Controls.Add(this.lblIP);
            this.grpConexion.Controls.Add(this.txtIP);
            this.grpConexion.Controls.Add(this.lblRack);
            this.grpConexion.Controls.Add(this.txtRack);
            this.grpConexion.Controls.Add(this.lblSlot);
            this.grpConexion.Controls.Add(this.txtSlot);
            this.grpConexion.Controls.Add(this.btnConectar);
            this.grpConexion.Controls.Add(this.lblTilde);
            this.grpConexion.Controls.Add(this.lblEstado);
            this.grpConexion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConexion.Location = new System.Drawing.Point(12, 12);
            this.grpConexion.Name = "grpConexion";
            this.grpConexion.Size = new System.Drawing.Size(556, 105);
            this.grpConexion.TabIndex = 0;
            this.grpConexion.TabStop = false;
            this.grpConexion.Text = "Conexión con el PLC";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.Location = new System.Drawing.Point(16, 32);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(63, 15);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP del PLC:";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(90, 28);
            this.txtIP.MaxLength = 15;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(130, 25);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.0.1";
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRack.Location = new System.Drawing.Point(232, 32);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(35, 15);
            this.lblRack.TabIndex = 2;
            this.lblRack.Text = "Rack:";
            // 
            // txtRack
            // 
            this.txtRack.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRack.Location = new System.Drawing.Point(270, 28);
            this.txtRack.MaxLength = 1;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(28, 25);
            this.txtRack.TabIndex = 3;
            this.txtRack.Text = "0";
            this.txtRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlot.Location = new System.Drawing.Point(308, 32);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(30, 15);
            this.lblSlot.TabIndex = 4;
            this.lblSlot.Text = "Slot:";
            // 
            // txtSlot
            // 
            this.txtSlot.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlot.Location = new System.Drawing.Point(342, 28);
            this.txtSlot.MaxLength = 1;
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(28, 25);
            this.txtSlot.TabIndex = 5;
            this.txtSlot.Text = "1";
            this.txtSlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(392, 24);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(105, 32);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblTilde
            // 
            this.lblTilde.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilde.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTilde.Location = new System.Drawing.Point(503, 16);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(45, 45);
            this.lblTilde.TabIndex = 7;
            this.lblTilde.Text = "✔";
            this.lblTilde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTilde.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Firebrick;
            this.lblEstado.Location = new System.Drawing.Point(16, 72);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(126, 15);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado: desconectado";
            // 
            // grpVariables
            // 
            this.grpVariables.Controls.Add(this.lblDB);
            this.grpVariables.Controls.Add(this.txtDB);
            this.grpVariables.Controls.Add(this.lblDBAyuda);
            this.grpVariables.Controls.Add(this.lblColVariable);
            this.grpVariables.Controls.Add(this.lblColSentido);
            this.grpVariables.Controls.Add(this.lblColTipo);
            this.grpVariables.Controls.Add(this.lblColByte);
            this.grpVariables.Controls.Add(this.lblColBit);
            this.grpVariables.Controls.Add(this.lblVarTempActual);
            this.grpVariables.Controls.Add(this.lblSentidoTempActual);
            this.grpVariables.Controls.Add(this.cmbTipoTempActual);
            this.grpVariables.Controls.Add(this.txtByteTempActual);
            this.grpVariables.Controls.Add(this.txtBitTempActual);
            this.grpVariables.Controls.Add(this.lblVarTiempoRestante);
            this.grpVariables.Controls.Add(this.lblSentidoTiempoRestante);
            this.grpVariables.Controls.Add(this.cmbTipoTiempoRestante);
            this.grpVariables.Controls.Add(this.txtByteTiempoRestante);
            this.grpVariables.Controls.Add(this.txtBitTiempoRestante);
            this.grpVariables.Controls.Add(this.lblVarSetpoint);
            this.grpVariables.Controls.Add(this.lblSentidoSetpoint);
            this.grpVariables.Controls.Add(this.cmbTipoSetpoint);
            this.grpVariables.Controls.Add(this.txtByteSetpoint);
            this.grpVariables.Controls.Add(this.txtBitSetpoint);
            this.grpVariables.Controls.Add(this.lblVarCaldera);
            this.grpVariables.Controls.Add(this.lblSentidoCaldera);
            this.grpVariables.Controls.Add(this.cmbTipoCaldera);
            this.grpVariables.Controls.Add(this.txtByteCaldera);
            this.grpVariables.Controls.Add(this.txtBitCaldera);
            this.grpVariables.Controls.Add(this.lblVarMarcha);
            this.grpVariables.Controls.Add(this.lblSentidoMarcha);
            this.grpVariables.Controls.Add(this.cmbTipoMarcha);
            this.grpVariables.Controls.Add(this.txtByteMarcha);
            this.grpVariables.Controls.Add(this.txtBitMarcha);
            this.grpVariables.Controls.Add(this.lblVarAlarma);
            this.grpVariables.Controls.Add(this.lblSentidoAlarma);
            this.grpVariables.Controls.Add(this.cmbTipoAlarma);
            this.grpVariables.Controls.Add(this.txtByteAlarma);
            this.grpVariables.Controls.Add(this.txtBitAlarma);
            this.grpVariables.Controls.Add(this.lblVarCmdMarcha);
            this.grpVariables.Controls.Add(this.lblSentidoCmdMarcha);
            this.grpVariables.Controls.Add(this.cmbTipoCmdMarcha);
            this.grpVariables.Controls.Add(this.txtByteCmdMarcha);
            this.grpVariables.Controls.Add(this.txtBitCmdMarcha);
            this.grpVariables.Controls.Add(this.lblVarCmdParada);
            this.grpVariables.Controls.Add(this.lblSentidoCmdParada);
            this.grpVariables.Controls.Add(this.cmbTipoCmdParada);
            this.grpVariables.Controls.Add(this.txtByteCmdParada);
            this.grpVariables.Controls.Add(this.txtBitCmdParada);
            this.grpVariables.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVariables.Location = new System.Drawing.Point(12, 125);
            this.grpVariables.Name = "grpVariables";
            this.grpVariables.Size = new System.Drawing.Size(556, 358);
            this.grpVariables.TabIndex = 1;
            this.grpVariables.TabStop = false;
            this.grpVariables.Text = "Variables en el DB";
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(16, 30);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(93, 15);
            this.lblDB.TabIndex = 0;
            this.lblDB.Text = "Número de DB:";
            // 
            // txtDB
            // 
            this.txtDB.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDB.Location = new System.Drawing.Point(115, 26);
            this.txtDB.MaxLength = 5;
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(55, 25);
            this.txtDB.TabIndex = 1;
            this.txtDB.Text = "1";
            this.txtDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDBAyuda
            // 
            this.lblDBAyuda.AutoSize = true;
            this.lblDBAyuda.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBAyuda.ForeColor = System.Drawing.Color.DimGray;
            this.lblDBAyuda.Location = new System.Drawing.Point(180, 31);
            this.lblDBAyuda.Name = "lblDBAyuda";
            this.lblDBAyuda.Size = new System.Drawing.Size(240, 13);
            this.lblDBAyuda.TabIndex = 2;
            this.lblDBAyuda.Text = "El DB debe tener acceso estándar (no optimizado)";
            // 
            // lblColVariable
            // 
            this.lblColVariable.AutoSize = true;
            this.lblColVariable.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColVariable.Location = new System.Drawing.Point(16, 66);
            this.lblColVariable.Name = "lblColVariable";
            this.lblColVariable.Size = new System.Drawing.Size(51, 15);
            this.lblColVariable.TabIndex = 3;
            this.lblColVariable.Text = "Variable";
            // 
            // lblColSentido
            // 
            this.lblColSentido.AutoSize = true;
            this.lblColSentido.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColSentido.Location = new System.Drawing.Point(222, 66);
            this.lblColSentido.Name = "lblColSentido";
            this.lblColSentido.Size = new System.Drawing.Size(50, 15);
            this.lblColSentido.TabIndex = 4;
            this.lblColSentido.Text = "Sentido";
            // 
            // lblColTipo
            // 
            this.lblColTipo.AutoSize = true;
            this.lblColTipo.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColTipo.Location = new System.Drawing.Point(310, 66);
            this.lblColTipo.Name = "lblColTipo";
            this.lblColTipo.Size = new System.Drawing.Size(76, 15);
            this.lblColTipo.TabIndex = 5;
            this.lblColTipo.Text = "Tipo de dato";
            // 
            // lblColByte
            // 
            this.lblColByte.AutoSize = true;
            this.lblColByte.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColByte.Location = new System.Drawing.Point(440, 66);
            this.lblColByte.Name = "lblColByte";
            this.lblColByte.Size = new System.Drawing.Size(33, 15);
            this.lblColByte.TabIndex = 6;
            this.lblColByte.Text = "Byte";
            // 
            // lblColBit
            // 
            this.lblColBit.AutoSize = true;
            this.lblColBit.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColBit.Location = new System.Drawing.Point(510, 66);
            this.lblColBit.Name = "lblColBit";
            this.lblColBit.Size = new System.Drawing.Size(23, 15);
            this.lblColBit.TabIndex = 7;
            this.lblColBit.Text = "Bit";
            // 
            // lblVarTempActual
            // 
            this.lblVarTempActual.AutoSize = true;
            this.lblVarTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarTempActual.Location = new System.Drawing.Point(16, 95);
            this.lblVarTempActual.Name = "lblVarTempActual";
            this.lblVarTempActual.Size = new System.Drawing.Size(109, 15);
            this.lblVarTempActual.TabIndex = 10;
            this.lblVarTempActual.Text = "Temperatura actual";
            // 
            // lblSentidoTempActual
            // 
            this.lblSentidoTempActual.AutoSize = true;
            this.lblSentidoTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoTempActual.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSentidoTempActual.Location = new System.Drawing.Point(222, 95);
            this.lblSentidoTempActual.Name = "lblSentidoTempActual";
            this.lblSentidoTempActual.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoTempActual.TabIndex = 11;
            this.lblSentidoTempActual.Text = "PLC → PC";
            // 
            // cmbTipoTempActual
            // 
            this.cmbTipoTempActual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoTempActual.Location = new System.Drawing.Point(310, 92);
            this.cmbTipoTempActual.Name = "cmbTipoTempActual";
            this.cmbTipoTempActual.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoTempActual.TabIndex = 12;
            // 
            // txtByteTempActual
            // 
            this.txtByteTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteTempActual.Location = new System.Drawing.Point(440, 92);
            this.txtByteTempActual.Name = "txtByteTempActual";
            this.txtByteTempActual.Size = new System.Drawing.Size(50, 23);
            this.txtByteTempActual.TabIndex = 13;
            this.txtByteTempActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitTempActual
            // 
            this.txtBitTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitTempActual.Location = new System.Drawing.Point(510, 92);
            this.txtBitTempActual.MaxLength = 1;
            this.txtBitTempActual.Name = "txtBitTempActual";
            this.txtBitTempActual.Size = new System.Drawing.Size(40, 23);
            this.txtBitTempActual.TabIndex = 14;
            this.txtBitTempActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarTiempoRestante
            // 
            this.lblVarTiempoRestante.AutoSize = true;
            this.lblVarTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarTiempoRestante.Location = new System.Drawing.Point(16, 127);
            this.lblVarTiempoRestante.Name = "lblVarTiempoRestante";
            this.lblVarTiempoRestante.Size = new System.Drawing.Size(168, 15);
            this.lblVarTiempoRestante.TabIndex = 15;
            this.lblVarTiempoRestante.Text = "Tiempo de encendido restante";
            // 
            // lblSentidoTiempoRestante
            // 
            this.lblSentidoTiempoRestante.AutoSize = true;
            this.lblSentidoTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoTiempoRestante.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSentidoTiempoRestante.Location = new System.Drawing.Point(222, 127);
            this.lblSentidoTiempoRestante.Name = "lblSentidoTiempoRestante";
            this.lblSentidoTiempoRestante.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoTiempoRestante.TabIndex = 16;
            this.lblSentidoTiempoRestante.Text = "PLC → PC";
            // 
            // cmbTipoTiempoRestante
            // 
            this.cmbTipoTiempoRestante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoTiempoRestante.Location = new System.Drawing.Point(310, 124);
            this.cmbTipoTiempoRestante.Name = "cmbTipoTiempoRestante";
            this.cmbTipoTiempoRestante.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoTiempoRestante.TabIndex = 17;
            // 
            // txtByteTiempoRestante
            // 
            this.txtByteTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteTiempoRestante.Location = new System.Drawing.Point(440, 124);
            this.txtByteTiempoRestante.Name = "txtByteTiempoRestante";
            this.txtByteTiempoRestante.Size = new System.Drawing.Size(50, 23);
            this.txtByteTiempoRestante.TabIndex = 18;
            this.txtByteTiempoRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitTiempoRestante
            // 
            this.txtBitTiempoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitTiempoRestante.Location = new System.Drawing.Point(510, 124);
            this.txtBitTiempoRestante.MaxLength = 1;
            this.txtBitTiempoRestante.Name = "txtBitTiempoRestante";
            this.txtBitTiempoRestante.Size = new System.Drawing.Size(40, 23);
            this.txtBitTiempoRestante.TabIndex = 19;
            this.txtBitTiempoRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarSetpoint
            // 
            this.lblVarSetpoint.AutoSize = true;
            this.lblVarSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarSetpoint.Location = new System.Drawing.Point(16, 159);
            this.lblVarSetpoint.Name = "lblVarSetpoint";
            this.lblVarSetpoint.Size = new System.Drawing.Size(51, 15);
            this.lblVarSetpoint.TabIndex = 20;
            this.lblVarSetpoint.Text = "Setpoint";
            // 
            // lblSentidoSetpoint
            // 
            this.lblSentidoSetpoint.AutoSize = true;
            this.lblSentidoSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoSetpoint.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSentidoSetpoint.Location = new System.Drawing.Point(222, 159);
            this.lblSentidoSetpoint.Name = "lblSentidoSetpoint";
            this.lblSentidoSetpoint.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoSetpoint.TabIndex = 21;
            this.lblSentidoSetpoint.Text = "PC → PLC";
            // 
            // cmbTipoSetpoint
            // 
            this.cmbTipoSetpoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoSetpoint.Location = new System.Drawing.Point(310, 156);
            this.cmbTipoSetpoint.Name = "cmbTipoSetpoint";
            this.cmbTipoSetpoint.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoSetpoint.TabIndex = 22;
            // 
            // txtByteSetpoint
            // 
            this.txtByteSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteSetpoint.Location = new System.Drawing.Point(440, 156);
            this.txtByteSetpoint.Name = "txtByteSetpoint";
            this.txtByteSetpoint.Size = new System.Drawing.Size(50, 23);
            this.txtByteSetpoint.TabIndex = 23;
            this.txtByteSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitSetpoint
            // 
            this.txtBitSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitSetpoint.Location = new System.Drawing.Point(510, 156);
            this.txtBitSetpoint.MaxLength = 1;
            this.txtBitSetpoint.Name = "txtBitSetpoint";
            this.txtBitSetpoint.Size = new System.Drawing.Size(40, 23);
            this.txtBitSetpoint.TabIndex = 24;
            this.txtBitSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarCaldera
            // 
            this.lblVarCaldera.AutoSize = true;
            this.lblVarCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarCaldera.Location = new System.Drawing.Point(16, 191);
            this.lblVarCaldera.Name = "lblVarCaldera";
            this.lblVarCaldera.Size = new System.Drawing.Size(179, 15);
            this.lblVarCaldera.TabIndex = 25;
            this.lblVarCaldera.Text = "Confirmación caldera encendida";
            // 
            // lblSentidoCaldera
            // 
            this.lblSentidoCaldera.AutoSize = true;
            this.lblSentidoCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoCaldera.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSentidoCaldera.Location = new System.Drawing.Point(222, 191);
            this.lblSentidoCaldera.Name = "lblSentidoCaldera";
            this.lblSentidoCaldera.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoCaldera.TabIndex = 26;
            this.lblSentidoCaldera.Text = "PLC → PC";
            // 
            // cmbTipoCaldera
            // 
            this.cmbTipoCaldera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoCaldera.Location = new System.Drawing.Point(310, 188);
            this.cmbTipoCaldera.Name = "cmbTipoCaldera";
            this.cmbTipoCaldera.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoCaldera.TabIndex = 27;
            // 
            // txtByteCaldera
            // 
            this.txtByteCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteCaldera.Location = new System.Drawing.Point(440, 188);
            this.txtByteCaldera.Name = "txtByteCaldera";
            this.txtByteCaldera.Size = new System.Drawing.Size(50, 23);
            this.txtByteCaldera.TabIndex = 28;
            this.txtByteCaldera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitCaldera
            // 
            this.txtBitCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitCaldera.Location = new System.Drawing.Point(510, 188);
            this.txtBitCaldera.MaxLength = 1;
            this.txtBitCaldera.Name = "txtBitCaldera";
            this.txtBitCaldera.Size = new System.Drawing.Size(40, 23);
            this.txtBitCaldera.TabIndex = 29;
            this.txtBitCaldera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarMarcha
            // 
            this.lblVarMarcha.AutoSize = true;
            this.lblVarMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarMarcha.Location = new System.Drawing.Point(16, 223);
            this.lblVarMarcha.Name = "lblVarMarcha";
            this.lblVarMarcha.Size = new System.Drawing.Size(139, 15);
            this.lblVarMarcha.TabIndex = 30;
            this.lblVarMarcha.Text = "Confirmación de marcha";
            // 
            // lblSentidoMarcha
            // 
            this.lblSentidoMarcha.AutoSize = true;
            this.lblSentidoMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoMarcha.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSentidoMarcha.Location = new System.Drawing.Point(222, 223);
            this.lblSentidoMarcha.Name = "lblSentidoMarcha";
            this.lblSentidoMarcha.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoMarcha.TabIndex = 31;
            this.lblSentidoMarcha.Text = "PLC → PC";
            // 
            // cmbTipoMarcha
            // 
            this.cmbTipoMarcha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoMarcha.Location = new System.Drawing.Point(310, 220);
            this.cmbTipoMarcha.Name = "cmbTipoMarcha";
            this.cmbTipoMarcha.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoMarcha.TabIndex = 32;
            // 
            // txtByteMarcha
            // 
            this.txtByteMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteMarcha.Location = new System.Drawing.Point(440, 220);
            this.txtByteMarcha.Name = "txtByteMarcha";
            this.txtByteMarcha.Size = new System.Drawing.Size(50, 23);
            this.txtByteMarcha.TabIndex = 33;
            this.txtByteMarcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitMarcha
            // 
            this.txtBitMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitMarcha.Location = new System.Drawing.Point(510, 220);
            this.txtBitMarcha.MaxLength = 1;
            this.txtBitMarcha.Name = "txtBitMarcha";
            this.txtBitMarcha.Size = new System.Drawing.Size(40, 23);
            this.txtBitMarcha.TabIndex = 34;
            this.txtBitMarcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarAlarma
            // 
            this.lblVarAlarma.AutoSize = true;
            this.lblVarAlarma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarAlarma.Location = new System.Drawing.Point(16, 255);
            this.lblVarAlarma.Name = "lblVarAlarma";
            this.lblVarAlarma.Size = new System.Drawing.Size(142, 15);
            this.lblVarAlarma.TabIndex = 35;
            this.lblVarAlarma.Text = "Alarma sobretemperatura";
            // 
            // lblSentidoAlarma
            // 
            this.lblSentidoAlarma.AutoSize = true;
            this.lblSentidoAlarma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoAlarma.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSentidoAlarma.Location = new System.Drawing.Point(222, 255);
            this.lblSentidoAlarma.Name = "lblSentidoAlarma";
            this.lblSentidoAlarma.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoAlarma.TabIndex = 36;
            this.lblSentidoAlarma.Text = "PLC → PC";
            // 
            // cmbTipoAlarma
            // 
            this.cmbTipoAlarma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAlarma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoAlarma.Location = new System.Drawing.Point(310, 252);
            this.cmbTipoAlarma.Name = "cmbTipoAlarma";
            this.cmbTipoAlarma.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoAlarma.TabIndex = 37;
            // 
            // txtByteAlarma
            // 
            this.txtByteAlarma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteAlarma.Location = new System.Drawing.Point(440, 252);
            this.txtByteAlarma.Name = "txtByteAlarma";
            this.txtByteAlarma.Size = new System.Drawing.Size(50, 23);
            this.txtByteAlarma.TabIndex = 38;
            this.txtByteAlarma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitAlarma
            // 
            this.txtBitAlarma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitAlarma.Location = new System.Drawing.Point(510, 252);
            this.txtBitAlarma.MaxLength = 1;
            this.txtBitAlarma.Name = "txtBitAlarma";
            this.txtBitAlarma.Size = new System.Drawing.Size(40, 23);
            this.txtBitAlarma.TabIndex = 39;
            this.txtBitAlarma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarCmdMarcha
            // 
            this.lblVarCmdMarcha.AutoSize = true;
            this.lblVarCmdMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarCmdMarcha.Location = new System.Drawing.Point(16, 287);
            this.lblVarCmdMarcha.Name = "lblVarCmdMarcha";
            this.lblVarCmdMarcha.Size = new System.Drawing.Size(99, 15);
            this.lblVarCmdMarcha.TabIndex = 40;
            this.lblVarCmdMarcha.Text = "Orden de marcha";
            // 
            // lblSentidoCmdMarcha
            // 
            this.lblSentidoCmdMarcha.AutoSize = true;
            this.lblSentidoCmdMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoCmdMarcha.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSentidoCmdMarcha.Location = new System.Drawing.Point(222, 287);
            this.lblSentidoCmdMarcha.Name = "lblSentidoCmdMarcha";
            this.lblSentidoCmdMarcha.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoCmdMarcha.TabIndex = 41;
            this.lblSentidoCmdMarcha.Text = "PC → PLC";
            // 
            // cmbTipoCmdMarcha
            // 
            this.cmbTipoCmdMarcha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCmdMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoCmdMarcha.Location = new System.Drawing.Point(310, 284);
            this.cmbTipoCmdMarcha.Name = "cmbTipoCmdMarcha";
            this.cmbTipoCmdMarcha.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoCmdMarcha.TabIndex = 42;
            // 
            // txtByteCmdMarcha
            // 
            this.txtByteCmdMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteCmdMarcha.Location = new System.Drawing.Point(440, 284);
            this.txtByteCmdMarcha.Name = "txtByteCmdMarcha";
            this.txtByteCmdMarcha.Size = new System.Drawing.Size(50, 23);
            this.txtByteCmdMarcha.TabIndex = 43;
            this.txtByteCmdMarcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitCmdMarcha
            // 
            this.txtBitCmdMarcha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitCmdMarcha.Location = new System.Drawing.Point(510, 284);
            this.txtBitCmdMarcha.MaxLength = 1;
            this.txtBitCmdMarcha.Name = "txtBitCmdMarcha";
            this.txtBitCmdMarcha.Size = new System.Drawing.Size(40, 23);
            this.txtBitCmdMarcha.TabIndex = 44;
            this.txtBitCmdMarcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVarCmdParada
            // 
            this.lblVarCmdParada.AutoSize = true;
            this.lblVarCmdParada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarCmdParada.Location = new System.Drawing.Point(16, 319);
            this.lblVarCmdParada.Name = "lblVarCmdParada";
            this.lblVarCmdParada.Size = new System.Drawing.Size(95, 15);
            this.lblVarCmdParada.TabIndex = 45;
            this.lblVarCmdParada.Text = "Orden de parada";
            // 
            // lblSentidoCmdParada
            // 
            this.lblSentidoCmdParada.AutoSize = true;
            this.lblSentidoCmdParada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentidoCmdParada.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSentidoCmdParada.Location = new System.Drawing.Point(222, 319);
            this.lblSentidoCmdParada.Name = "lblSentidoCmdParada";
            this.lblSentidoCmdParada.Size = new System.Drawing.Size(57, 15);
            this.lblSentidoCmdParada.TabIndex = 46;
            this.lblSentidoCmdParada.Text = "PC → PLC";
            // 
            // cmbTipoCmdParada
            // 
            this.cmbTipoCmdParada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCmdParada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoCmdParada.Location = new System.Drawing.Point(310, 316);
            this.cmbTipoCmdParada.Name = "cmbTipoCmdParada";
            this.cmbTipoCmdParada.Size = new System.Drawing.Size(110, 23);
            this.cmbTipoCmdParada.TabIndex = 47;
            // 
            // txtByteCmdParada
            // 
            this.txtByteCmdParada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByteCmdParada.Location = new System.Drawing.Point(440, 316);
            this.txtByteCmdParada.Name = "txtByteCmdParada";
            this.txtByteCmdParada.Size = new System.Drawing.Size(50, 23);
            this.txtByteCmdParada.TabIndex = 48;
            this.txtByteCmdParada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBitCmdParada
            // 
            this.txtBitCmdParada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitCmdParada.Location = new System.Drawing.Point(510, 316);
            this.txtBitCmdParada.MaxLength = 1;
            this.txtBitCmdParada.Name = "txtBitCmdParada";
            this.txtBitCmdParada.Size = new System.Drawing.Size(40, 23);
            this.txtBitCmdParada.TabIndex = 49;
            this.txtBitCmdParada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DatosPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 495);
            this.Controls.Add(this.grpConexion);
            this.Controls.Add(this.grpVariables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatosPLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos PLC";
            this.grpConexion.ResumeLayout(false);
            this.grpConexion.PerformLayout();
            this.grpVariables.ResumeLayout(false);
            this.grpVariables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConexion;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblRack;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpVariables;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label lblDBAyuda;
        private System.Windows.Forms.Label lblColVariable;
        private System.Windows.Forms.Label lblColSentido;
        private System.Windows.Forms.Label lblColTipo;
        private System.Windows.Forms.Label lblColByte;
        private System.Windows.Forms.Label lblColBit;
        private System.Windows.Forms.Label lblVarTempActual;
        private System.Windows.Forms.Label lblSentidoTempActual;
        private System.Windows.Forms.ComboBox cmbTipoTempActual;
        private System.Windows.Forms.TextBox txtByteTempActual;
        private System.Windows.Forms.TextBox txtBitTempActual;
        private System.Windows.Forms.Label lblVarTiempoRestante;
        private System.Windows.Forms.Label lblSentidoTiempoRestante;
        private System.Windows.Forms.ComboBox cmbTipoTiempoRestante;
        private System.Windows.Forms.TextBox txtByteTiempoRestante;
        private System.Windows.Forms.TextBox txtBitTiempoRestante;
        private System.Windows.Forms.Label lblVarSetpoint;
        private System.Windows.Forms.Label lblSentidoSetpoint;
        private System.Windows.Forms.ComboBox cmbTipoSetpoint;
        private System.Windows.Forms.TextBox txtByteSetpoint;
        private System.Windows.Forms.TextBox txtBitSetpoint;
        private System.Windows.Forms.Label lblVarCaldera;
        private System.Windows.Forms.Label lblSentidoCaldera;
        private System.Windows.Forms.ComboBox cmbTipoCaldera;
        private System.Windows.Forms.TextBox txtByteCaldera;
        private System.Windows.Forms.TextBox txtBitCaldera;
        private System.Windows.Forms.Label lblVarMarcha;
        private System.Windows.Forms.Label lblSentidoMarcha;
        private System.Windows.Forms.ComboBox cmbTipoMarcha;
        private System.Windows.Forms.TextBox txtByteMarcha;
        private System.Windows.Forms.TextBox txtBitMarcha;
        private System.Windows.Forms.Label lblVarAlarma;
        private System.Windows.Forms.Label lblSentidoAlarma;
        private System.Windows.Forms.ComboBox cmbTipoAlarma;
        private System.Windows.Forms.TextBox txtByteAlarma;
        private System.Windows.Forms.TextBox txtBitAlarma;
        private System.Windows.Forms.Label lblVarCmdMarcha;
        private System.Windows.Forms.Label lblSentidoCmdMarcha;
        private System.Windows.Forms.ComboBox cmbTipoCmdMarcha;
        private System.Windows.Forms.TextBox txtByteCmdMarcha;
        private System.Windows.Forms.TextBox txtBitCmdMarcha;
        private System.Windows.Forms.Label lblVarCmdParada;
        private System.Windows.Forms.Label lblSentidoCmdParada;
        private System.Windows.Forms.ComboBox cmbTipoCmdParada;
        private System.Windows.Forms.TextBox txtByteCmdParada;
        private System.Windows.Forms.TextBox txtBitCmdParada;
    }
}
