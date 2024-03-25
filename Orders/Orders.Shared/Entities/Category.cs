using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Orders.Shared.Interfaces;

namespace Orders.Shared.Entities
{
    public class Category : IEntityWithName
	{
        public int id { get; set; }

        [Display(Name = "Category")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
    }
}

