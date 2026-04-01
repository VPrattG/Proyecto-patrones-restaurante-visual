using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System.Xml;

namespace PDS_U4_Examen.Bases
{
    public class FormatoDecorador : CreadorFormato
    {
        // Base para implementar el patrón decorador
        protected CreadorFormato _creadorFormato;
        public FormatoDecorador(CreadorFormato creadorFormato)
        {
            _creadorFormato = creadorFormato;
            foreach (string linea in _creadorFormato.Reporte)
            {
                _reporte.Add(linea);
            }
        }
        public override void AgregarLinea(string linea)
        {
            _creadorFormato.AgregarLinea(linea);
            _reporte.Add(linea);
        }
        public override List<string> CrearFormato(string ruta)
        {
            return _creadorFormato.CrearFormato(ruta);
        }
    }

    // Archivo que siempre se creará al "finalizar el día"
    public class TXT : CreadorFormato
    {
        public override void AgregarLinea(string linea)
        {
            _reporte.Add(linea);
        }
        public override List<string> CrearFormato(string rutaBase)
        {
            Console.WriteLine("Generando TXT...");

            // Función para compatibilidad
            // Se toman las direcciones anteriores aunque tengan extensión pdf o xml
            // y se cambia a txt
            string ruta = Path.ChangeExtension(rutaBase, ".txt");

            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (string linea in _reporte)
                {
                    sw.WriteLine(linea);
                }
            }

            Console.WriteLine("Archivo generado exitosamente.");
            Console.WriteLine($"Archivo encontrado en {ruta}");

            // Se devuelve la lista para uso donde se llame
            return new List<string> { ruta };
        }
    }

    public class FormatoPDF : FormatoDecorador
    {
        public FormatoPDF(CreadorFormato creadorFormato) : base(creadorFormato) { }

        public override List<string> CrearFormato(string rutaBase)
        {
            // Se obtiene la ruta del decorador anterior
            // y se modifica para terminar en .pdf
            List<string> rutas = _creadorFormato.CrearFormato(rutaBase);
            string rutaPDF = Path.ChangeExtension(rutaBase, ".pdf");

            // Creación del documento pdf
            double y = 0;

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = $"Reporte de {DateTime.Now.ToString("U")}";

            PdfPage pag = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pag);
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

            foreach (string s in _reporte)
            {
                gfx.DrawString(s, font, XBrushes.Black,
                    new XRect(0, y, pag.Width + 2, pag.Height), XStringFormats.TopLeft);
                y += 12;
            }

            pdf.Save(rutaPDF);

            Console.WriteLine("Archivo PDF generado exitosamente.");
            Console.WriteLine($"Archivo encontrado en {rutaPDF}");

            // Se devuelve la lista para uso donde se llame
            return rutas.Concat(new[] { rutaPDF }).ToList();
        }
    }
    public class FormatoXML : FormatoDecorador
    {
        private string _elementoRaiz;
        private string _elementoLinea;
        public FormatoXML(CreadorFormato creadorFormato) : base(creadorFormato)
        {
            _elementoRaiz = "Reporte";
            _elementoLinea = "Línea";
        }

        public override List<string> CrearFormato(string rutaBase)
        {
            List<string> rutas = _creadorFormato.CrearFormato(rutaBase);
            
            // Se toma la ruta y modifica la extensión a xml
            string rutaXML = Path.ChangeExtension(rutaBase, ".xml");

            Console.WriteLine("Generando XML...");

            // Generación del archivo XML
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  "
            };

            using (XmlWriter writer = XmlWriter.Create(rutaXML, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(_elementoRaiz);

                writer.WriteAttributeString("FechaGeneracion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Cada línea se incorpora como elemento
                for (int i = 0; i < _reporte.Count; i++)
                {
                    writer.WriteStartElement(_elementoLinea);
                    writer.WriteAttributeString("Numero", (i + 1).ToString());
                    writer.WriteString(_reporte[i]);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("Archivo XML generado exitosamente.");
            Console.WriteLine($"Archivo encontrado en {rutaXML}");

            // Se devuelve la lista para uso donde se llame
            return rutas.Concat(new[] { rutaXML }).ToList();
        }
    }
}
