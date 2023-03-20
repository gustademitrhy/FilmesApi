using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private CartazContext _context;
    private IMapper _mapper;

    public FilmeController(CartazContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    
    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id },
             filme);
    }


    [HttpGet]
    public IEnumerable<ReadFilmesDto> RecupararFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmesDto>>( _context.Filmes.Skip(skip).Take(take));
    }


    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            throw new Exception("Filme  do ID não foi encontrado.!!");
        }
        var filmeDto = _mapper.Map<ReadFilmesDto>(filme);   
        return Ok(filmeDto);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id,[FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>
        filme.Id == id);
        if (filme == null)
        {
            throw new Exception("Filme  do ID não foi encontrado.!!");
        }
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return Ok("Alegria!! Deu certo ");

    }


    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial(int id,
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>
        filme.Id == id);
        if (filme == null)
        {
            throw new Exception("Filme do ID não foi encontrado.!!");
        }

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return Ok("Alegria!!! Deu certo");

    }


    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>
        filme.Id == id);
        if (filme == null)
        {
            throw new Exception("Filme  do ID não foi encontrado.!!");
        }

        _context.Filmes.Remove(filme);
        var resut = _context.SaveChanges();
        return Ok("Voçê é um gênio!! Parabéns!!");

    }

}
