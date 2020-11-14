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
        List<Dialog> GetDialogs(string username);
    }

    public class MessageService : IMessageService
    {
        private DataContext _context;
        public MessageService(DataContext context)
        {
            _context = context;
        }

        public List<Dialog> GetDialogs(string username)
        {
            var user = _context.Users.Where(u => u.Username == username).Include(u => u.UserDialog).ThenInclude(ud => ud.Dialog).SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            return user.UserDialog.Select(ud => ud.Dialog).ToList();
        }

    }
}
