using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateAtorDto
{


    [Required(ErrorMessage = "O Nome do ator é obrigatorio")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    public int Idade { get; set; }


    public int filmesFeito { get; set; }
}
