using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Elenco
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int AtorId { get; set; }

    }
}
