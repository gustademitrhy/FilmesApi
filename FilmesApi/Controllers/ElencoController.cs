
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ElencoController : ControllerBase
{

    private  CartazContext _context;

    public ElencoController(CartazContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetFilmesComAtores()
    {
        var filmesComAtores = await _context.Filmes
            .Include(f => f.ElencoFilme)
            .ThenInclude(fa => fa.Atore)
            .ToListAsync();

        return Ok(filmesComAtores);
    }

}
