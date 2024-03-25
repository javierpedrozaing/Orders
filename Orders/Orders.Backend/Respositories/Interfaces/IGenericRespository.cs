using System;
using Orders.Frontend.Repositories;
using Orders.Shared.Responses;

namespace Orders.Backend.Respositories.Interfaces
{
	public interface IGenericRespository<T> where T : class // validation where T is class
	{
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync(); // devovler lista de una entidad

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}

