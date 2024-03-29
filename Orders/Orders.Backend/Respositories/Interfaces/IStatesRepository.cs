﻿using System;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.Respositories.Interfaces
{
	public interface IStatesRepository
	{
        Task<ActionResponse<State>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<State>>> GetAsync();
    }
}

