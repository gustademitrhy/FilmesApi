using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadAtorDto
    {

        [Required(ErrorMessage = "O Nome do ator é obrigatorio")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
        public int Idade { get; set; }


        public int filmesFeito { get; set; }
        public DateTime HoraDaConsulta  { get; set;} = DateTime.Now;
}
    }
