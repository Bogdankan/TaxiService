using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TaxiService.Interfaces;

namespace TaxiService.Middleware
{
    public class OrdersListMiddleware
    {
        private readonly RequestDelegate _next;

        public OrdersListMiddleware(RequestDelegate next)
        {

            this._next = next;
        }
        //To do
        public async Task InvokeAsync(HttpContext httpContext, IHost app, EFCoreTaxiDbContext dbContext)
        {
            if (httpContext.Request.Path == "/orders")
            {
                var orderService = app.Services.GetRequiredService<IGetOrdersService>();

                httpContext.Response.ContentType = "text/html; charset=utf-8";
                var sb = new StringBuilder("<h3>Orders<h3><table>");
                sb.Append("<tr> <td><h3># |  </h3></td> <td><h3>Price |  </h3></td> <td><h3>Trip begin |  </h3></td>"
                    + "<td><h3>Trip end |  </h3></td> <td><h3>Car class   </h3></td>");
                int i = 1;

                foreach (var order in orderService.GetOrders(httpContext, dbContext))
                {
                    sb.Append($"<tr><td>{i}  </td> <td>{order.Price}  </td> <td>{order.TripBegin}  </td>"
                        + $"<td>{order.TripEnd} </td> <td>{order.Car.Class}</td>");
                    i++;
                }

                sb.Append("</table>");

                await httpContext.Response.WriteAsync(sb.ToString());
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
