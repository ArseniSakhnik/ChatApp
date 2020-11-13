﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Entities
{
    public class Dialog
    {
        [Key]
        public int Id { get; set; }
        public List<Message> Messages { get; set; }
        public List<UserDialog> UserDialog { get; set; }

    }
}