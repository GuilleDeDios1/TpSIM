namespace TpSIM.Generadores
{
    partial class FrmNormalBoxM
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
            tablaRND = new DataGridView();
            RND1 = new DataGridViewTextBoxColumn();
            RND2 = new DataGridViewTextBoxColumn();
            txtRandoms = new Label();
            txtValores = new Label();
            ((System.ComponentModel.ISupportInitialize)tablaRND).BeginInit();
            SuspendLayout();
            // 
            // tablaRND
            // 
            tablaRND.AllowUserToOrderColumns = true;
            tablaRND.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablaRND.Columns.AddRange(new DataGridViewColumn[] { RND1, RND2 });
            tablaRND.Location = new Point(12, 46);
            tablaRND.Name = "tablaRND";
            tablaRND.RowTemplate.Height = 25;
            tablaRND.Size = new Size(243, 622);
            tablaRND.TabIndex = 0;
            // 
            // RND1
            // 
            RND1.HeaderText = "RND1";
            RND1.Name = "RND1";
            // 
            // RND2
            // 
            RND2.HeaderText = "RND2";
            RND2.Name = "RND2";
            // 
            // txtRandoms
            // 
            txtRandoms.AutoSize = true;
            txtRandoms.Location = new Point(24, 28);
            txtRandoms.Name = "txtRandoms";
            txtRandoms.Size = new Size(101, 15);
            txtRandoms.TabIndex = 2;
            txtRandoms.Text = "Valores aleatorios:";
            // 
            // txtValores
            // 
            txtValores.AutoSize = true;
            txtValores.Location = new Point(304, 28);
            txtValores.Name = "txtValores";
            txtValores.Size = new Size(105, 15);
            txtValores.TabIndex = 3;
            txtValores.Text = "Valores generados:";
            // 
            // FrmNormalBoxM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 450);
            Controls.Add(txtValores);
            Controls.Add(txtRandoms);
            Controls.Add(tablaRND);
            Name = "FrmNormalBoxM";
            Text = "FrmNormalBoxM";
            Load += FrmNormalBoxM_Load;
            ((System.ComponentModel.ISupportInitialize)tablaRND).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tablaRND;
        private DataGridViewTextBoxColumn RND1;
        private DataGridViewTextBoxColumn RND2;
        private Label txtRandoms;
        private Label txtValores;
    }
}