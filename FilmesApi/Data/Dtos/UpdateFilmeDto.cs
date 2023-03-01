using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "O título do filme é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    [StringLength(50, ErrorMessage = "O tamanho do gênereo não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A Duração deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }
}
