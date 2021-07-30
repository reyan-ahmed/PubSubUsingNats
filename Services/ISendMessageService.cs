using System.Collections.Generic;
using MessagingApp.Models;

namespace MessagingApp.Services
{
    public interface ISendMessageService
    {
        bool SendMessage(MessageBody message);
    }
}