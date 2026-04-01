using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PDS_U4_Examen.Bases
{
    public abstract class FabricaAlimento
    {
        public abstract Alimento CrearAlimento();
    }
    public class FabricaAgua : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));

            return new Agua(ingredientes);
        }
    }
    public class FabricaCarneAsada : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Filete", 200));
            ingredientes.Add(new IngredienteAlimento("Cebollín", 4));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 12));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 4));
            ingredientes.Add(new IngredienteAlimento("Tomate", 5));
            ingredientes.Add(new IngredienteAlimento("Frijol", 50));
            ingredientes.Add(new IngredienteAlimento("Nopal", 20));
            ingredientes.Add(new IngredienteAlimento("Lima", 5));

            return new CarneAsada(ingredientes);
        }
    }
    public class FabricaEnchiladas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Pollo", 300));
            ingredientes.Add(new IngredienteAlimento("Crema", 15));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 10));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 8));
            ingredientes.Add(new IngredienteAlimento("Queso", 50));
            ingredientes.Add(new IngredienteAlimento("Salsa roja", 175));
            ingredientes.Add(new IngredienteAlimento("Masa", 120));
            return new Enchiladas(ingredientes);
        }
    }
    public class FabricaFlautas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Pollo", 140));
            ingredientes.Add(new IngredienteAlimento("Crema", 20));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 9));
            ingredientes.Add(new IngredienteAlimento("Tomate", 6));
            ingredientes.Add(new IngredienteAlimento("Queso", 30));
            ingredientes.Add(new IngredienteAlimento("Salsa verde", 125));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 5));
            ingredientes.Add(new IngredienteAlimento("Masa", 150));
            return new Flautas(ingredientes);
        }
    }
    public class FabricaHorchata : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));
            ingredientes.Add(new IngredienteAlimento("Arroz", 50));
            ingredientes.Add(new IngredienteAlimento("Canela", 10));
            ingredientes.Add(new IngredienteAlimento("Azúcar", 20));
            ingredientes.Add(new IngredienteAlimento("Hielo", 85));

            return new Horchata(ingredientes);
        }
    }
    public class FabricaJamaica : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));
            ingredientes.Add(new IngredienteAlimento("Flor de Jamaica", 3));
            ingredientes.Add(new IngredienteAlimento("Azúcar", 20));
            ingredientes.Add(new IngredienteAlimento("Hielo", 85));

            return new Jamaica(ingredientes);
        }
    }
    public class FabricaLimonada : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Agua", 650));
            ingredientes.Add(new IngredienteAlimento("Limón", 2));
            ingredientes.Add(new IngredienteAlimento("Azúcar", 20));
            ingredientes.Add(new IngredienteAlimento("Hielo", 85));

            return new Limonada(ingredientes);
        }
    }
    public class FabricaRefresco : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Latas de refresco", 1));

            return new Refresco(ingredientes);
        }
    }
    public class FabricaSopes : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Masa", 120));
            ingredientes.Add(new IngredienteAlimento("Frijol", 100));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 12));
            ingredientes.Add(new IngredienteAlimento("Queso", 85));
            ingredientes.Add(new IngredienteAlimento("Cebolla blanca", 10));
            ingredientes.Add(new IngredienteAlimento("Salsa de tomate", 100));

            return new Sopes(ingredientes);
        }
    }
    public class FabricaTostadas : FabricaAlimento
    {
        public override Alimento CrearAlimento()
        {
            List<IngredienteAlimento> ingredientes = new List<IngredienteAlimento>();
            ingredientes.Add(new IngredienteAlimento("Tostadas", 3));
            ingredientes.Add(new IngredienteAlimento("Frijol", 120));
            ingredientes.Add(new IngredienteAlimento("Res", 150));
            ingredientes.Add(new IngredienteAlimento("Salsa de tomate", 85));
            ingredientes.Add(new IngredienteAlimento("Cebolla morada", 10));
            ingredientes.Add(new IngredienteAlimento("Lechuga", 8));
            ingredientes.Add(new IngredienteAlimento("Crema", 25));
            ingredientes.Add(new IngredienteAlimento("Aguacate", 6));

            return new Tostadas(ingredientes);
        }
    }
}
