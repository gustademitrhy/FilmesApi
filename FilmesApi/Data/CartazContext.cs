using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;


namespace FilmesApi.Data;

public class CartazContext : DbContext
{
    public CartazContext(DbContextOptions<CartazContext> opts) 
        : base(opts)
    {
        
    }
    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Ator> Atores { get; set; }

    public DbSet<Elenco> Elenco { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elenco>()
            .HasKey(fa => new { fa.FilmeId, fa.AtorId });
     
    }




}