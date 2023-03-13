using System.ComponentModel.DataAnnotations;


namespace FilmesApi.Models;



public class Ator 
{

    [Key]
    [Required]
    public int Id { get; set; }


    [Required(ErrorMessage = "O Nome do ator é obrigatorio")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]

    public  int Idade { get; set; }

    public int filmesFeito { get; set; }

    public ICollection<Elenco> ElencoAtore { get; set; }

}
