using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TpSIM.Generadores
{
    public partial class FrmNormal : Form
    {
        public FrmNormal()
        {
            InitializeComponent();
        }

        private void FrmNormal_Load(object sender, EventArgs e)
        {

        }

        private void txtTamañoMuestra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si la tecla presionada no es un número y no es la tecla de retroceso, se ignora
                e.Handled = true;
            }
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAlfa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmNormal_Load_1(object sender, EventArgs e)
        {
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {   
            // validar núemro de mmuestra

            if (Convert.ToInt64(this.txtTamañoMuestra.Text.ToString()) > 1000000)
            {
                MessageBox.Show("Debe ingresar una muestra inferior a 1.000.000", "Error");
                return;
            }

            //guardar valor de muestra, desviación y media

            int cantidad = int.Parse(txtTamañoMuestra.Text);
            
            int desviacion = int.Parse(txtHasta.Text);
           
            int media = int.Parse(txtDesde.Text);
           

            FrmNormalBoxM ventana1BM = new FrmNormalBoxM(cantidad, desviacion, media);
            ventana1BM.Show();

           

        }
    }
}
