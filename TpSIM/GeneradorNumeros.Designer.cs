namespace TpSIM
{
    partial class GeneradorNumeros
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUniforme = new Button();
            btnExponencial = new Button();
            btnNormal = new Button();
            SuspendLayout();
            // 
            // btnUniforme
            // 
            btnUniforme.Location = new Point(73, 30);
            btnUniforme.Name = "btnUniforme";
            btnUniforme.Size = new Size(117, 57);
            btnUniforme.TabIndex = 0;
            btnUniforme.Text = "Uniforme";
            btnUniforme.UseVisualStyleBackColor = true;
            btnUniforme.Click += btnUniforme_Click;
            // 
            // btnExponencial
            // 
            btnExponencial.Location = new Point(73, 110);
            btnExponencial.Name = "btnExponencial";
            btnExponencial.Size = new Size(117, 57);
            btnExponencial.TabIndex = 1;
            btnExponencial.Text = "Exponencial";
            btnExponencial.UseVisualStyleBackColor = true;
            btnExponencial.Click += btnExponencial_Click;
            // 
            // btnNormal
            // 
            btnNormal.Location = new Point(73, 191);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(117, 57);
            btnNormal.TabIndex = 2;
            btnNormal.Text = "Normal";
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Click += btnNormal_Click;
            // 
            // GeneradorNumeros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 291);
            Controls.Add(btnNormal);
            Controls.Add(btnExponencial);
            Controls.Add(btnUniforme);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GeneradorNumeros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generador De Numeros";
            Load += GeneradorNumeros_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnUniforme;
        private Button btnExponencial;
        private Button btnNormal;
    }
}