using System;
using System.Net.Mail;
using System.Web.Http;
using EmailsService.Models;

namespace EmailsService
{
    public class EmailsController: ApiController
    {
        [Route("api/chats/messages")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Message message)
        {
            
            EmailViewModel email = new EmailViewModel();
            email.SubjectText = "New Message";
            email.BodyText = "You have received a new message! Go check ConnectingUs right now!";
            //email.ServiceTitle = chatsRepository.GetChat(message.IdChat).Service.Title;
            email.UserSenderMail = "flopirosental@hotmail.com";
            email.UserReceiverMail = "flopirosental@hotmail.com";
            
            try
            {
                EmailsService.SendEmailViaWebApi(email);
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw new SmtpFailedRecipientException("Failed while sending the email");
            }

            return (IHttpActionResult)Ok();

        }
    }
}
