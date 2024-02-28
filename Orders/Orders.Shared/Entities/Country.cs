﻿using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities
{
	public class Country
	{
		public int id { get; set; }

		[Display(Name="País")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
		[Required(ErrorMessage = "El campo {0} es requerido.")]
		public string Name { get; set; } = null!;
	}
}

