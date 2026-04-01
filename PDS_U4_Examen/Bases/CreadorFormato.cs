using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public abstract class CreadorFormato
    {
        protected List<string> _reporte;
        protected StringWriter _stringWriter;

        public CreadorFormato()
        {
            _reporte = new List<string>();
            _stringWriter = new StringWriter();
        }
        
        public List<string> Reporte
        {
            get { return _reporte; }
        }

        public void Reiniciar()
        {
            _reporte.Clear();
        }
        
        public abstract void AgregarLinea(string linea);

        public abstract List<string> CrearFormato(string ruta);
    }
}
