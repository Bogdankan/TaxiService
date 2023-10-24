using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TaxiService.Interfaces;

namespace TaxiService.Middleware
{
    public class AddOrderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddOrderMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        //To do
        public async Task InvokeAsync(HttpContext httpContext, IHost app, EFCoreTaxiDbContext dbContext)
        {
            if (httpContext.Request.Path == "/addorder")
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";
                await httpContext.Response.SendFileAsync("AddOrder.html");
            }
            else if (httpContext.Request.Path == "/postorder")
            {
                var orderService = app.Services.GetRequiredService<IAddOrderService>();
                var form = httpContext.Request.Form;
                decimal price = 200;
                string tripBegin = form["startAddress"];
                string tripEnd = form["endAddress"];
                string carClass = form["carClass"];
                orderService.AddOrder(httpContext, dbContext, price, tripBegin, tripEnd, carClass);
                await httpContext.Response.WriteAsync("Order was added");
            }
            {               
                await _next.Invoke(httpContext);
            }
        }
    }
}
