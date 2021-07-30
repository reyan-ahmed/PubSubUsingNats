using System.Collections.Generic;
using MessagingApp.Models;

namespace MessagingApp.Services
{
    public class DataStorage : IDataStorage
    {
        public static List<MessageBody> listOfReceiveMessages;
        public DataStorage()
        {
            listOfReceiveMessages = new List<MessageBody>();
        }
        public List<MessageBody> GetData()
        {
            return listOfReceiveMessages;
        }

        public void InsertData(MessageBody receiveMessage)
        {
            listOfReceiveMessages.Add(receiveMessage);
        }
    }
}