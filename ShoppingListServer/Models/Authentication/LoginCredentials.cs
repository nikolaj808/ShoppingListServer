﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingListServer.Models.Authentication
{
    public class LoginCredentials
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
