﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroVeiculos.Models
{
	public class Categoria
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50, ErrorMessage = "Máximo 50 Caracteres")]
		public string Descricao { get; set; }
	}
}