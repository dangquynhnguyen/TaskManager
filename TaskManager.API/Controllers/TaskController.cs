using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.DTOs.Tasks;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TaskController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<TaskDTO>>(tasks));
    }

    [HttpPost]
    public async Task<ActionResult<TaskDTO>> CreateTask(CreateTaskDTO dto)
    {
        if (!await _context.Users.AnyAsync(u => u.Id == dto.UserId))
            return BadRequest("Invalid user");

        var task = _mapper.Map<TaskItem>(dto);
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, _mapper.Map<TaskDTO>(task));
    }
}

