using PDS_U4_Examen.Bases;
using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        // Formulario para realizar órdenes

        private Dictionary<Alimento, int> ordenPorPedir;
        private List<NumericUpDown> nuds;
        private FabricaAlimento _fab;
        private List<Alimento> _etiquetas;
        private Orden _orden;
        private Ventas _ventas;
        private AdministradorMesa _admin;
        private Inventario _inventario;

        Form4 formularioHistorial;

        public Form3()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Form3_Shown(object sender, EventArgs e)
        {

        }

        // Cargar la información necesaria
        private void Cargar()
        {
            _orden = new Orden();
            ordenPorPedir = new Dictionary<Alimento, int>();
            nuds = new List<NumericUpDown>();
            _etiquetas = new List<Alimento>();
            _admin = AdministradorMesa.ObtenerInstancia();
            _inventario = Inventario.ObtenerInstancia();

            nudNumMesa.Minimum = 1;
            nudNumMesa.Maximum = AdministradorMesa.maximoMesas;

            _ventas = Ventas.ObtenerInstancia();

            ObtenerNuds("Comida");
            ObtenerNuds("Bebida");

            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaEnchiladas()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaFlautas()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaTostadas()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaCarneAsada()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaSopes()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaLimonada()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaJamaica()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaHorchata()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaRefresco()));
            _etiquetas.Add(ManejarPlatillo(_fab = new FabricaAgua()));

            for (int i = 0; i < nuds.Count; i++)
            {
                nuds[i].ValueChanged += CambiarValor;
                nuds[i].Tag = _etiquetas[i];
            }

            ActivarBoton();
        }

        // Agregar o quitar un alimento de la orden a enviar
        private void CambiarValor(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Alimento ali = (Alimento)nud.Tag;

            int nuevaCantidad = (int)nud.Value;

            if (ordenPorPedir.ContainsKey(ali))
            {
                // Se compara la cantidad actual con la previamente guardada
                // para determinar si agregar o eliminar un producto
                int cantidadAnterior = ordenPorPedir[ali];
                int diferencia = nuevaCantidad - cantidadAnterior;

                if (diferencia > 0)
                {
                    for (int i = 0; i < diferencia; i++)
                    {
                        AgregarAOrden(ali);
                    }
                }
                else
                {
                    for (int i = 0; i < -diferencia; i++)
                    {
                        RemoverDeOrden(ali);
                    }
                }

                if (nuevaCantidad <= 0)
                {
                    ordenPorPedir.Remove(ali);
                }
                else
                {
                    ordenPorPedir[ali] = nuevaCantidad;
                }
            }
            else if (nuevaCantidad > 0)
            {
                ordenPorPedir[ali] = nuevaCantidad;
                for (int i = 0; i < nuevaCantidad; i++)
                {
                    AgregarAOrden(ali);
                }
            }
            ActivarBoton();
        }

        private void ActivarBoton()
        {
            if (ordenPorPedir.Count > 0)
            {
                btnOrdenar.Enabled = true;
            }
            else
            {
                btnOrdenar.Enabled = false;
            }
        }

        private void ObtenerNuds(string nud)
        {
            for (int i = 1; i <= 5; i++)
            {
                var nu = this.Controls.Find($"nud{nud}{i}", true).FirstOrDefault() as NumericUpDown;
                if (nu != null)
                {
                    nuds.Add(nu);
                }
            }
        }

        // Función auxiliar para declarar los alimentos
        private Alimento ManejarPlatillo(FabricaAlimento fab)
        {
            Alimento ali = fab.CrearAlimento();
            return ali;
        }

        private void AgregarAOrden(Alimento ali)
        {
            if (ali.EsBebida)
            {
                _orden.AgregarBebida(ali);
            }
            else
            {
                _orden.AgregarPlatillo(ali);
            }
        }

        private void RemoverDeOrden(Alimento ali)
        {
            if (ali.EsBebida)
            {
                _orden.ListaBebidas.Remove(ali);
            }
            else
            {
                _orden.ListaPlatillos.Remove(ali);
            }
        }

        // Desplegar el historial de ventas
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var texto = _ventas.MostrarVentas();
            formularioHistorial = new Form4(texto);
            formularioHistorial.ShowDialog();
        }

        // Realizar la orden
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = (int)nudNumMesa.Value;

                // Se asegura que la mesa esté ocupada y no desocupada o sucia
                if (!_admin.Mesas[numero - 1].Estado.PermiteOrdenar())
                {
                    MessageBox.Show($"La mesa {numero} no se encuentra ocupada. No puede usarla para una orden.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Se manda la lista de alimentos a validar
                if (!_ventas.OrdenEsValida(ordenPorPedir))
                {
                    return;
                }

                // Finalmente, se descuentan los ingredientes y se añade la venta a la lista
                _inventario.UtilizarIngredientes(ordenPorPedir);
                _ventas.AgregarVenta(_orden);

                MessageBox.Show("Orden agregada con éxito", "Orden implementada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "¡Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudNumMesa_ValueChanged(object sender, EventArgs e)
        {
            _orden.IndicarMesa((int)nudNumMesa.Value);
        }

        private void Reiniciar()
        {
            _orden = new Orden();
            foreach (var nud in nuds)
            {
                nud.Value = 0;
            }
        }
    }
}
