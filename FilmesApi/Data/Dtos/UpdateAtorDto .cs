using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Data.Dtos;

public class UpdateAtorDto
{

    [Required(ErrorMessage = "O Nome do ator é obrigatorio")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    public int Idade { get; set; }

    public int FilmesFeito { get; set; }

  


}
