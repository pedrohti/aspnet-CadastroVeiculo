using CadastroVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CadastroVeiculos.Data.Config
{
	public class CategoriaConfig : EntityTypeConfiguration<Categoria>
	{
		public CategoriaConfig()
		{
			HasKey(c => c.Id);

			ToTable("Categorias");
		}
	}
}