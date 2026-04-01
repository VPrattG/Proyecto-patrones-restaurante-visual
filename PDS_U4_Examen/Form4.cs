using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDS_U4_Examen
{
    public partial class Form4 : Form
    {
        public Form4(string contenido)
        {
            InitializeComponent();
            txtVentas.Text = contenido;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
