using System.Collections.Generic;

namespace MessagingApp.Models
{
    public class MessageModel
    {
        public MessageBody Message { get; set; }
        public List<MessageBody> SendHistory { get; set; }
    }
}