
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ElencoController : ControllerBase
{

    private CartazContext _context;
    private IMapper _mapper;
   
    private List<Filme> _filmes;
    private List<Ator> ators;
    


    public ElencoController(CartazContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdiconarElenco([FromBody] CreatElencoDto atorDto)
    {
        var elenco = _mapper.Map<Elenco>(atorDto);
        _context.Elenco.Add(elenco);
        _context.SaveChanges();
         return Ok();
    }

    [HttpGet]
    public IEnumerable<Elenco> RecuperaElenco([FromQuery] int skip = 0,
      [FromQuery] int take = 50)
    {
        return _context.Elenco.Skip(skip).Take(take);

    }


  

    [HttpGet("{Titulo}")]
    public ActionResult<ElencoDto> GetFilme(string Titulo)
    {
        var filme = _context.Filmes.Where(f => f.Titulo.Equals(Titulo)).FirstOrDefault();

        if (filme == null)
        {
            return NotFound();
        }

        var elenco = _context.Elenco.Where(e => e.FilmeId == filme.Id).ToList();

        if (elenco.Count == 0)
        {
            return NotFound();
        }

        //var atores = new List<Ator>();

        //foreach (var e in elenco)
        //{
        //    var ator = _context.Atores.FirstOrDefault(ator => ator.Id.Equals(e.AtorId));
        //    atores.Add((Ator)ator);
        //};

        var atores = elenco
            .Select(e => _context.Atores.FirstOrDefault(a => a.Id.Equals(e.AtorId)))
             .ToList();

        var filmeDTO = new ElencoDto
        {
           Titulo= Titulo,
           Duracao= filme.Duracao,
           Genero=filme.Genero,
            Atores = atores
        };

        return filmeDTO;
    }







}

