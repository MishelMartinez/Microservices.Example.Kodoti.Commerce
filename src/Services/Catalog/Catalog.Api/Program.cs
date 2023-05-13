using Catalog.Persistence.Database;
using Catalog.Services.Queries;
using Catalog.Services.Queries.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"),
                                    x=>x.MigrationsHistoryTable("_EFMigrationsHistory","Catalog")
                                    )
                );

//mediator
// SE registra el Assembly para que no se inserte command por command
builder.Services.AddMediatR(Assembly.Load("Catalog.Service.EventHandlers"));


builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
