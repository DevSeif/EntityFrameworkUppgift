using EntityFrameworkUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Olof Olofsson", PhoneNumber = "0733456021", City = "Göteborg" },
                new Person { Id = 2, Name = "Per Persson", PhoneNumber = "0733456022", City = "Stockholm" },
                new Person { Id = 3, Name = "Anders Andersson", PhoneNumber = "0733456023", City = "Malmö" },
                new Person { Id = 4, Name = "Rolf Rolfsson", PhoneNumber = "0733456024", City = "Borås" },
                new Person { Id = 5, Name = "Björn Björnsson", PhoneNumber = "0733456025", City = "Gbg" }
                );
        }
    }
}
