using System.ComponentModel.DataAnnotations;

namespace MVCCoreProject2.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string Username { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Role { get; set; } = "user";
        public string? ProfileImageFileName { get; set; } = "Unknown_person.jpg";
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(6, ErrorMessage = "Username must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Username must be maximum 16 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked {get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Password must be maximum 16 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re-Password is required.")]
        [MinLength(6, ErrorMessage = "Re-Password must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Re-Password must be maximum 16 characters")]
        [Compare(nameof(Password), ErrorMessage = "Passwords does not match")]
        public string RePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }

    public class EditUserModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(6, ErrorMessage = "Username must be minimum 6 characters")]
        [MaxLength(16, ErrorMessage = "Username must be maximum 16 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }
}
