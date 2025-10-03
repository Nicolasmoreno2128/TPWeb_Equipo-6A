using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public string Asunto { get; set; }
    
        public EmailService()
        {

            server = new SmtpClient();
            server.Credentials = new NetworkCredential("12f8840d7d5042", "8a2ffc51dfa85b");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host= "sandbox.smtp.mailtrap.io";
            Asunto = "Sorteo";
            

        }

        public void armarCorreo(string correo)
        {
            email = new MailMessage();
            email.From = new MailAddress("tp_web_grupo6@programacioniii.com");
            email.To.Add(correo);
            email.Subject = Asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1> Muchas gracias por participar!</h1> <br> Vamos a informar los ganadores por este medio el dia del sorteo";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
