using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Elenco
    {
        public int FilmeId { get; set; }
        public Filme Filmes { get; set; }
        public int AtorId { get; set; }
        public Ator Atore { get; set; }
    }
}
