using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessagingApp.Models;
using MessagingApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace MessagingApp.Controllers
{
    public class ChatController : Controller
    {
        public ISendMessageService _sendMessageService;
        private readonly ILogger<ChatController> _logger;
        public static MessageModel _messageModel; //Temporary Hold the data;
        private IDataStorage _dataStorage;
        public ChatController(ILogger<ChatController> logger, ISendMessageService sendMessageService, IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
            _logger = logger;
            _sendMessageService = sendMessageService;
        }

        [AllowAnonymous]
        public IActionResult SendMessage()
        {
            ModelState.Clear();
            return View(_messageModel);
        }

        [HttpPost]
        public ActionResult SendMessage(MessageModel messageModel)
        {
            if (_sendMessageService.SendMessage(messageModel.Message))
            {
                if (_messageModel == null)
                {
                    _messageModel = new MessageModel();
                    _messageModel.SendHistory = new List<MessageBody>();
                }
                _messageModel.SendHistory.Add(messageModel.Message);
            };
            ModelState.Clear();
            return View(_messageModel);
        }

        [HttpGet]
        public IActionResult ReceiveMessage()
        {
            List<MessageBody> listOfMessages = _dataStorage.GetData();
            return View(listOfMessages);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
