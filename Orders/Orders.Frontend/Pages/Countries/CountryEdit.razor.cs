﻿using System;
using System.Net;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Orders.Frontend.Repositories;
using Orders.Shared.Entities;

namespace Orders.Frontend.Pages.Countries
{
	public partial class CountryEdit
	{
        private CountryForm? countryForm;

        private Country? country;

        [Inject] private IRepository repository { get; set; } = null;

        [Inject] private SweetAlertService sweetAlertService { get; set; } = null;

        [Inject] private NavigationManager navigationManager { get; set; } = null; // framework component

        [EditorRequired, Parameter] public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await repository.GetAsync<Country>($"/api/countries/{Id}");

            if(responseHttp.Error)
            {
                if (responseHttp.Httpresponsemessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/countries/");
                }
                else
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                }
            }
            else
            {
                country = responseHttp.Response;
            }
        }

        private async Task EditCountryAsync()
        {
            var responseHttp = await repository.PutAsync("/api/countries", country);
            if(responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }


            Return();

            var toast = sweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 300
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito");
        }

        private void Return()
        {
            countryForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("/countries");
        }
    }
}

