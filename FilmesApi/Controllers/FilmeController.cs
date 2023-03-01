using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
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
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id },
             filme);
    }


    [HttpGet]
    public IEnumerable<Filme> RecuparFilmes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id,
        [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>
        filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();

    }
     

    [HttpPatch("{id}")]
    public  IActionResult AtualizarFilmeParcial(int id, 
        JsonPatchDocument<UpdateFilmeDto> pacth)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>
        filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        pacth.ApplyTo(filmeParaAtualizar, ModelState);

        if(!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }   

        _mapper.Map(filmeParaAtualizar, filme);
       var resut =  _context.SaveChanges();
        return Ok(resut);

    }

}
