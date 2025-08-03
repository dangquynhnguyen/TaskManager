using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TaskManager.API.Data;
using TaskManager.API.DTOs.Users;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(CreateUserDTO dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("Email already exists");

        var user = _mapper.Map<User>(dto);
        user.PasswordHash = HashPassword(dto.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, _mapper.Map<UserDTO>(user));
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        return Convert.ToBase64String(sha.ComputeHash(bytes));
    }
}

