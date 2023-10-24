using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using TaxiService.Interfaces;

namespace TaxiService.Services
{
    public class AddOrderService : IAddOrderService
    {

        public void AddOrder(HttpContext httpContext, DbContext dbContext, decimal price, string tripBegin, string tripEnd, string carClass)
        {
            var car = dbContext.Set<Car>().Where(c => c.Class == carClass).FirstOrDefault();
            var order = new Order { Price = price, TripBegin = tripBegin, TripEnd = tripEnd, Car = car };
            dbContext.AddAsync(order);
            dbContext.SaveChangesAsync();
        }
    }
}
