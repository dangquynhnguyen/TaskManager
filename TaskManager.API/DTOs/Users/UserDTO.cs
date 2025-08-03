using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs.Users
{
    public class UserDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
