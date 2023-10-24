using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Interfaces
{
    public interface IAddOrderService
    {
        public void AddOrder(HttpContext httpContext, DbContext dbContext, decimal price, string tripBegin, string tripEnd, string carClass );
    }
}
