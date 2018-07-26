using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsSerivce
{
    public class Mailer
    {
        public static void SendMail(Exception e)
        {
            var fromAddress = new MailAddress("bntest96@gmail.com", "Sender");
            var toAddress = new MailAddress("bntest96@gmail.com", "Receiver");


            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Windows Service Error";
            mail.Body = $"Source: {e.Source}\n" +
                        $"Message: {e.Message}\n" +
                        $"Stacktrace: {e.StackTrace}"; ;
            client.Send(mail);
            
        }
    }
}
