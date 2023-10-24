using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using TaxiService;
using TaxiService.Interfaces;
using TaxiService.Middleware;
using TaxiService.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFCoreTaxiDbContext>(options=> options.UseSqlite(connection));
builder.Services.AddScoped<IEfCoreTaxiDbContext, EFCoreTaxiDbContext>();

builder.Services.AddTransient<IGetOrdersService, GetOrdersService>();
builder.Services.AddTransient<IAddOrderService, AddOrderService>();


var app = builder.Build();

app.UseMiddleware<OrdersListMiddleware>();
app.UseMiddleware<AddOrderMiddleware>();

app.Run(async (context) => await context.Response.WriteAsync("Hello"));

app.Run();
