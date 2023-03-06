using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]

public class AtorController : ControllerBase
{
    private CartazContext _context1;
    private IMapper _mapper1;

    public AtorController(CartazContext context, IMapper mapper)
    {
        _context1 = context;
        _mapper1 = mapper;
    }

    [HttpPost]
    public IActionResult AdiconarAtores([FromBody] Ator ator)
    {
        _context1.Atores.Add(ator);
        _context1.SaveChanges();
        return CreatedAtAction(nameof(RecuperarAtorPorId), new { id = ator.Id }, ator);
    }




    [HttpGet]
    public IEnumerable<Ator> RecuperaAtor([FromQuery] int skip = 0,
     [FromQuery] int take = 50)
    {
        return _context1.Atores.Skip(skip).Take(take);
    }


    [HttpGet("{id}")]
    public IActionResult RecuperarAtorPorId(int id)
    {
        var ator = _context1.Atores.FirstOrDefault(ator => ator.Id == id);
        if (ator == null) return NotFound();
        return Ok(ator);

    }


    [HttpPut("{id}")]
    public IActionResult AtualizarAtor(int id, [FromBody] UpdateAtorDto AtorDto)
    {
        var ator = _context1.Atores.FirstOrDefault(ator => ator.Id == id);
        if (ator == null) return NotFound();
        _mapper1.Map(AtorDto, ator);
        _context1.SaveChanges();
        return Ok("Deu certo Meu Nobre!!!! Alegria ");
    }

    [HttpPatch("{id}")]

    public IActionResult AtualizarAtorParcial(int id, JsonPatchDocument<UpdateAtorDto> patch)
    {
        var ator = _context1.Atores.FirstOrDefault(ator => ator.Id == id);
        if (ator == null) return NotFound();

        var ATorParaAtualizar = _mapper1.Map<UpdateAtorDto>(ator);

        patch.ApplyTo(ATorParaAtualizar, ModelState);

        if (!TryValidateModel(ATorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper1.Map(ATorParaAtualizar, ator);
        _context1.SaveChanges();
        return Ok("Deu certo de Novo Meu Nobre!!!! Alegria ");
    }


    [HttpDelete("{id}")]
    public IActionResult DeteleAtor(int id)
    {
        var ator = _context1.Atores.FirstOrDefault(ator => ator.Id == id);
        if (ator == null) return NotFound();

        _context1.Atores.Remove(ator);
        _context1.SaveChanges();
        return Ok("Caba bom viu !!!! Alegria que Deu Certo ");

    }

}

