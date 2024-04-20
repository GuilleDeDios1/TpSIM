using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TP_SIM_V2
{
    public partial class FrmNormal : Form
    {
        private FrmGeneradorNumeros _formularioPrincipal;
        public FrmNormal(FrmGeneradorNumeros formularioPrincipal)
        {
            InitializeComponent();
            _formularioPrincipal = formularioPrincipal;
        }

        public List<float> NormalBoxM(int cantidad, int desviacion, int media, float alfa, int intervalo)
        {
            Random rnd = new Random();

            // Crear una lista para almacenar los datos generados
            List<float> resultados = new List<float>();

            // Calcular la cantidad de filas
            int filas = cantidad / 2;
            // Generar los números aleatorios y calcular los resultados
            for (int i = 0; i < filas; i++)
            {
                double numero1 = Math.Round(rnd.NextDouble(), 4);
                double numero2 = Math.Round(rnd.NextDouble(), 4);
                float resultado1 = (float)Math.Round(CalculadoraEcuaciones.CalcularEcuacion1(numero1, numero2, desviacion, media), 4);
                float resultado2 = (float)Math.Round(CalculadoraEcuaciones.CalcularEcuacion2(numero1, numero2, desviacion, media), 4);
                resultados.Add(resultado1);
                resultados.Add(resultado2);
            }

            //Agregar un resultado adicional si la cantidad es impar
            if (cantidad % 2 != 0)
            {
                double numeroExtra1 = Math.Round(rnd.NextDouble(), 4);
                double numeroExtra2 = Math.Round(rnd.NextDouble(), 4);
                float resultadoExtra1 = (float)Math.Round(CalculadoraEcuaciones.CalcularEcuacion1(numeroExtra1, numeroExtra2, desviacion, media), 4);
                resultados.Add(resultadoExtra1);
            }

            // Exportar los resultados
            Exportador exportar = new Exportador();
            exportar.Exportar(resultados.ToArray(), "C:\\Users\\Francisco\\Desktop\\TP SIM V2\\TP SIM V2", "datosNormal");

            return resultados;
        }

        // Método Box-M.
        public class CalculadoraEcuaciones
        {
            //N1
            public static double CalcularEcuacion1(double valor1, double valor2, int desviacion, int media)
            {
                return (((Math.Sqrt(-2 * Math.Log(valor1))) * Math.Cos(2 * Math.PI * valor2)) * desviacion) + media;
            }

            //N2
            public static double CalcularEcuacion2(double valor1, double valor2, int desviacion, int media)
            {
                return (((Math.Sqrt(-2 * Math.Log(valor1))) * Math.Sin(2 * Math.PI * valor2)) * desviacion) + media;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string valor1 = txtTamañoMuestra.Text;
            string valor2 = txtMedia.Text;
            string valor3 = txtDesviacion.Text;
            string valor4 = txtAlfa.Text;
            int indiceCombo = int.Parse(cbIntrevalos.Text);

            if (ValidarCampos(valor1, valor2, valor3, valor4, indiceCombo))
            {
                //guardar valor de muestra, desviación y media

                int cantidad = int.Parse(txtTamañoMuestra.Text);

                int desviacion = int.Parse(txtDesviacion.Text);

                int media = int.Parse(txtMedia.Text);

                float alfa = float.Parse(txtAlfa.Text);

                int intervalo = indiceCombo;

                List<float> resultados = NormalBoxM(cantidad, desviacion, media, alfa, intervalo);

                if (ckbDatos.Checked)
                {                    
                    FrmDatos frmDatos = new FrmDatos(resultados.ToArray());

                    frmDatos.ShowDialog();
                }

                ChiCuadrado chi = new ChiCuadrado(2, resultados.ToArray(), alfa, intervalo, cantidad);
                Exportador exp = new Exportador();
                exp.Exportar(resultados.ToArray(), "C:\\Users\\guill\\OneDrive\\Escritorio\\TP SIM V2", "NumerosAleatoriosUniforme");
                chi.calcularChi();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario secundario
            this.Close();

            // Mostrar nuevamente el formulario principal
            _formularioPrincipal.Show();
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

        private void txtMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, teclas de control y la coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignorar el carácter
            }

            // Permitir solo un signo "-" al principio
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.Contains('-')))
            {
                e.Handled = true; // Ignorar el carácter
            }

            // Permitir solo una coma
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.Contains(',')))
            {
                e.Handled = true; // Ignorar el carácter
            }
        }

        private void txtDesviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos(string valorTextBox1, string valorTextBox2, string valorTextBox3, string valorTextBox4, int indiceComboBox)
        {
            // Verificar si los TextBox están vacíos
            if (string.IsNullOrEmpty(valorTextBox1) || string.IsNullOrEmpty(valorTextBox2) || string.IsNullOrEmpty(valorTextBox3) || string.IsNullOrEmpty(valorTextBox4))
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

        private void FrmNormal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar nuevamente el formulario principal
            FrmGeneradorNumeros FrmGeneradorNumeros = new FrmGeneradorNumeros();
            FrmGeneradorNumeros.Show();
        }

        private void FrmNormal_Load(object sender, EventArgs e)
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
