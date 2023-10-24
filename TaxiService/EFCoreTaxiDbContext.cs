using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiService;
using TaxiService.Interfaces;

namespace DataLayer
{
    public class EFCoreTaxiDbContext : DbContext, IEfCoreTaxiDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EFCoreTaxiDbContext(DbContextOptions<EFCoreTaxiDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreatedAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Initialize();
        }
    }
}
 