using System.ComponentModel.DataAnnotations;
namespace FilmesApi.Models;

public class Filme
{
    public Filme(int id, string titulo, string genero, int duracao)
    {
        Id = id;
        Titulo = titulo;
        Genero = genero;
        Duracao = duracao;
    }

    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênereo não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A Duração deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }
}
