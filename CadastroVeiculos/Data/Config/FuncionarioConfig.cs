using CadastroVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CadastroVeiculos.Data.Config
{
	public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
	{
		public FuncionarioConfig()
		{
			HasKey(f => f.Id);

			ToTable("Funcionarios");
		}
	}
}