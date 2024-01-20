using Microsoft.EntityFrameworkCore;

namespace MovieLibrary
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Sua-String-de-Conexão");
        }
    }
}
