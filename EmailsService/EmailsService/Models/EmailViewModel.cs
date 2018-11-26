using System;
namespace EmailsService.Models
{
    public class EmailViewModel
    {
        public string UserSenderNickname { get; set; }
        public string UserReceiverNickname { get; set; }
        public string UserReceiverMail { get; set; }
    }
}
