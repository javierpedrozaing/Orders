using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Orders.Shared.Interfaces;

namespace Orders.Shared.Entities
{
	public class State : IEntityWithName
	{
        public int id { get; set; }
        public int CountryId { get; set; } // foreing key

        [Display(Name = "Departamento / Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public Country? Country { get; set; } // relacion uno a muchos con paises
        public ICollection<City>? Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null || Cities.Count == 0 ? 0 : Cities.Count;
    }
}

