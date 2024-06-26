﻿using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "FirstName must be at least {2}, and maximum {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "LastName must be at least {2}, and maximum {1} characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

