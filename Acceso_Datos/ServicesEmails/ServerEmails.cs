using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
namespace Acceso_Datos.ServicesEmails
{
    public abstract class ServerEmails
    {
        private SmtpClient smtclient;
        protected string senderEmail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        protected void inicialSmtclient()
        {
            smtclient = new SmtpClient();
            smtclient.Credentials = new NetworkCredential(senderEmail, password);
            smtclient.Host = host;
            smtclient.Port = port;
            smtclient.EnableSsl = ssl;
        }

        public void sendEmail(string asunto,string body,List<string>listaCorreos)
        {
            var mensajecorreo = new MailMessage();
            try
            {
                mensajecorreo.From = new MailAddress(senderEmail);
                foreach (string mail in listaCorreos)
                {
                    mensajecorreo.To.Add(mail);
                }
                mensajecorreo.Subject = asunto;
                mensajecorreo.Body = body;
                mensajecorreo.Priority = MailPriority.Normal;
                smtclient.Send(mensajecorreo);
                
            }catch(Exception ex){}
            finally
            {
                mensajecorreo.Dispose();
                smtclient.Dispose();
            }
        }
    }
}
