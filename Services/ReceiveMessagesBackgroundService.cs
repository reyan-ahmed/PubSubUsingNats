using System;
using System.Threading;
using System.Threading.Tasks;
using MessagingApp.Models;
using MessagingApp.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NATS.Client;

namespace MessagingApp.Services
{
    public class ReceiveMessagesBackgroundService : BackgroundService
    {
        private readonly IConfiguration _config;
        private IDataStorage _dataStorage;
        private IObjectConvertor _objectConvertor;
        public ReceiveMessagesBackgroundService(IDataStorage dataStorage, IObjectConvertor objectConvertor, IConfiguration config)
        {
            _config = config;
            _objectConvertor = objectConvertor;
            _dataStorage = dataStorage;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    ConnectionFactory cf = new ConnectionFactory();
                    IConnection c = cf.CreateConnection();
                    EventHandler<MsgHandlerEventArgs> h = (sender, args) =>
                        {
                            _dataStorage.InsertData(_objectConvertor.deserializeFromXML(args.Message.Data) as MessageBody);
                        };
                    IAsyncSubscription sAsync = c.SubscribeAsync(_config["Subject"].ToString());


                    sAsync.MessageHandler += h;
                    sAsync.Start();
                    await Task.Delay(1000, stoppingToken);
                    sAsync.Unsubscribe();
                }
                catch (OperationCanceledException)
                {

                }

            }
        }
    }
}