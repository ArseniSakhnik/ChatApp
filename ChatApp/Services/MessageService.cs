using ChatApp.Entities;
using ChatApp.Helpers;
using ChatApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Services
{

    public interface IMessageService
    {
        //bool SendMessage(int senderId, int recipientId, string text);
        //List<Message> GetLastMessages(int senderId);
        //List<Message> GetSenderAndRecipientMessages(int senderId, int recipientId);
    }

    public class MessageService : IMessageService
    {
        private DataContext _context;
        public MessageService(DataContext context)
        {
            _context = context;
        }

        public bool SendMessage(string senderId, string dialogId, string text)
        {
            int? userId;
            int? userDialogId;

            try
            {
                userId = Int32.Parse(senderId);
                userDialogId = Int32.Parse(dialogId);
            }
            catch (Exception ex)
            {
                return false;
            }

            var dialog = _context.Dialogs.Where(d => d.Id == userDialogId).Include(d => d.UserDialog).ThenInclude(ud => ud.User).SingleOrDefault();

            if (dialog == null)
            {
                return false;
            }

            var user = (from u in dialog.UserDialog where u.UserId == userId select u.User).SingleOrDefault();

            if (user == null)
            {
                return false;
            }

            _context.Messages.Add(new Message
            {
                Sender = user,
                Dialog = dialog,
                Text = text
            });

            _context.SaveChanges();

            return true;

        }

        publi

    }
}
