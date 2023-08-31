﻿using System.Collections.Generic;
using System;

namespace BlogApp.BlogAppLib.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }

        // Связь с статьями
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
