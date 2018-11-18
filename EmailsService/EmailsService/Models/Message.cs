using System;
namespace EmailsService.Models
{
    public class Message
    {
        public DateTime Date { get; set; }
        public int UserSenderId { get; set; }
        public int UserReceiverId { get; set; }
        public String Text { get; set; }
        public int IdChat { get; set; }

    }
}
