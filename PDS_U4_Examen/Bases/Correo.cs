using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace PDS_U4_Examen.Bases
{
    public class Correo
    {
        private string _rem;
        private string _con;
        private string _des;
        public Correo()
        {
            // Información para el envío por correo
            _rem = "pdsdummyaddress@gmail.com";
            // Contraseña de aplicaciones
            _con = "rboo zjxh qnnd qsfa";
            // Destinatario fijo para demostrar envío exitoso
            _des = "l21212581@tectijuana.edu.mx";
        }
        public void EnviarCorreoAdjunto(List<string> rutas)
        {
            try
            {
                MailMessage mensaje = new MailMessage(_rem, _des);
                mensaje.Subject = "Recibo generado";
                mensaje.Body = "Este correo contiene un recibo creado sobre un aporte determinado";

                // Todos los archivos creados se añaden al correo
                foreach (string ruta in rutas)
                {
                    if (File.Exists(ruta))
                    {
                        mensaje.Attachments.Add(new Attachment(ruta));
                    }
                }

                // Configuración del SMTP
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);

                cliente.EnableSsl = true;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential(_rem, _con);
                cliente.Timeout = 30000;

                cliente.Send(mensaje);

                MessageBox.Show("Correo enviado");

                // Finaliza la conexión de TCP y elimina los recursos ocupados para creal el correo
                mensaje.Dispose();
                cliente.Dispose();
            }
            catch (Exception e)
            {
                // Error a desplegar en caso de alguna falla
                MessageBox.Show($"{e.Message}", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
        }
    }
}
