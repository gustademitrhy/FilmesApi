using FilmesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ElencoDto
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Genero{ get; set; }
        public ICollection<Ator> Atores { get; set; }
    }
}
