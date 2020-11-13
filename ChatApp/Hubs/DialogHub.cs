﻿using ChatApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    [Authorize]
    public class DialogHub : Hub
    {
        private IMessageService _messageService;
        public DialogHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendDialogs()
        {
            //var messages = _messageService.GetLastMessages(Int32.Parse(Context.UserIdentifier));
            //await Clients.User(Context.UserIdentifier).SendAsync("Receive", messages);
        }
    }
}