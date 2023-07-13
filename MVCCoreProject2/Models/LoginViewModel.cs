﻿using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject2.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(6, ErrorMessage = "Username must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Username must be maximum 16 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Password must be maximum 16 characters")]
        public string Password { get; set; }
    }
}
