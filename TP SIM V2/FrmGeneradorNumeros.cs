using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SIM_V2
{
    public partial class FrmGeneradorNumeros : Form
    {
        public FrmGeneradorNumeros()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            // Ocultar el formulario principal
            this.Hide();

            // Crear una instancia del formulario secundario
            FrmNormal FrmNormal = new FrmNormal(this);
            
            // Mostrar el formulario secundario
            FrmNormal.Show();
        }

        private void btnExponencial_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide();

            // Crear una instancia del formulario secundario
            FrmExponencial frmExponencial = new FrmExponencial(this);

            // Mostrar el formulario secundario
            frmExponencial.Show();
        }

        private void btnUniforme_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide();

            // Crear una instancia del formulario secundario
            FrmUniforme frmUniforme = new FrmUniforme(this);

            // Mostrar el formulario secundario
            frmUniforme.Show();
        }

        private void FrmGeneradorNumeros_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
