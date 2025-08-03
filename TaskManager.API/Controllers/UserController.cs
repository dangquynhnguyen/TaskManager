using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.DTOs.Users;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

/// <summary>
/// Contrôleur API pour la gestion des utilisateurs.
/// Fournit des endpoints pour récupérer la liste des utilisateurs avec leurs tâches associées
/// et pour créer de nouveaux utilisateurs dans la base de données.
/// Utilise Entity Framework Core pour l'accès aux données.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetUsers() =>
        Ok(await _context.Users.Include(u => u.Tasks).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("UserName is required");

        var user = new User
        {
            Name = dto.Name 
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
    }
}
