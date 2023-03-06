
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class CartazContext : DbContext
    {
        public CartazContext(DbContextOptions<CartazContext> opts) 
            : base(opts)
        {

        }
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Ator> Atores { get; set; }


  
    }
}
