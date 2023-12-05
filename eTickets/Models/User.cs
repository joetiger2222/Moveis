﻿using Microsoft.AspNetCore.Identity;

namespace eTickets.Models
{
    public class User:IdentityUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
