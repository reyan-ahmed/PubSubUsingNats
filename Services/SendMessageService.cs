using System;
using System.Collections.Generic;
using MessagingApp.Models;
using MessagingApp.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NATS.Client;

namespace MessagingApp.Services
{
    public class SendMessageService : ISendMessageService
    {
        public IConfiguration _config { get; }
        private readonly ILogger<SendMessageService> _logger;
        public IObjectConvertor _objectConvertor;
        private IDataStorage _dataStorage;
        public SendMessageService(ILogger<SendMessageService> logger,
        IObjectConvertor objectConvertor, IConfiguration config,
        IDataStorage dataStorage)
        {
            _logger = logger;
            _objectConvertor = objectConvertor;
            _config = config;
            _dataStorage = dataStorage;
        }

        public bool SendMessage(MessageBody message)
        {
            try
            {
                ConnectionFactory cf = new ConnectionFactory();
                IConnection c = cf.CreateConnection();
                message.Date = DateTime.Now;
                c.Publish(_config["Subject"].ToString(), _objectConvertor.serializeToXML(message));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Got some error during publishing message {ex.Message}");
            }
            return false;
        }


    }
}