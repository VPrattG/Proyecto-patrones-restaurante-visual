using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class Ingrediente
    {
        private string _nombre;
        private int _cantidad;
        private int _cantidadMaxima;
        private int _puntoDeOrden;
        public Ingrediente(string nom, int cant, int min)
        {
            _nombre = nom;
            _cantidad = cant;
            _cantidadMaxima = cant;
            _puntoDeOrden = min;
        }
        public string Nombre
        {
            get { return _nombre; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
        }
        public int CantidadMaxima
        {
            get { return _cantidadMaxima; }
        }
        public int PuntoDeOrden
        {
            get { return _puntoDeOrden; }
        }
        public void Ordenar()
        {
            _cantidad = _cantidadMaxima;
        }
        
        // Función para reducir la cantidad total del ingrediente
        public void Utilizar(int total)
        {
            _cantidad -= total;

            if (_cantidad <= _puntoDeOrden)
            {
                Console.WriteLine($"- Se recomienda ordenar más {_nombre}.");
            }
        }
    }
}
