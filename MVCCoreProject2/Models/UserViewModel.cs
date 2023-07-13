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
}
