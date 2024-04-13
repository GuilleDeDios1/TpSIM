using TpSIM.Generadores;

namespace TpSIM
{
    public partial class GeneradorNumeros : Form
    {
        public GeneradorNumeros()
        {
            InitializeComponent();
        }

        private void btnUniforme_Click(object sender, EventArgs e)
        {
            
            new FrmUniforme().ShowDialog();
        }

        private void btnExponencial_Click(object sender, EventArgs e)
        {
            new FrmExponencial().ShowDialog();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            new FrmNormal().ShowDialog();
        }

        private void GeneradorNumeros_Load(object sender, EventArgs e)
        {

        }
    }
}