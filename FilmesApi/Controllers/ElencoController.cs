
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


    [HttpGet("/BuscaElencoDoFilme/{Titulo}")]
    public  ActionResult<ElencoFilmeDto> BuscaElencoDoFilme(string Titulo)
    {
        var filme =  _context.Filmes.Where(f => f.Titulo.Equals(Titulo)).FirstOrDefault();
        if (filme == null)
        {
            throw new Exception("Filme  do ID não foi encontrado.!!");
        }


        var elenco = _context.Elenco.Where(e => e.FilmeId == filme.Id).ToList();
        if (elenco.Count == 0)
        {
            throw new Exception("Elenco desse Filme não foi encontrado.!!");
        }




        var atores = new List<Ator>();
        foreach (var e in elenco)
        {
            var ator = _context.Atores.FirstOrDefault(ator => ator.Id.Equals(e.AtorId));
            atores.Add((Ator)ator);
        };



        var filmeDTO = new ElencoFilmeDto
        {
            Titulo = Titulo,
            Duracao = filme.Duracao,
            Genero = filme.Genero,
            Atores = atores
        };

        return filmeDTO;
    }


    [HttpGet("/BuscaAtorDoFilme/{Nome}")]

    public ActionResult<ElencoAtorDto> BuscaAtorDoFilme(string Nome)
    {
        var ator = _context.Atores.Where(a => a.Nome.Equals(Nome)).FirstOrDefault();
        if (ator == null)
        {
            throw new Exception("Ator  do ID não foi encontrado.!!");
        }

        var elenco = _context.Elenco.Where(e => e.AtorId == ator.Id).ToList();
        if (elenco.Count == 0)
        {
            throw new Exception("ID do Elenco  não foi encontrado.!!");
        }


        var filmes = elenco
            .Select(e => _context.Filmes.FirstOrDefault(f => f.Id.Equals(e.FilmeId)))
            .ToList();
        


        var atorDto = new ElencoAtorDto
        {
            Nome = Nome,
            Idade = ator.Idade,
            filmesFeito = ator.filmesFeito,
            Filmes = filmes
        };

        return atorDto;
    }







}

