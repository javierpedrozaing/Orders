using System;
namespace Orders.Frontend.Repositories
{
	public interface IRepository
	{
		Task<HttpResponseWrapper<T>> GetAsync<T>(String url);

		Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model); // post que no devuelve respuesta

		Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model); // post que devuelve respuesta
    }
}

