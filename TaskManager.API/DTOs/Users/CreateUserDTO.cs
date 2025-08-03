using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs.Users
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
