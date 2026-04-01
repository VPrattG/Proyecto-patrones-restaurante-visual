using PDS_U4_Examen.Bases;
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
    public partial class Form2 : Form
    {
        // Formulario encargado de la gestión de mesas

        private AdministradorMesa admin;
        public Form2()
        {
            //Cargar();
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void Form2_Shown(object sender, FormClosedEventArgs e)
        {

        }
        private void Cargar()
        {
            admin = AdministradorMesa.ObtenerInstancia();

            nudMesa.Minimum = 1;
            nudMesa.Maximum = AdministradorMesa.maximoMesas;

            ActualizarEtiquetas();
        }

        // Actualizar las etiquetas que indican el estado de las mesas
        private void ActualizarEtiquetas()
        {
            List<string> valores = admin.ObtenerInfoMesas();
            for (int i = 1; i <= AdministradorMesa.maximoMesas; i++)
            {
                var et = this.Controls.Find($"lblMesa{i}", true).FirstOrDefault() as Label;
                if (et != null && i <= valores.Count)
                {
                    et.Tag = i;
                    et.Text = valores[i - 1];
                }
            }
        }
        private void Form2_Shown(object sender, EventArgs e)
        {

        }

        private void btnOcuparMesa_Click(object sender, EventArgs e)
        {
            admin.OcuparMesa((int)nudMesa.Value);
            ActualizarEtiquetas();
        }

        private void btnDesocuparMesa_Click(object sender, EventArgs e)
        {
            admin.DesocuparMesa(((int)nudMesa.Value));
            ActualizarEtiquetas();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
