using System;
using System.Net.Mail;
using System.Web.Http;
using EmailsService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;


namespace EmailsService
{
    public class EmailsController: ApiController
    {
        [Route("api/email")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] EmailViewModel email)
        {
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
