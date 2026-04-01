using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class Inventario
    {
        private static Inventario _instance;
        private static readonly object _lock = new object();
        public List<Ingrediente> Ingredientes { get; private set; }
        private Inventario()
        {
            // Los ingredientes se rellenan al iniciar el programa
            Ingredientes = new List<Ingrediente>();
            // Medido en gramos
            Ingredientes.Add(new Ingrediente("Masa", 3000, 500));
            Ingredientes.Add(new Ingrediente("Pollo", 10000, 2500));
            Ingredientes.Add(new Ingrediente("Res", 10000, 2500));
            Ingredientes.Add(new Ingrediente("Filete", 10000, 3000));
            Ingredientes.Add(new Ingrediente("Frijol", 8000, 2500));
            Ingredientes.Add(new Ingrediente("Hielo", 2000, 500));
            Ingredientes.Add(new Ingrediente("Azúcar", 3000, 800));
            Ingredientes.Add(new Ingrediente("Queso", 2000, 500));
            Ingredientes.Add(new Ingrediente("Canela", 3000, 1000));
            Ingredientes.Add(new Ingrediente("Arroz", 6000, 1200));
            // Medido en mililitros
            Ingredientes.Add(new Ingrediente("Agua", 10000, 4000));
            Ingredientes.Add(new Ingrediente("Crema", 5000, 1000));
            Ingredientes.Add(new Ingrediente("Salsa roja", 4000, 800));
            Ingredientes.Add(new Ingrediente("Salsa verde", 4000, 800));
            Ingredientes.Add(new Ingrediente("Salsa de tomate", 4000, 800));
            // Medido en rebanadas/gajos
            Ingredientes.Add(new Ingrediente("Cebolla blanca", 300, 60));
            Ingredientes.Add(new Ingrediente("Cebolla morada", 300, 60));
            Ingredientes.Add(new Ingrediente("Lechuga", 500, 200));
            Ingredientes.Add(new Ingrediente("Tomate", 500, 200));
            Ingredientes.Add(new Ingrediente("Aguacate", 300, 100));
            Ingredientes.Add(new Ingrediente("Nopal", 600, 320));
            Ingredientes.Add(new Ingrediente("Lima", 250, 100));
            // Medido en unidades enteras
            Ingredientes.Add(new Ingrediente("Limón", 750, 250));
            Ingredientes.Add(new Ingrediente("Cebollín", 500, 200));
            Ingredientes.Add(new Ingrediente("Flor de Jamaica", 800, 500));
            Ingredientes.Add(new Ingrediente("Latas de refresco", 75, 30));
            Ingredientes.Add(new Ingrediente("Tostadas", 240, 48));
        }

        public static Inventario ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Inventario();
                    }
                }
            }
            return _instance;
        }

        // Uso de ingredientes
        // Asume que ya se verificó previamente que se pueden usar
        public void UtilizarIngredientes(Dictionary<Alimento, int> ordenPorPedir)
        {
            // Se calculan los ingredientes necesarios
            Dictionary<string, int> ingredientesTotales = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var par in ordenPorPedir)
            {
                Alimento alimento = par.Key;
                int cantidad = par.Value;

                foreach (var ingredienteAli in alimento.Ingredientes)
                {
                    int cantidadNecesaria = ingredienteAli.CantidadNecesaria * cantidad;

                    if (ingredientesTotales.ContainsKey(ingredienteAli.Nombre))
                    {
                        ingredientesTotales[ingredienteAli.Nombre] += cantidadNecesaria;
                    }
                    else
                    {
                        ingredientesTotales[ingredienteAli.Nombre] = cantidadNecesaria;
                    }
                }
            }

            // Se descuentan los ingredientes
            foreach (var par in ingredientesTotales)
            {
                var ingredienteInv = Ingredientes.First(i =>
                    i.Nombre.Equals(par.Key, StringComparison.OrdinalIgnoreCase));

                ingredienteInv.Utilizar(par.Value);
            }
        }

        // Se devuelve una lista conteniendo qué ingredientes faltan, o una lista vacía
        public List<string> ObtenerErrores(Alimento alimento, int cantidadPedida)
        {
            List<string> ingredientesFaltantes = new List<string>();

            foreach (var ingredienteAli in alimento.Ingredientes)
            {
                var ingredienteInv = Ingredientes.FirstOrDefault(i =>
                    i.Nombre.Equals(ingredienteAli.Nombre, StringComparison.OrdinalIgnoreCase));

                // Se aprovecha que se envía la cantidad de veces que se ordenó un alimento para verificar todo de golpe
                int cantidadNecesaria = ingredienteAli.CantidadNecesaria * cantidadPedida;

                // Si el alimento no existe, o no se tiene la cantidad necesaria, se añade a la lista de errores
                if (ingredienteInv == null)
                {
                    ingredientesFaltantes.Add($"- El ingrediente {ingredienteAli.Nombre} no se encuentra en el inventario.");
                }
                else if (ingredienteInv.Cantidad < cantidadNecesaria)
                {
                    ingredientesFaltantes.Add($"- La cantidad de {ingredienteInv.Nombre} es insuficiente.");
                    ingredientesFaltantes.Add($"Necesario: {cantidadNecesaria} (para {cantidadPedida} " +
                        $"{alimento.Nombre}), Disponible: {ingredienteInv.Cantidad}");
                }
            }

            return ingredientesFaltantes;
        }

        // Ordena más de los componentes debajo del punto de orden
        public void ReponerInventario()
        {
            foreach (var ingrediente in Ingredientes)
            {
                if (ingrediente.Cantidad <= ingrediente.PuntoDeOrden)
                {
                    Console.WriteLine($"Se ha pedido y reabastecido el siguiente ingrediente: {ingrediente.Nombre}");
                    ingrediente.Ordenar();
                    Thread.Sleep(100);
                }
            }
        }
    }
}