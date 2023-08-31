﻿using System.Collections.Generic;
using System;

namespace BlogApp.BlogAppLib.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        // Привязываю пользователей многие ко многим
        public List<User> Users { get; set; } = new List<User>();
    }
}
