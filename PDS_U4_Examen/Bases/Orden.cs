using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class Orden
    {
        private List<Alimento> _listaPlatillos;
        private List<Alimento> _listaBebidas;
        private decimal _propina; // Se usa decimal por su mayor precisión
        private int _numMesa;
        public Orden()
        {
            _listaPlatillos = new List<Alimento>();
            _listaBebidas = new List<Alimento>();
            _numMesa = 1;
        }
        public List<Alimento> ListaPlatillos
        {
            get
            {
                return _listaPlatillos;
            }
        }
        public List<Alimento> ListaBebidas
        {
            get
            {
                return _listaBebidas;
            }
        }
        public decimal Propina
        {
            get
            {
                return _propina;
            }
        }
        public int NumMesa
        {
            get
            {
                return _numMesa;
            }
        }
        public void IndicarMesa(int numMesa)
        {
            _numMesa = numMesa;
        }
        
        public void AgregarPlatillo(Alimento alimento)
        {
            _listaPlatillos.Add(alimento);
            _propina += Decimal.Round((decimal)alimento.Precio * (decimal)0.1, 2);
        }
        public void AgregarBebida(Alimento alimento)
        {
            _listaBebidas.Add(alimento);
            _propina += Decimal.Round((decimal)alimento.Precio * (decimal)0.1, 2);
        }

        // Mostrar información de la orden
        public string DesplegarOrden(List<Alimento> lista)
        {
            StringBuilder sb = new StringBuilder();
            if (lista.Count > 0)
            {
                var agrupados = lista.GroupBy(a => a.Nombre);
                
                foreach(var grupo in agrupados)
                {
                    int cantidad = grupo.Count();
                    double precioIndv = grupo.First().Precio;
                    double precioTot = precioIndv * cantidad;

                    sb.AppendLine($"    {grupo.Key} x {cantidad} -> ${precioTot}");
                }
            }
            else
            {
                sb.AppendLine("    (Ninguno)");
            }
            return sb.ToString();
        }
    }
}
