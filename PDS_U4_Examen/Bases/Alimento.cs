using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public abstract class Alimento
    {
        private string _nombre;
        private double _precio;
        private List<IngredienteAlimento> _ingredientes;
        private bool _esBebida;
        public string Nombre
        {
            get { return _nombre; }
        }
        public double Precio
        {
            get { return _precio; }
        }
        public bool EsBebida
        {
            get { return _esBebida; }
        }
        public List<IngredienteAlimento> Ingredientes
        {
            get { return _ingredientes; }
        }
        public Alimento(string nombre, double precio, List<IngredienteAlimento> ingredientes, bool esBebida)
        {
            _nombre = nombre;
            _precio = precio;
            _ingredientes = ingredientes;
            _esBebida = esBebida;
        }
    }
    public class Agua : Alimento
    {
        public Agua(List<IngredienteAlimento> ingredientes) : base("Agua", 0, ingredientes, true) { }
    }
    public class CarneAsada : Alimento
    {
        public CarneAsada(List<IngredienteAlimento> ingredientes) : base("Carne Asada", 175, ingredientes, false) { }
    }
    public class Enchiladas : Alimento
    {
        public Enchiladas(List<IngredienteAlimento> ingredientes) : base("Enchiladas", 120.5, ingredientes, false) { }
    }
    public class Flautas : Alimento
    {
        public Flautas(List<IngredienteAlimento> ingredientes) : base("Flautas", 105.0, ingredientes, false) { }
    }
    public class Horchata : Alimento
    {
        public Horchata(List<IngredienteAlimento> ingredientes) : base("Horchata", 28, ingredientes, true) { }
    }
    public class Jamaica : Alimento
    {
        public Jamaica(List<IngredienteAlimento> ingredientes) : base("Agua de Jamaica", 30, ingredientes, true) { }
    }
    public class Limonada : Alimento
    {
        public Limonada(List<IngredienteAlimento> ingredientes) : base("Limonada", 27.5, ingredientes, true) { }
    }
    public class Refresco : Alimento
    {
        public Refresco(List<IngredienteAlimento> ingredientes) : base("Lata de refresco", 25, ingredientes, true) { }
    }
    public class Sopes : Alimento
    {
        public Sopes(List<IngredienteAlimento> ingredientes) : base("Sopes", 111, ingredientes, false) { }
    }
    public class Tostadas : Alimento
    {
        public Tostadas(List<IngredienteAlimento> ingredientes) : base("Tostadas", 130.2, ingredientes, false) { }
    }
}
