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
    public partial class Form5 : Form
    {
        // Formulario para ver el inventario

        Inventario inventario;
        public Form5()
        {
            InitializeComponent();
        }

        private void lvwInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        // Se vuelve a llenar el ListView que contiene los componentes del inventario
        private void Cargar()
        {
            inventario = Inventario.ObtenerInstancia();
            lvwInventario.Items.Clear();

            foreach (var ingrediente in inventario.Ingredientes)
            {
                string estado = ingrediente.Cantidad <= ingrediente.PuntoDeOrden ? "Necesita reabastecerse" : "Hay suficiente";

                ListViewItem obj = new ListViewItem(ingrediente.Nombre);
                obj.SubItems.Add(ingrediente.Cantidad.ToString());
                obj.SubItems.Add(ingrediente.CantidadMaxima.ToString());
                obj.SubItems.Add(estado);

                lvwInventario.Items.Add(obj);
                lvwInventario.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReabastecer_Click(object sender, EventArgs e)
        {
            inventario.ReponerInventario();
            Cargar();
        }
    }
}
