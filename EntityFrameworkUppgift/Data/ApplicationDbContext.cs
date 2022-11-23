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
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasKey(p => p.PersonId);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);

            modelBuilder.Entity<Person>().HasOne(p => p.City).WithMany(c => c.People).HasForeignKey(x => x.CityId);
            modelBuilder.Entity<City>().HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, Name = "Olof Olofsson", PhoneNumber = "0733456021", CityId = 1 },
                new Person { PersonId = 2, Name = "Per Persson", PhoneNumber = "0733456022", CityId = 2 },
                new Person { PersonId = 3, Name = "Anders Andersson", PhoneNumber = "0733456023", CityId = 3 },
                new Person { PersonId = 4, Name = "Rolf Rolfsson", PhoneNumber = "0733456024", CityId = 4 },
                new Person { PersonId = 5, Name = "Björn Björnsson", PhoneNumber = "0733456025", CityId = 5 }
                );

            modelBuilder.Entity<City>().HasData(
                new City { CityName = "Göteborg", CityId = 1, CountryId = 1 },
                new City { CityName = "Stockholm", CityId = 2, CountryId = 1 },
                new City { CityName = "Malmö", CityId = 3, CountryId = 1 },
                new City { CityName = "Helsinki", CityId = 4, CountryId = 2 },
                new City { CityName = "Copenhagen", CityId = 5, CountryId = 3 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Sweden" },
                new Country { CountryId = 2, CountryName = "Finland" },
                new Country { CountryId = 3, CountryName = "Denmark" },
                new Country { CountryId = 4, CountryName = "Norway" },
                new Country { CountryId = 5, CountryName = "Iceland" }
                );
        }
    }
}
