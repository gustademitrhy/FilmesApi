
using FilmesApi.Data;
using FilmesApi.Models;
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
    public IEnumerable<Elenco> RecuperaAtor([FromQuery] int skip = 0,
      [FromQuery] int take = 50)
    {
        return _context.Elenco.Skip(skip).Take(take);
        
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarAtorPorId(int id)
    {
        var ator = _context.Elenco.FirstOrDefault(ator => ator.FilmeId == id);
        if (ator == null) return NotFound();
        return Ok(ator);

    }


}
