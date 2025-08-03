using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs.Tasks;

public class TaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
