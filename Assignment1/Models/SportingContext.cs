using System;
using Microsoft.EntityFrameworkCore;


namespace Assignment1.Models
{
    public class SportingContext : DbContext
    {
        public SportingContext(DbContextOptions<SportingContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Incident> Incidents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(

                new Country { CountryId = 1, Name = "Canada" },
                new Country { CountryId = 2, Name = "US" },
                new Country { CountryId = 3, Name = "Mexico" },
                new Country { CountryId = 4, Name = "Other" }
                );
            modelBuilder.Entity<Customer>().HasData(

              new Customer
              {
                  CustomerId = 1,
                  FirstName = "Bruce",
                  LastName = "Wayne",
                  Address = "123 Random Lane",
                  City = "Toronto",
                  PostalCode = "M4N 250",
                  State = "Ontario",
                  Phone = "416-123-6456",
                  Email = "bruce@domain.com",
                  CountryId = 1,

              },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "123 Random Lane",
                    City = "New York",
                    State = "New York",
                    PostalCode = "1234",
                    Phone = "416-345-1237",
                    Email = "janedoe@domain.com",
                    CountryId = 2,

                },
                  new Customer
                  {
                      CustomerId = 3,
                      FirstName = "Emily",
                      LastName = "Wats",
                      Address = "123 Random Lane",
                      City = "Toronto",
                      PostalCode = "M4N 250",
                      State = "Ontario",
                      Phone = "647-860-1678",
                      Email = "wats@domain.com",
                      CountryId = 1,
                  }
           );
            modelBuilder.Entity<Technician>().HasData(

             new Technician
             {

                 TechnicianId = 1,
                 Name = "Fark Gallager",
                 Phone = "416-123-1234",
                 Email = "fGallager@sporting.com",
             },
             new Technician
             {
                 TechnicianId = 2,
                 Name = "Tim Burt",
                 Phone = "647-267-3795",
                 Email = "tBurt@sporting.com",
             },
             new Technician
             {

                 TechnicianId = 3,
                 Name = "Edgar Poe",
                 Phone = "437-769-1793",
                 Email = "ePoe@sporting.com",
             }
            );

            modelBuilder.Entity<Product>().HasData(

             new Product
             {
                 ProductId = 1,
                 Code = "TRNY10",
                 Name = "Tournament Master",
                 YearlyPrice = 10.99,
                 ReleaseDate = DateTime.Now
             },
             new Product
             {
                 ProductId = 2,
                 Code = "DRAFT10",
                 Name = "Draft Manager 2.0",
                 YearlyPrice = 5.99,
                 ReleaseDate = DateTime.Now
             },
             new Product
             {
                 ProductId = 3,
                 Code = "TRNY20",
                 Name = "Tournament Master 2.0",
                 YearlyPrice = 12.99,
                 ReleaseDate = DateTime.Now
             }
             );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 2,
                    ProductId = 1,
                    Title = "Could not install",
                    Description = "Customer is having issues with installation on Win 10",
                    TechnicianId = 3,
                    DateOpened = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 3,
                    ProductId = 2,
                    Title = "Error launching program",
                    Description = "Encountered compatability issues",
                    TechnicianId = 3,
                    DateOpened = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 3,
                    CustomerId = 1,
                    ProductId = 1,
                    Title = "Error while attempting to run program",
                    Description = "Unknown error when attempting to open program",
                    TechnicianId = 3,
                    DateOpened = DateTime.Now
                }
             );
        }
    }
}

