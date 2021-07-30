using System.Collections.Generic;
using MessagingApp.Models;

namespace MessagingApp.Services
{
    public interface IDataStorage
    {
        void InsertData(MessageBody receiveMessage);
        List<MessageBody> GetData();
    }
}