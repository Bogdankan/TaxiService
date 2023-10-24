using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Interfaces
{
    public interface IGetOrdersService
    {
        public IEnumerable<Order> GetOrders(HttpContext httpContext, DbContext dbContext);
    }
}
