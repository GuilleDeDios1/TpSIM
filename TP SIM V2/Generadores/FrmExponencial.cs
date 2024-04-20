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

namespace TP_SIM_V2
{
    public partial class FrmExponencial : Form
    {
        private FrmGeneradorNumeros _formularioPrincipal;
        
        private Random random = new Random();
        public FrmExponencial(FrmGeneradorNumeros formularioPrincipal)
        {
            InitializeComponent();
            _formularioPrincipal = formularioPrincipal;
        }

        private float[] GenerarExponenciales(int tamañoMuestra, float lambda)
        {
            float[] numerosAleatorios = new float[tamañoMuestra];
            for (int i = 0; i < tamañoMuestra; i++)
            {
                float u = (float)random.NextDouble(); // Generar número aleatorio uniforme entre 0 y 1
                float x = (float)(-1 / lambda * Math.Log(1 - u)); // Transformación inversa de la distribución exponencial
                x = (float)Math.Round(x, 4); // Ajustar la precisión a 4 decimales
                numerosAleatorios[i] = x;
            }
            return numerosAleatorios;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string tamMuestra = txtTamañoMuestra.Text;
            string lambda = txtLambda.Text;
            string alfa = txtAlfa.Text;
            int indiceCombo = int.Parse(cbIntrevalos.Text);

            if (ValidarCampos(tamMuestra, lambda, alfa, indiceCombo))
            {
                float[] numerosAleatorios = GenerarExponenciales(int.Parse(tamMuestra), float.Parse(lambda));
                
                if (ckbDatos.Checked)
                {
                    FrmDatos frmDatos = new FrmDatos(numerosAleatorios);

                    frmDatos.ShowDialog();
                }

                ChiCuadrado chi = new ChiCuadrado(1, numerosAleatorios, float.Parse(alfa), indiceCombo, int.Parse(tamMuestra));
                Exportador exp = new Exportador();
                exp.Exportar(numerosAleatorios, "C:\\Users\\guill\\OneDrive\\Escritorio\\TP SIM V2", "NumerosAleatoriosExponencial");
                chi.calcularChi();
            }
        }

        private void txtTamañoMuestra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLambda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignorar el carácter
            }

            // Permitir solo una coma
            if ((e.KeyChar == ',') && (txtLambda.Text.Contains(',')))
            {
                e.Handled = true; // Ignorar el carácter
            }
        }

        private void cbIntrevalos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario secundario
            this.Close();

            // Mostrar nuevamente el formulario principal
            _formularioPrincipal.Show();
        }

        private bool ValidarCampos(string valorTextBox1, string valorTextBox2, string valorTextBox3, int indiceComboBox)
        {
            // Verificar si los TextBox están vacíos
            if (string.IsNullOrEmpty(valorTextBox1) || string.IsNullOrEmpty(valorTextBox2) || string.IsNullOrEmpty(valorTextBox3))
            {
                MessageBox.Show("Por favor, completa todos los campos de texto.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si el ComboBox está seleccionado
            if (indiceComboBox == -1)
            {
                MessageBox.Show("Por favor, selecciona un valor de intervalos.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt64(this.txtTamañoMuestra.Text.ToString()) > 1000000)
            {
                MessageBox.Show("Debe ingresar una muestra inferior a 1.000.000", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Todos los campos están llenos
            return true;
        }

        private void FrmExponencial_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar nuevamente el formulario principal
            FrmGeneradorNumeros FrmGeneradorNumeros = new FrmGeneradorNumeros();
            FrmGeneradorNumeros.Show();
        }

        private void FrmExponencial_Load(object sender, EventArgs e)
        {

        }

        private void txtAlfa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, teclas de control y la coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignorar el carácter
            }

            // Permitir solo una coma
            if ((e.KeyChar == ',') && (txtAlfa.Text.Contains(',')))
            {
                e.Handled = true; // Ignorar el carácter
            }
        }
    }
}
