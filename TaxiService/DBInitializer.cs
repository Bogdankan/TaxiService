using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace TaxiService
{
    public static class DBInitializer
    {
        public static void Initialize(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasData(
                new Driver { Id = 1, FirstName = "Mykola", LastName = "Ivanov", PhoneNumber = "+380733447676" },
                new Driver { Id = 2, FirstName = "Ivan", LastName = "Petrov", PhoneNumber = "+380738908888" },
                new Driver { Id = 3, FirstName = "Andriy", LastName = "Melnyk", PhoneNumber = "+380731297632" },
                new Driver { Id = 4, FirstName = "Ryan", LastName = "Gosling", PhoneNumber = "+380737663478" }
                );
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Class = "Standart", DriverId = 1 },
                new Car { Id = 2, Class = "Comfort", DriverId = 2 },
                new Car { Id = 3, Class = "Business", DriverId = 3 },
                new Car { Id = 4, Class = "Business", DriverId = 4 }
                );          
        }
    }
}
