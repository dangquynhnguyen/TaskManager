using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs.Tasks;

public class TaskDTO
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "UserId must be > 0")]
    public int UserId { get; set; }
}
