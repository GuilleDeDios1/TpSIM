﻿namespace TP_SIM_V2
{
    partial class FrmUniforme
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbIntrevalos = new System.Windows.Forms.ComboBox();
            this.txtAlfa = new System.Windows.Forms.TextBox();
            this.lblIntervalos = new System.Windows.Forms.Label();
            this.lblAlfa = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtTamañoMuestra = new System.Windows.Forms.TextBox();
            this.lblLambda = new System.Windows.Forms.Label();
            this.lblTamañoMuestra = new System.Windows.Forms.Label();
            this.ckbDatos = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(11, 293);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(186, 293);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 23);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbIntrevalos);
            this.groupBox2.Controls.Add(this.txtAlfa);
            this.groupBox2.Controls.Add(this.lblIntervalos);
            this.groupBox2.Controls.Add(this.lblAlfa);
            this.groupBox2.Location = new System.Drawing.Point(11, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 115);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Chi Cuadrado";
            // 
            // cbIntrevalos
            // 
            this.cbIntrevalos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIntrevalos.FormattingEnabled = true;
            this.cbIntrevalos.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25"});
            this.cbIntrevalos.Location = new System.Drawing.Point(116, 68);
            this.cbIntrevalos.Name = "cbIntrevalos";
            this.cbIntrevalos.Size = new System.Drawing.Size(100, 21);
            this.cbIntrevalos.TabIndex = 5;
            this.cbIntrevalos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbIntrevalos_KeyPress);
            // 
            // txtAlfa
            // 
            this.txtAlfa.Location = new System.Drawing.Point(116, 34);
            this.txtAlfa.Name = "txtAlfa";
            this.txtAlfa.Size = new System.Drawing.Size(100, 20);
            this.txtAlfa.TabIndex = 4;
            this.txtAlfa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlfa_KeyPress);
            // 
            // lblIntervalos
            // 
            this.lblIntervalos.AutoSize = true;
            this.lblIntervalos.Location = new System.Drawing.Point(22, 71);
            this.lblIntervalos.Name = "lblIntervalos";
            this.lblIntervalos.Size = new System.Drawing.Size(53, 13);
            this.lblIntervalos.TabIndex = 1;
            this.lblIntervalos.Text = "Intervalos";
            // 
            // lblAlfa
            // 
            this.lblAlfa.AutoSize = true;
            this.lblAlfa.Location = new System.Drawing.Point(22, 37);
            this.lblAlfa.Name = "lblAlfa";
            this.lblAlfa.Size = new System.Drawing.Size(25, 13);
            this.lblAlfa.TabIndex = 0;
            this.lblAlfa.Text = "Alfa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDesde);
            this.groupBox1.Controls.Add(this.txtTamañoMuestra);
            this.groupBox1.Controls.Add(this.lblLambda);
            this.groupBox1.Controls.Add(this.lblTamañoMuestra);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generador";
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(116, 103);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(100, 20);
            this.txtHasta.TabIndex = 5;
            this.txtHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHasta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hasta";
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(116, 68);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(100, 20);
            this.txtDesde.TabIndex = 3;
            this.txtDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesde_KeyPress);
            // 
            // txtTamañoMuestra
            // 
            this.txtTamañoMuestra.Location = new System.Drawing.Point(116, 34);
            this.txtTamañoMuestra.Name = "txtTamañoMuestra";
            this.txtTamañoMuestra.Size = new System.Drawing.Size(100, 20);
            this.txtTamañoMuestra.TabIndex = 2;
            this.txtTamañoMuestra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTamañoMuestra_KeyPress);
            // 
            // lblLambda
            // 
            this.lblLambda.AutoSize = true;
            this.lblLambda.Location = new System.Drawing.Point(22, 71);
            this.lblLambda.Name = "lblLambda";
            this.lblLambda.Size = new System.Drawing.Size(38, 13);
            this.lblLambda.TabIndex = 1;
            this.lblLambda.Text = "Desde";
            // 
            // lblTamañoMuestra
            // 
            this.lblTamañoMuestra.AutoSize = true;
            this.lblTamañoMuestra.Location = new System.Drawing.Point(22, 37);
            this.lblTamañoMuestra.Name = "lblTamañoMuestra";
            this.lblTamañoMuestra.Size = new System.Drawing.Size(87, 13);
            this.lblTamañoMuestra.TabIndex = 0;
            this.lblTamañoMuestra.Text = "Tamaño Muestra";
            // 
            // ckbDatos
            // 
            this.ckbDatos.AutoSize = true;
            this.ckbDatos.Location = new System.Drawing.Point(88, 297);
            this.ckbDatos.Name = "ckbDatos";
            this.ckbDatos.Size = new System.Drawing.Size(92, 17);
            this.ckbDatos.TabIndex = 12;
            this.ckbDatos.Text = "Mostrar Datos";
            this.ckbDatos.UseVisualStyleBackColor = true;
            // 
            // FrmUniforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 328);
            this.Controls.Add(this.ckbDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUniforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uniforme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUniforme_FormClosing);
            this.Load += new System.EventHandler(this.FrmUniforme_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbIntrevalos;
        private System.Windows.Forms.Label lblIntervalos;
        private System.Windows.Forms.Label lblAlfa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.TextBox txtTamañoMuestra;
        private System.Windows.Forms.Label lblLambda;
        private System.Windows.Forms.Label lblTamañoMuestra;
        private System.Windows.Forms.TextBox txtAlfa;
        private System.Windows.Forms.CheckBox ckbDatos;
    }
}