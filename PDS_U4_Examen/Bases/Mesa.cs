using PDS_U4_Examen.Bases.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class Mesa
    {
        private int _numero;
        private IEstadoMesa _estado;

        public int Numero
        {
            get { return _numero; }
        }
        public IEstadoMesa Estado
        {
            get
            {
                return _estado;
            }
        }
        public Mesa(int num)
        {
            _numero = num;
            _estado = new Desocupado();
        }
        public void CambiarEstado(IEstadoMesa estado)
        {
            _estado = estado;
        }
        public void OcuparMesa()
        {
            _estado.OcuparMesa(this);
        }
        public void DesocuparMesa()
        {
            _estado.DesocuparMesa(this);
        }
        public string DesplegarInfo()
        {
            return $"Mesa {_numero}: {_estado.ObtenerEstado()}";
        }
    }
}
