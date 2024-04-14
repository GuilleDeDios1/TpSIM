using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpSIM.Generadores
{
    public partial class FrmNormalBoxM : Form
    {
        public FrmNormalBoxM(int cantidad, int desviacion, int media)
        {
            InitializeComponent();
            Random rnd = new Random();

            // Calcular la cantidad de filas
            int filas = cantidad / 2;
            bool cantidadEsImpar = cantidad % 2 != 0;

            // Generar los números aleatorios
            for (int i = 0; i < filas; i++)
            {
                double numero1 = Math.Round(rnd.NextDouble(), 4);
                double numero2 = Math.Round(rnd.NextDouble(), 4);
                tablaRND.Rows.Add(numero1, numero2);
            }
            //Agregar una fila adicional si la cantidad es impar
            if (cantidad % 2 != 0)
            {
                double numeroExtra1 = Math.Round(rnd.NextDouble(), 4);
                double numeroExtra2 = Math.Round(rnd.NextDouble(), 4);
                tablaRND.Rows.Add(numeroExtra1, numeroExtra2);
            }

            //Generar valores de segunda tabla: Box-Muller
            // Crear una nueva tabla de dos columnas
            DataGridView nuevaTabla = new DataGridView();
            nuevaTabla.Columns.Add("Resultado1", "Resultado 1");
            nuevaTabla.Columns.Add("Resultado2", "Resultado 2");
            nuevaTabla.Size = new Size(243, 622); // tamaño de la tabla
            nuevaTabla.Location = new Point(300, 46); // ubicación de la tabla
            Controls.Add(nuevaTabla);


            foreach (DataGridViewRow fila in tablaRND.Rows)
            {
                // Verificar si la fila no es la última y si los valores en las dos primeras columnas no son nulos
                if (!fila.IsNewRow && fila.Cells[0].Value != null && fila.Cells[1].Value != null)
                {
                    // Obtener los valores de las dos primeras columnas de esa fila
                    double valor1, valor2;

                    // Verificar si los valores son numéricos y no nulos
                    if (double.TryParse(fila.Cells[0].Value.ToString(), out valor1) && double.TryParse(fila.Cells[1].Value.ToString(), out valor2))
                    {
                        double resultado1 = Math.Round(CalculadoraEcuaciones.CalcularEcuacion1(valor1, valor2, desviacion, media), 4);
                        double resultado2 = Math.Round(CalculadoraEcuaciones.CalcularEcuacion2(valor1, valor2, desviacion, media), 4);

                        // Agregar los resultados a la nueva tabla
                        nuevaTabla.Rows.Add(resultado1, resultado2);
                    }
                }

            }
           
        }

        // Método Box-M.
        public class CalculadoraEcuaciones
        {
            //N1
            public static double CalcularEcuacion1(double valor1, double valor2, int desviacion, int media)
            {
                double resultado1 = (((Math.Sqrt(-2 * Math.Log(valor1))) * Math.Cos(2 * Math.PI * valor2)) * desviacion) + media;
                return resultado1;
            }

            //N2
            public static double CalcularEcuacion2(double valor1, double valor2, int desviacion, int media)
            {
                double resultado2 = (((Math.Sqrt(-2 * Math.Log(valor1))) * Math.Sin(2 * Math.PI * valor2)) * desviacion) + media;
                return resultado2;
            }
        }


        private void FrmNormalBoxM_Load(object sender, EventArgs e)
        {

        }
    }
}
