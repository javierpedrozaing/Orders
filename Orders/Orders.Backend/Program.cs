﻿using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Respositories.Implementations;
using Orders.Backend.Respositories.Interfaces;
using Orders.Backend.UnitOfWork.Implementations;
using Orders.Backend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DockerConnection"));
builder.Services.AddScoped(typeof(IGenericRespository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddTransient<SeeDB>();

var app = builder.Build();

// injección manual
SeedData(app);

async void SeedData(WebApplication app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeeDB>();
        service!.SeedAsync().Wait();
    }
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

