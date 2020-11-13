using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public User Sender { get; set; }
        public Dialog Dialog { get; set; }
        [Required, MinLength(1)]
        public string Text { get; set; }
    }
}
