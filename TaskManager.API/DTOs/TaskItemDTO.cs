using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs;

public class TaskItemDTO
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "UserId must be > 0")]
    public int UserId { get; set; }
}
