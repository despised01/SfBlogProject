using System.Collections.Generic;
using System.Data;
using System;

namespace BlogApp.BlogAppLib.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        // Статьи потльзователя
        public List<Post> Posts { get; set; } = new List<Post>();

        // комментарии пользователя
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Привязываю роли многие ко многим
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
