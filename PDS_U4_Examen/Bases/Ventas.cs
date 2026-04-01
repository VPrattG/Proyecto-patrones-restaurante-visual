using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public enum Area
    {
        Meseros,
        Cocina,
        Bebidas
    }
    public class Ventas
    {
        private static Ventas _instance;
        private static readonly object _lock = new object();
        
        private Inventario _inventario;

        List<Orden> ordenes;
        List<Area> areasDePropina;
        static Random rng;

        private Ventas()
        {
            ordenes = new List<Orden>();
            areasDePropina = new List<Area>();
            rng = new Random();
            _inventario = Inventario.ObtenerInstancia();
        }
        
        // La clase se volvió un Singleton por las múltiples pantallas
        public static Ventas ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Ventas();
                    }
                }
            }
            return _instance;
        }
        
        // Agregar una orden a la lista
        public void AgregarVenta(Orden orden)
        {
            ordenes.Add(orden);
            areasDePropina.Add(ValorAleatorio<Area>());
        }

        public bool OrdenEsValida(Dictionary<Alimento, int> ordenPorPedir)
        {
            List<string> errores = new List<string>();

            // Cada alimento pasa por este proceso, usando su cantidad total
            foreach (var par in ordenPorPedir)
            {
                Alimento alimento = par.Key;
                int cantidad = par.Value;

                // Se busca la presencia de errores
                List<string> erroresAli = _inventario.ObtenerErrores(alimento, cantidad);

                if (erroresAli.Any())
                {
                    errores.Add($"Problemas con {alimento.Nombre} (cantidad: {cantidad})\n");
                    errores.AddRange(erroresAli);
                    errores.Add("");
                }
            }

            if (errores.Any())
            {
                string advertencia = string.Join("\n", errores);
                MessageBox.Show(advertencia, "Problemas al realizar la orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Desplegar ventas, pero no nececsariamente en pantalla
        public string MostrarVentas()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ordenes.Count; i++)
            {
                sb.AppendLine($"Orden {i + 1}:");
                sb.AppendLine($"  Pedido por mesa {ordenes[i].NumMesa}");
                sb.AppendLine("   Platillos:");
                sb.AppendLine(ordenes[i].DesplegarOrden(ordenes[i].ListaPlatillos));
                sb.AppendLine("   Bebidas:");
                sb.AppendLine(ordenes[i].DesplegarOrden(ordenes[i].ListaBebidas));
                sb.AppendLine($"\tPropina de ${ordenes[i].Propina} para el Área de {areasDePropina[i]}");
                sb.AppendLine(new string('-', 50));
            }
            return sb.ToString();
        }
        
        // Reiniciar el inventario de ventas
        public void Reiniciar()
        {
            ordenes.Clear();
            areasDePropina.Clear();
        }
        
        // La selección del área de propina es aleatoria
        public static T ValorAleatorio<T>() where T : Enum
        {
            var valores = Enum.GetValues(typeof(T));
            return (T)valores.GetValue(rng.Next(valores.Length));
        }
    }
}
