namespace TP_SIM_V2
{
    partial class FrmGeneradorNumeros
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
            this.btnUniforme = new System.Windows.Forms.Button();
            this.btnExponencial = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUniforme
            // 
            this.btnUniforme.Location = new System.Drawing.Point(91, 48);
            this.btnUniforme.Name = "btnUniforme";
            this.btnUniforme.Size = new System.Drawing.Size(134, 61);
            this.btnUniforme.TabIndex = 0;
            this.btnUniforme.Text = "Uniforme";
            this.btnUniforme.UseVisualStyleBackColor = true;
            this.btnUniforme.Click += new System.EventHandler(this.btnUniforme_Click);
            // 
            // btnExponencial
            // 
            this.btnExponencial.Location = new System.Drawing.Point(91, 115);
            this.btnExponencial.Name = "btnExponencial";
            this.btnExponencial.Size = new System.Drawing.Size(134, 61);
            this.btnExponencial.TabIndex = 1;
            this.btnExponencial.Text = "Exponencial";
            this.btnExponencial.UseVisualStyleBackColor = true;
            this.btnExponencial.Click += new System.EventHandler(this.btnExponencial_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(91, 182);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(134, 61);
            this.btnNormal.TabIndex = 2;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.Location = new System.Drawing.Point(88, 20);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(143, 13);
            this.lblSeleccion.TabIndex = 3;
            this.lblSeleccion.Text = "Seleccione una distribucion: ";
            // 
            // FrmGeneradorNumeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 268);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnExponencial);
            this.Controls.Add(this.btnUniforme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmGeneradorNumeros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Numeros";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUniforme;
        private System.Windows.Forms.Button btnExponencial;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label lblSeleccion;
    }
}

