using FilmesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ElencoAtorDto
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int filmesFeito { get; set; }

        public ICollection<Filme> Filmes { get; set; }
    }
}
