using Microsoft.EntityFrameworkCore;

namespace MovieLibrary
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\yohan\\source\\repos\\MovieLibrary\\Database1.mdf;Integrated Security=True");
        }
    }
}
