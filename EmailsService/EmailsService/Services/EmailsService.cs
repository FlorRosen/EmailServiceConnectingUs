using System;
using System.Net.Mail;
using EmailsService.Models;
using System.Net.Mime;

namespace EmailsService
{
    public class EmailsService
    {
        public static void SendEmailViaWebApi(EmailViewModel email)
        {
            try
            {
                var body = "Hey " + email.UserReceiverNickname + "! \n " + email.UserSenderNickname + " has sent you a message! Go check it out in Connecting Us web.";

                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(email.UserReceiverMail));

                // From
                mailMsg.From = new MailAddress("connecting.us2018@gmail.com", "Connecting Us");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "[Connecting-Us] New message from " + email.UserSenderNickname;
                string text = body;
                string html = body;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
