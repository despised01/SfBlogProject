﻿using System;

namespace BlogApp.BlogAppBll.RequestModels
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public DateTime Birthday { get; set; }
        public RoleReqest Role { get; set; }
    }
}
