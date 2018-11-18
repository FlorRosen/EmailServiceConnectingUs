using System;
using System.Net.Mail;
using EmailsService.Models;

namespace EmailsService
{
    public class EmailsService
    {
        public static void SendEmailViaWebApi(EmailViewModel email)
        {
            string subject = "[Connecting-Us] " + email.SubjectText;
            string body = "Hey " + email.UserSenderMail + "!\n" + email.BodyText;
            string fromMail = "connecting.us2018@gmail.com";
            string emailTo = email.UserReceiverMail;

            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;

            // var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("connecting.us2018@gmail.com", "Ort123456");
            smtpServer.EnableSsl = true;
            //smtpServer.UseDefaultCredentials = true;
            smtpServer.Send(mail);



        }
    }
}
