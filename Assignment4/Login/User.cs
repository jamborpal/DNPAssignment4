﻿﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Assignment2.Login
{
    public class User
    {
        [Key,MaxLength(200)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}