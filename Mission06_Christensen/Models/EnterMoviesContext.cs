using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Christensen.Models;

public class EnterMoviesContext : DbContext 
{
    public EnterMoviesContext(DbContextOptions<EnterMoviesContext> options) : base(options) // constructor
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}
