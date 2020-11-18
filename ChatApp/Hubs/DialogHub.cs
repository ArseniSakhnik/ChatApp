using ChatApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    //[Authorize]
    public class DialogHub : Hub
    {
        private IMessageService _messageService;
        public DialogHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendDialogs(List<string> usernames)
        {
            var dialogs = _messageService.GetDialogs(Context.UserIdentifier);
            if (usernames == null)
            {
                await Clients.User(Context.UserIdentifier).SendAsync("GetDialogs", dialogs);
            }
            else
            {
                foreach (var u in usernames)
                {
                    await Clients.User(u).SendAsync("GetDialogs", dialogs);
                }
            }
        }


        public async Task SendMessage(string usernameSender, int dialogId, string text, List<string> usernames)
        {
            if (_messageService.SendMessage(usernameSender, dialogId, text))
            {
                await SendDialogs(usernames);
            }
        }
    }
}
