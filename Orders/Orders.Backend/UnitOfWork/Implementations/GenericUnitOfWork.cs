using System;
using Orders.Backend.Respositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitOfWork.Implementations
{
	public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRespository<T> _repository;

        public GenericUnitOfWork(IGenericRespository<T> repository )
		{
            _repository = repository; // el underscore tambien nos permite no tener que utilizar la palabra this
        }

        public async Task<ActionResponse<T>> AddAsync(T model) => await _repository.AddAsync(model);

        public async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();

        public async Task<ActionResponse<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);
    }
}

