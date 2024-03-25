using System;
using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
	public class SeeDB
	{

		private readonly DataContext _context;

		public SeeDB(DataContext context)
		{
			_context = context;
		}

		public async Task SeedAsync()
		{
			await _context.Database.EnsureCreatedAsync(); // corre un update de migraciones
			await CheckCountriesAsync();
			await ChecCategoriesAsync();

		}

        private async Task ChecCategoriesAsync()
        {
            if (!_context.Categories.Any())
			{
				_context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Hogar" });
				await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Argentina" });
                _context.Countries.Add(new Country { Name = "México" });
                await _context.SaveChangesAsync();
            }
        }
    }
}

