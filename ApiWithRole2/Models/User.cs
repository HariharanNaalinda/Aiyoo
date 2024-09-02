using System.ComponentModel.DataAnnotations;

namespace ApiWithRole2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string UserType { get; set; } // Admin/User

        [Required]
        public string PasswordHash { get; set; }
    }
}
