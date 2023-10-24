using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Interfaces
{
    public interface IEfCoreTaxiDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
