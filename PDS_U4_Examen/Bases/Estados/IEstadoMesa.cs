using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases.Estados
{
    public interface IEstadoMesa
    {
        public void OcuparMesa(Mesa mesa);
        public void DesocuparMesa(Mesa mesa);
        public string ObtenerEstado();
        public bool PermiteOrdenar();
    }

    public class Ocupado : IEstadoMesa
    {
        public void OcuparMesa(Mesa mesa)
        {
            Console.WriteLine($"La mesa {mesa.Numero} ya se encuentra ocupada");
            MessageBox.Show($"La mesa {mesa.Numero} ya se encuentra ocupada", "Advertencia", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void DesocuparMesa(Mesa mesa)
        {
            mesa.CambiarEstado(new Sucio());
            Console.WriteLine($"La mesa {mesa.Numero} se ha desocupado y necesita limpieza.");
            MessageBox.Show($"La mesa {mesa.Numero} se ha desocupado y necesita limpieza.", "Nota",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public string ObtenerEstado()
        {
            return $"Ocupada";
        }
        public bool PermiteOrdenar()
        {
            return true;
        }
    }
    public class Desocupado : IEstadoMesa
    {
        public void OcuparMesa(Mesa mesa)
        {
            mesa.CambiarEstado(new Ocupado());
            Console.WriteLine($"La mesa {mesa.Numero} se ha ocupado");
            MessageBox.Show($"La mesa {mesa.Numero} se ha ocupado.", "Perfecto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void DesocuparMesa(Mesa mesa)
        {
            Console.WriteLine($"La mesa {mesa.Numero} se ha ocupado");
            MessageBox.Show($"La mesa {mesa.Numero} ya se encuentra desocupada", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public string ObtenerEstado()
        {
            return $"Desocupada";
        }
        public bool PermiteOrdenar()
        {
            return false;
        }
    }
    public class Sucio : IEstadoMesa
    {
        public void OcuparMesa(Mesa mesa)
        {
            mesa.CambiarEstado(new Desocupado());
            Console.WriteLine($"La mesa {mesa.Numero} está sucia.");
            Console.WriteLine("La mesa se ha limpiado");
            MessageBox.Show($"La mesa {mesa.Numero} estaba sucia y se ha limpiado.", "Nota",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void DesocuparMesa(Mesa mesa)
        {
            mesa.CambiarEstado(new Desocupado());
            Console.WriteLine($"La mesa {mesa.Numero} necesita limpiarse antes de uso.");
            Console.WriteLine("La mesa se ha limpiado");
            MessageBox.Show($"La mesa {mesa.Numero} estaba sucia y se ha limpiado.", "Nota",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public string ObtenerEstado()
        {
            return $"En necesidad de limpieza";
        }
        public bool PermiteOrdenar()
        {
            return false;
        }
    }
}
