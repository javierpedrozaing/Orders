﻿using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Orders.Frontend;
using Orders.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5262/") });

// configuramos la inyección del repositorio
builder.Services.AddScoped<IRepository, Repository>(); // Notacion diamante porque tambien es un genérico

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();

