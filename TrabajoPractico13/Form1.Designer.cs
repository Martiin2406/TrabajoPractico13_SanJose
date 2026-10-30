namespace TrabajoPractico13
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_datosplc = new System.Windows.Forms.Button();
            this.diagrama = new TrabajoPractico13.DiagramaHorno();
            this.pilMarcha = new TrabajoPractico13.Piloto();
            this.lblMarcha = new System.Windows.Forms.Label();
            this.lblTempActual = new System.Windows.Forms.Label();
            this.txtTempActual = new System.Windows.Forms.TextBox();
            this.lblTempUnidad = new System.Windows.Forms.Label();
            this.lblSetpoint = new System.Windows.Forms.Label();
            this.txtSetpoint = new System.Windows.Forms.TextBox();
            this.lblSetpointUnidad = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtTiempoRestante = new System.Windows.Forms.TextBox();
            this.pilCaldera = new TrabajoPractico13.Piloto();
            this.lblCaldera = new System.Windows.Forms.Label();
            this.diagrama.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_datosplc
            // 
            this.btn_datosplc.Location = new System.Drawing.Point(420, 575);
            this.btn_datosplc.Name = "btn_datosplc";
            this.btn_datosplc.Size = new System.Drawing.Size(115, 23);
            this.btn_datosplc.TabIndex = 1;
            this.btn_datosplc.Text = "Datos PLC";
            this.btn_datosplc.UseVisualStyleBackColor = true;
            this.btn_datosplc.Click += new System.EventHandler(this.button1_Click);
            // 
            // diagrama
            // 
            this.diagrama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.diagrama.Controls.Add(this.pilMarcha);
            this.diagrama.Controls.Add(this.lblMarcha);
            this.diagrama.Controls.Add(this.lblTempActual);
            this.diagrama.Controls.Add(this.txtTempActual);
            this.diagrama.Controls.Add(this.lblTempUnidad);
            this.diagrama.Controls.Add(this.lblSetpoint);
            this.diagrama.Controls.Add(this.txtSetpoint);
            this.diagrama.Controls.Add(this.lblSetpointUnidad);
            this.diagrama.Controls.Add(this.lblTiempo);
            this.diagrama.Controls.Add(this.txtTiempoRestante);
            this.diagrama.Controls.Add(this.pilCaldera);
            this.diagrama.Controls.Add(this.lblCaldera);
            this.diagrama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagrama.Location = new System.Drawing.Point(0, 0);
            this.diagrama.Name = "diagrama";
            this.diagrama.Size = new System.Drawing.Size(1000, 610);
            this.diagrama.TabIndex = 0;
            // 
            // pilMarcha
            // 
            this.pilMarcha.BackColor = System.Drawing.Color.Transparent;
            this.pilMarcha.Location = new System.Drawing.Point(24, 90);
            this.pilMarcha.Name = "pilMarcha";
            this.pilMarcha.Size = new System.Drawing.Size(34, 34);
            this.pilMarcha.TabIndex = 0;
            // 
            // lblMarcha
            // 
            this.lblMarcha.AutoSize = true;
            this.lblMarcha.BackColor = System.Drawing.Color.Transparent;
            this.lblMarcha.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcha.Location = new System.Drawing.Point(64, 97);
            this.lblMarcha.Name = "lblMarcha";
            this.lblMarcha.Size = new System.Drawing.Size(75, 20);
            this.lblMarcha.TabIndex = 1;
            this.lblMarcha.Text = "MARCHA";
            // 
            // lblTempActual
            // 
            this.lblTempActual.AutoSize = true;
            this.lblTempActual.BackColor = System.Drawing.Color.Transparent;
            this.lblTempActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempActual.Location = new System.Drawing.Point(828, 172);
            this.lblTempActual.Name = "lblTempActual";
            this.lblTempActual.Size = new System.Drawing.Size(115, 15);
            this.lblTempActual.TabIndex = 2;
            this.lblTempActual.Text = "Temperatura actual";
            // 
            // txtTempActual
            // 
            this.txtTempActual.BackColor = System.Drawing.Color.Black;
            this.txtTempActual.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempActual.ForeColor = System.Drawing.Color.Lime;
            this.txtTempActual.Location = new System.Drawing.Point(830, 194);
            this.txtTempActual.Name = "txtTempActual";
            this.txtTempActual.ReadOnly = true;
            this.txtTempActual.Size = new System.Drawing.Size(100, 30);
            this.txtTempActual.TabIndex = 3;
            this.txtTempActual.TabStop = false;
            this.txtTempActual.Text = "0";
            this.txtTempActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTempUnidad
            // 
            this.lblTempUnidad.AutoSize = true;
            this.lblTempUnidad.BackColor = System.Drawing.Color.Transparent;
            this.lblTempUnidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempUnidad.Location = new System.Drawing.Point(934, 198);
            this.lblTempUnidad.Name = "lblTempUnidad";
            this.lblTempUnidad.Size = new System.Drawing.Size(24, 20);
            this.lblTempUnidad.TabIndex = 4;
            this.lblTempUnidad.Text = "°C";
            // 
            // lblSetpoint
            // 
            this.lblSetpoint.AutoSize = true;
            this.lblSetpoint.BackColor = System.Drawing.Color.Transparent;
            this.lblSetpoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetpoint.Location = new System.Drawing.Point(88, 266);
            this.lblSetpoint.Name = "lblSetpoint";
            this.lblSetpoint.Size = new System.Drawing.Size(55, 15);
            this.lblSetpoint.TabIndex = 5;
            this.lblSetpoint.Text = "Setpoint";
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetpoint.Location = new System.Drawing.Point(90, 286);
            this.txtSetpoint.MaxLength = 4;
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(95, 30);
            this.txtSetpoint.TabIndex = 6;
            this.txtSetpoint.Text = "0";
            this.txtSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSetpointUnidad
            // 
            this.lblSetpointUnidad.AutoSize = true;
            this.lblSetpointUnidad.BackColor = System.Drawing.Color.Transparent;
            this.lblSetpointUnidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetpointUnidad.Location = new System.Drawing.Point(188, 290);
            this.lblSetpointUnidad.Name = "lblSetpointUnidad";
            this.lblSetpointUnidad.Size = new System.Drawing.Size(24, 20);
            this.lblSetpointUnidad.TabIndex = 7;
            this.lblSetpointUnidad.Text = "°C";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(718, 300);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(177, 15);
            this.lblTiempo.TabIndex = 8;
            this.lblTiempo.Text = "Tiempo de encendido restante";
            // 
            // txtTiempoRestante
            // 
            this.txtTiempoRestante.BackColor = System.Drawing.Color.Black;
            this.txtTiempoRestante.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempoRestante.ForeColor = System.Drawing.Color.Lime;
            this.txtTiempoRestante.Location = new System.Drawing.Point(720, 320);
            this.txtTiempoRestante.Name = "txtTiempoRestante";
            this.txtTiempoRestante.ReadOnly = true;
            this.txtTiempoRestante.Size = new System.Drawing.Size(100, 30);
            this.txtTiempoRestante.TabIndex = 9;
            this.txtTiempoRestante.TabStop = false;
            this.txtTiempoRestante.Text = "00:00";
            this.txtTiempoRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pilCaldera
            // 
            this.pilCaldera.BackColor = System.Drawing.Color.Transparent;
            this.pilCaldera.ColorEncendido = System.Drawing.Color.OrangeRed;
            this.pilCaldera.Location = new System.Drawing.Point(618, 410);
            this.pilCaldera.Name = "pilCaldera";
            this.pilCaldera.Size = new System.Drawing.Size(34, 34);
            this.pilCaldera.TabIndex = 10;
            // 
            // lblCaldera
            // 
            this.lblCaldera.AutoSize = true;
            this.lblCaldera.BackColor = System.Drawing.Color.Transparent;
            this.lblCaldera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaldera.Location = new System.Drawing.Point(656, 419);
            this.lblCaldera.Name = "lblCaldera";
            this.lblCaldera.Size = new System.Drawing.Size(108, 15);
            this.lblCaldera.TabIndex = 11;
            this.lblCaldera.Text = "Caldera encendida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.btn_datosplc);
            this.Controls.Add(this.diagrama);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TP13 - Control de temperatura de horno";
            this.diagrama.ResumeLayout(false);
            this.diagrama.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DiagramaHorno diagrama;
        private Piloto pilMarcha;
        private System.Windows.Forms.Label lblMarcha;
        private System.Windows.Forms.Label lblTempActual;
        private System.Windows.Forms.TextBox txtTempActual;
        private System.Windows.Forms.Label lblTempUnidad;
        private System.Windows.Forms.Label lblSetpoint;
        private System.Windows.Forms.TextBox txtSetpoint;
        private System.Windows.Forms.Label lblSetpointUnidad;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.TextBox txtTiempoRestante;
        private Piloto pilCaldera;
        private System.Windows.Forms.Label lblCaldera;
        private System.Windows.Forms.Button btn_datosplc;
    }
}

