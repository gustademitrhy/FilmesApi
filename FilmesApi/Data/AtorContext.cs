using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class AtorContext : DbContext
{
	public AtorContext(DbContextOptions<AtorContext> opts) 
		: base(opts)
	{

	}

	public DbSet<Ator> Atores { get; set; }
}
