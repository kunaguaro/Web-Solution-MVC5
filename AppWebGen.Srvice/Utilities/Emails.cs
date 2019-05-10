using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AppWebGen.Service.Utilities
{
    public class Emails
    {
        public void SendEmail(string bodyHtml, string emailTo, string emailFrom, string passwordFrom, int port, string host )
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(emailTo));
            email.From = new MailAddress(emailFrom);
            email.Subject = "Asunto Errores Actualizacion Tasa  " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss");
            email.Body = bodyHtml;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;


            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(emailFrom, passwordFrom);
            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            Console.WriteLine(output);
        }
    }
}
