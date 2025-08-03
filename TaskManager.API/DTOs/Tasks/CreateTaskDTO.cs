using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs.Tasks
{
    public class CreateTaskDTO
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
