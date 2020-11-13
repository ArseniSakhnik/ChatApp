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
        //private DataContext _context;

        //public MessageService(DataContext context)
        //{
        //    _context = context;
        //}

        //public bool SendMessage(int senderId, int recipientId, string text)
        //{
        //    var recipient = _context.Users.SingleOrDefault(u => u.Id == recipientId);

        //    if (recipient == null)
        //    {
        //        return false;
        //    }

        //    var sender = _context.Users.SingleOrDefault(u => u.Id == senderId);

        //    if (sender == null)
        //    {
        //        return false;
        //    }

        //    _context.Messages.Add(new Message
        //    {
        //        SenderId = senderId,
        //        RecipientId = recipientId,
        //        Text = text
        //    });

        //    _context.SaveChanges();

        //    return true;

        //}

        //public List<Message> GetLastMessages(int senderId)
        //{
        //    var userMessages = from m in _context.Messages where m.SenderId == senderId select m;

        //    var recipients = (from r in userMessages select r.RecipientId).Distinct();

        //    List<Message> lastMessages = new List<Message>();

        //    foreach (var r in recipients)
        //    {
        //        //багованная строка
        //        //var lastMessage = (from m in _context.Messages where m.RecipientId == r select m).ToList().Last();
        //        var lastMessage = from m in _context.Messages where m.RecipientId == r select m;
        //        if (lastMessage.Count() != 0)
        //        {
        //            lastMessages.Add(lastMessage.Last());
        //        }
        //    }

        //    return lastMessages;
        //}

        //public List<Message> GetSenderAndRecipientMessages(int senderId, int recipientId)
        //{
        //    return (from m in _context.Messages where m.SenderId == senderId && m.RecipientId == recipientId select m).ToList();
        //}

    }
}
