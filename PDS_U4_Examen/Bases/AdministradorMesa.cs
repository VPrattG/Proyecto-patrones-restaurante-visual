using PDS_U4_Examen.Bases.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class AdministradorMesa
    {
        private static AdministradorMesa _instance;
        private static readonly object _lock = new object();

        public const int maximoMesas = 8;
        private readonly List<Mesa> _mesas;

        // Otro Singleton
        private AdministradorMesa()
        {
            _mesas = new List<Mesa>();
            for (int i = 1; i <= maximoMesas; i++)
            {
                _mesas.Add(new Mesa(i));
            }
        }

        public List<Mesa> Mesas
        {
            get
            {
                return _mesas;
            }
        }

        public static AdministradorMesa ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AdministradorMesa();
                    }
                }
            }
            return _instance;
        }
        
        // Ocupa una mesa indicada por el usuario
        public void OcuparMesa(int numMesa)
        {
            lock (_lock)
            {
                if (numMesa < 1 || numMesa > maximoMesas)
                {
                    throw new ArgumentOutOfRangeException($"El número de mesa debe estar entre 1 y {maximoMesas}.");
                }

                Mesa mesa = _mesas[numMesa - 1];

                mesa.OcuparMesa();
            }
        }

        // Desocupa una mesa
        // A diferencia de la función de ocupar, esta necesita el número específico.
        public void DesocuparMesa(int numMesa)
        {
            lock (_lock)
            {
                if (numMesa < 1 || numMesa > maximoMesas)
                {
                    throw new ArgumentOutOfRangeException($"El número de mesa debe estar entre 1 y {maximoMesas}.");
                }

                Mesa mesa = _mesas[numMesa - 1];

                mesa.DesocuparMesa();
            }
        }

        // Obtiene toda la información de todas las mesas
        public List<string> ObtenerInfoMesas()
        {
            List<string> infoMesas = new List<string>();
            foreach(var mesa in _mesas)
            {
                infoMesas.Add(mesa.DesplegarInfo());
            }
            return infoMesas;
        }
    }
}
