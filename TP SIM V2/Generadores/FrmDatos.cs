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
    public partial class FrmDatos : Form
    {
        float[] datos;
        public FrmDatos(float[] datos)
        {
            InitializeComponent();
            this.datos = datos;
        }

        private void frmDatos_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // Limpia cualquier dato previo en el DataGridView

            // Itera sobre los elementos del vector y agrégalos al DataGridView
            for (int i = 0; i < datos.Length; i++)
            {
                // Añade una nueva fila al DataGridView
                dataGridView1.Rows.Add();

                // Asigna el valor de la columna de numeración
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString(); // Columna 0 es la columna de numeración

                // Asigna el valor de la columna de datos
                dataGridView1.Rows[i].Cells[1].Value = datos[i]; // Columna 1 es la columna de datos
            }
        }
    }
}
