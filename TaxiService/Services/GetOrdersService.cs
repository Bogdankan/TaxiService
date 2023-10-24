using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using TaxiService.Interfaces;

namespace TaxiService.Services
{
    public class GetOrdersService : IGetOrdersService
    {
        public IEnumerable<Order> GetOrders(HttpContext httpContext, DbContext dbContext)
        {
            if (dbContext.Set<Order>() != null)
            {
                return dbContext.Set<Order>().Include(o => o.Car).ToList();
            }
            return new List<Order>();
        }
    }
}
