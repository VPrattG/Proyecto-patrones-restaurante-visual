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
    public partial class Form6 : Form
    {
        private Ventas _ventas;
        private CreadorFormato _creadorFormato;
        private Inventario _inventario;
        private Correo _correo;

        public Form6()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Permite que la ruta del archivo sea decidia por el usuario
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Guardar reporte(s)";
            sfd.Filter = "Archivos TXT (*.txt)|*.txt";
            sfd.FileName = $"Reporte_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ruta = sfd.FileName;
                List<string> reporte = new List<string>();
                _creadorFormato = new TXT();

                // Inicio del archivo sin importar el formato
                _creadorFormato.AgregarLinea("=========================== VENTAS ===========================");
                _creadorFormato.AgregarLinea($"Fecha: {DateTime.Now.ToString("U")}");

                string ventasTexto = _ventas.MostrarVentas();

                foreach (string linea in ventasTexto.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    _creadorFormato.AgregarLinea(linea);
                }

                // En caso que un ingrediente tenga menos de lo deseado, se indica en el archivo
                foreach (var ingrediente in _inventario.Ingredientes)
                {
                    if (ingrediente.Cantidad <= ingrediente.PuntoDeOrden)
                    {
                        string mensaje = $"* Se recomienda ordenar más {ingrediente.Nombre} *";

                        _creadorFormato.AgregarLinea(mensaje);
                    }
                }

                // Implementación del patrón decorador
                if (chkXML.Checked) { _creadorFormato = new FormatoXML(_creadorFormato); }
                if (chkPDF.Checked) { _creadorFormato = new FormatoPDF(_creadorFormato); }

                List<string> rutasGeneradas = _creadorFormato.CrearFormato(ruta);
                _correo.EnviarCorreoAdjunto(rutasGeneradas);

                // "Reinicio" de la aplicación
                _creadorFormato.Reiniciar();
                _ventas.Reiniciar();
            }
        }

        private void Form6_Shown(object sender, EventArgs e)
        {
            _ventas = Ventas.ObtenerInstancia();
            _inventario = Inventario.ObtenerInstancia();
            _correo = new Correo();
        }
    }
}
