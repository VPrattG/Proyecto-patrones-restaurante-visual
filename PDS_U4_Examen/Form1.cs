using PDS_U4_Examen.Bases;

namespace PDS_U4_Examen
{
    public partial class Form1 : Form
    {
        // Formulario apra transportarse entre otros formularios
        Form2 formularioMesas;
        Form3 formularioOrdenes;
        Form5 formularioInventario;
        Form6 formularioFinal;
        public Form1()
        {
            formularioMesas = new Form2();
            formularioOrdenes = new Form3();
            formularioInventario = new Form5();
            formularioFinal = new Form6();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            this.Hide();
            formularioMesas.ShowDialog();
            this.Show();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Hide();
            formularioOrdenes.ShowDialog();
            this.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            formularioInventario.ShowDialog();
            this.Show();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            //this.Hide();
            formularioFinal.ShowDialog();
            //this.Show();
        }
    }
}