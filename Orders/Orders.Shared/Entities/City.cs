﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Orders.Shared.Entities
{
	public class City
    {
        public int id { get; set; }
        public int StateId { get; set; } // foreing key

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public State? State { get; set; } // relacion uno a muchos con estados
        public ICollection<User>? Users { get; set; }
    }
}

