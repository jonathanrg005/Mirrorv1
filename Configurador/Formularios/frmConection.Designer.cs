
namespace Configurador.Formularios
{
    partial class frmConection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConection));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabStandardSecurity = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuarioIDSS = new System.Windows.Forms.TextBox();
            this.txtDataBaseSS = new System.Windows.Forms.TextBox();
            this.txtPassWordSS = new System.Windows.Forms.TextBox();
            this.txtServerSS = new System.Windows.Forms.TextBox();
            this.TabTrustedConnection = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataBaseTC = new System.Windows.Forms.TextBox();
            this.txtServerTC = new System.Windows.Forms.TextBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabStandardSecurity.SuspendLayout();
            this.TabTrustedConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabStandardSecurity);
            this.tabControl1.Controls.Add(this.TabTrustedConnection);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // TabStandardSecurity
            // 
            this.TabStandardSecurity.Controls.Add(this.label4);
            this.TabStandardSecurity.Controls.Add(this.label3);
            this.TabStandardSecurity.Controls.Add(this.label2);
            this.TabStandardSecurity.Controls.Add(this.label1);
            this.TabStandardSecurity.Controls.Add(this.txtUsuarioIDSS);
            this.TabStandardSecurity.Controls.Add(this.txtDataBaseSS);
            this.TabStandardSecurity.Controls.Add(this.txtPassWordSS);
            this.TabStandardSecurity.Controls.Add(this.txtServerSS);
            this.TabStandardSecurity.Location = new System.Drawing.Point(4, 22);
            this.TabStandardSecurity.Name = "TabStandardSecurity";
            this.TabStandardSecurity.Padding = new System.Windows.Forms.Padding(3);
            this.TabStandardSecurity.Size = new System.Drawing.Size(559, 332);
            this.TabStandardSecurity.TabIndex = 0;
            this.TabStandardSecurity.Text = "Standard Security";
            this.TabStandardSecurity.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "PassWord:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "UserID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "DataBase:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server:";
            // 
            // txtUsuarioIDSS
            // 
            this.txtUsuarioIDSS.Location = new System.Drawing.Point(143, 195);
            this.txtUsuarioIDSS.Name = "txtUsuarioIDSS";
            this.txtUsuarioIDSS.Size = new System.Drawing.Size(261, 20);
            this.txtUsuarioIDSS.TabIndex = 3;
            // 
            // txtDataBaseSS
            // 
            this.txtDataBaseSS.Location = new System.Drawing.Point(143, 136);
            this.txtDataBaseSS.Name = "txtDataBaseSS";
            this.txtDataBaseSS.Size = new System.Drawing.Size(261, 20);
            this.txtDataBaseSS.TabIndex = 2;
            // 
            // txtPassWordSS
            // 
            this.txtPassWordSS.Location = new System.Drawing.Point(143, 253);
            this.txtPassWordSS.Name = "txtPassWordSS";
            this.txtPassWordSS.Size = new System.Drawing.Size(261, 20);
            this.txtPassWordSS.TabIndex = 1;
            // 
            // txtServerSS
            // 
            this.txtServerSS.Location = new System.Drawing.Point(143, 81);
            this.txtServerSS.Name = "txtServerSS";
            this.txtServerSS.Size = new System.Drawing.Size(261, 20);
            this.txtServerSS.TabIndex = 0;
            // 
            // TabTrustedConnection
            // 
            this.TabTrustedConnection.Controls.Add(this.label5);
            this.TabTrustedConnection.Controls.Add(this.label6);
            this.TabTrustedConnection.Controls.Add(this.txtDataBaseTC);
            this.TabTrustedConnection.Controls.Add(this.txtServerTC);
            this.TabTrustedConnection.Location = new System.Drawing.Point(4, 22);
            this.TabTrustedConnection.Name = "TabTrustedConnection";
            this.TabTrustedConnection.Padding = new System.Windows.Forms.Padding(3);
            this.TabTrustedConnection.Size = new System.Drawing.Size(559, 332);
            this.TabTrustedConnection.TabIndex = 1;
            this.TabTrustedConnection.Text = "Trusted Connection";
            this.TabTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "DataBase:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(145, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Server:";
            // 
            // txtDataBaseTC
            // 
            this.txtDataBaseTC.Location = new System.Drawing.Point(148, 172);
            this.txtDataBaseTC.Name = "txtDataBaseTC";
            this.txtDataBaseTC.Size = new System.Drawing.Size(261, 20);
            this.txtDataBaseTC.TabIndex = 7;
            // 
            // txtServerTC
            // 
            this.txtServerTC.Location = new System.Drawing.Point(148, 117);
            this.txtServerTC.Name = "txtServerTC";
            this.txtServerTC.Size = new System.Drawing.Size(261, 20);
            this.txtServerTC.TabIndex = 6;
            // 
            // btnVerificar
            // 
            this.btnVerificar.Image = global::Configurador.Properties.Resources.si_5x5;
            this.btnVerificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerificar.Location = new System.Drawing.Point(391, 364);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(75, 50);
            this.btnVerificar.TabIndex = 1;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(488, 364);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmConection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 426);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConection";
            this.tabControl1.ResumeLayout(false);
            this.TabStandardSecurity.ResumeLayout(false);
            this.TabStandardSecurity.PerformLayout();
            this.TabTrustedConnection.ResumeLayout(false);
            this.TabTrustedConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabStandardSecurity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuarioIDSS;
        private System.Windows.Forms.TextBox txtDataBaseSS;
        private System.Windows.Forms.TextBox txtPassWordSS;
        private System.Windows.Forms.TextBox txtServerSS;
        private System.Windows.Forms.TabPage TabTrustedConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataBaseTC;
        private System.Windows.Forms.TextBox txtServerTC;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnSalir;
    }
}