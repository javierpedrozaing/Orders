using System;
using Orders.Backend.Respositories.Interfaces;
using Orders.Backend.UnitOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitOfWork.Implementations
{
	public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
	{
        public readonly IStatesRepository _statesRepository;

        public StatesUnitOfWork(IGenericRespository<State> repository, IStatesRepository statesRepository) : base(repository)
        {
            _statesRepository = statesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _statesRepository.GetAsync();

        public override async Task<ActionResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);
    }
}

