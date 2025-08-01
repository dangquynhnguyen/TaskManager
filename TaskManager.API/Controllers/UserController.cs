using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
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
    public async Task<IActionResult> Get() =>
        Ok(await _context.Users.Include(u => u.Tasks).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }
}
