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
    public partial class FrmUniforme : Form
    {
        public FrmUniforme()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario secundario
            this.Close();

            // Crear una instancia del formulario principal
            FrmGeneradorNumeros FrmGeneradorNumeros = new FrmGeneradorNumeros();

            // Mostrar el formulario principal
            FrmGeneradorNumeros.Show();
        }

        private void txtTamañoMuestra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
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

        private void cbIntrevalos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string tamañoMuestra = txtTamañoMuestra.Text;
            string desde = txtDesde.Text;
            string hasta = txtHasta.Text;
            string alfa = txtAlfa.Text;
            int cantidadIntervalo = cbIntrevalos.SelectedIndex;
            
            if (ValidarCampos(tamañoMuestra, desde, alfa, hasta, cantidadIntervalo))
            {

                float[] datos = generarNumeros();
                ChiCuadrado chi = new ChiCuadrado(0, datos, float.Parse(alfa), 17,int.Parse(tamañoMuestra));
                chi.calcularChi();
            }


        }

        private float[] generarNumeros() {

            // Obtener los valores ingresados por el usuario
            int tamañoMuestra = int.Parse(txtTamañoMuestra.Text);
            double a = double.Parse(txtDesde.Text);
            double b = double.Parse(txtHasta.Text);


            

            // Generar números aleatorios
            Random rnd = new Random();
            float[] resultados = new float[tamañoMuestra];
            for (int i = 0; i < tamañoMuestra; i++)
            {
                double aleatorio = rnd.NextDouble(); // Generar número aleatorio entre 0 y 1
                double numeroGenerado = a + (b - a) * aleatorio; // Escalar el número al rango deseado
                resultados[i] = (float)numeroGenerado;
            }
            return resultados;
        }

        private bool ValidarCampos(string tamañoMuestra, string desde, string alfa, string hasta, int cantidadIntervalo)
        {
            // Verificar si los TextBox están vacíos
            if (string.IsNullOrEmpty(tamañoMuestra) || string.IsNullOrEmpty(desde) || string.IsNullOrEmpty(alfa) || string.IsNullOrEmpty(hasta))
            {
                MessageBox.Show("Por favor, completa todos los campos de texto.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si el ComboBox está seleccionado
            if (cantidadIntervalo == -1)
            {
                MessageBox.Show("Por favor, selecciona un valor de intervalos.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt64(this.txtTamañoMuestra.Text.ToString()) > 1000000)
            {
                MessageBox.Show("Debe ingresar una muestra inferior a 1.000.000", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Validar que 'a' sea menor que 'b'
            if (float.Parse(desde) > float.Parse(hasta))
            {
                MessageBox.Show("El valor 'a' debe ser menor que el valor 'b'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Todos los campos están llenos
            return true;
        }
    }
}
