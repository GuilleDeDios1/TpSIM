using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP_SIM_V2.Grafico
{
    public partial class FrmHistograma : Form
    {
        float[][] matriz;
        List<List<float>> agrupada;
        float count;
        float valorCritico;
        
        public FrmHistograma(float[][] matriz, List<List<float>> agrupada, float count, float valorCritico)
        {
            this.matriz = matriz;
            this.agrupada = agrupada;
            this.count = count;
            this.valorCritico = valorCritico;
            InitializeComponent();
        }

        private void FrmHistograma_Load(object sender, EventArgs e)
        {
            // Datos de ejemplo de rango y cantidad observada
            List<(string, float)> datos = new List<(string, float)>();

            for (int i = 0; i < matriz.Length; i++) {
                datos.Add((matriz[i][0].ToString() + "-" + matriz[i][1].ToString(), matriz[i][2]));
            }
            

            // Agregar una serie al Chart
            chart1.Series.Clear();
            chart1.Series.Add("Cantidad Observada");

            // Agregar puntos de datos basados en los rangos y la cantidad observada
            foreach (var (rango, cantidad) in datos)
            {
                chart1.Series["Cantidad Observada"].Points.AddXY(rango, cantidad);
            }

            // Personalizar el tipo de gráfico y el formato del eje X
            chart1.Series["Cantidad Observada"].ChartType = SeriesChartType.Column;
            chart1.Series["Cantidad Observada"]["PointWidth"] = "0.8"; // Establecer el ancho relativo de las columnas
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // Deshabilitar las líneas de la cuadrícula para una apariencia más limpia

            // Establecer el número de columnas en el DataGridView
            dataGridView1.ColumnCount = matriz[0].Length;

            // Agregar filas y llenar el DataGridView con los datos de la matriz
            for (int i = 0; i < matriz.Length; i++)
            {
                dataGridView1.Rows.Add();
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matriz[i][j];
                }
            }
            
            //Muestra la tabla de frecuencia ya agrupada
            // Establecer el número de columnas en el DataGridView
            dataGridView1.ColumnCount = agrupada[0].Count;

            // Agregar filas y llenar el DataGridView con los datos de la lista de listas
            foreach (List<float> fila in agrupada)
            {
                int rowIndex = dataGridView2.Rows.Add(); // Agregar una nueva fila y obtener su índice
                for (int j = 0; j < fila.Count; j++)
                {
                    dataGridView2.Rows[rowIndex].Cells[j].Value = fila[j]; // Asignar el valor de la lista a la celda
                }
            }
            txtChiCalculado.Text = count.ToString();
            txtChiCuadradoTabulado.Text = valorCritico.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario secundario
            this.Hide();
        }
    }
}
