using System;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Countries
{
	public partial class CountriesIndex // partial significa que hay dos clases que se llaman lo mismo, pero copiladas generan una sola
	{
        [Inject] private IRepository repository { get; set; } = null;

        public List<Country>? Countries { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync(); // inicialización por defecto
            var responseHttp = await repository.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response;
        }
    }
}

