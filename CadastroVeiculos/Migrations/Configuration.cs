using CadastroVeiculos.Data;
using CadastroVeiculos.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CadastroVeiculos.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<BancoContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(BancoContext context)
		{
			List<Categoria> categorias = new List<Categoria>();
			List<Funcionario> funcionarios = new List<Funcionario>();
			if (!context.Categorias.Any())
			{
				context.Categorias.AddOrUpdate(x => x.Id,
					new Categoria { Id = 1, Descricao = "Caminhão" },
					new Categoria { Id = 2, Descricao = "Esportivo" },
					new Categoria { Id = 3, Descricao = "Furgão" },
					new Categoria { Id = 4, Descricao = "Hatch" },
					new Categoria { Id = 5, Descricao = "Jipe" },
					new Categoria { Id = 6, Descricao = "Ônibus" },
					new Categoria { Id = 7, Descricao = "Picape" },
					new Categoria { Id = 8, Descricao = "Sedã" },
					new Categoria { Id = 9, Descricao = "SUV" },
					new Categoria { Id = 10, Descricao = "Van" },
					new Categoria { Id = 11, Descricao = "Veículo" }
					);
				//categorias = new List<Categoria>
				//{
				//	new Categoria { Id = 1, Descricao = "Caminhão" },
				//	new Categoria { Id = 2, Descricao = "Esportivo" },
				//	new Categoria { Id = 3, Descricao = "Furgão" },
				//	new Categoria { Id = 4, Descricao = "Hatch" },
				//	new Categoria { Id = 5, Descricao = "Jipe" },
				//	new Categoria { Id = 6, Descricao = "Ônibus" },
				//	new Categoria { Id = 7, Descricao = "Picape" },
				//	new Categoria { Id = 8, Descricao = "Sedã" },
				//	new Categoria { Id = 9, Descricao = "SUV" },
				//	new Categoria { Id = 10, Descricao = "Van" },
				//	new Categoria { Id = 11, Descricao = "Veículo" },
				//};

				
			}

			if (!context.Funcionarios.Any())
			{
				funcionarios = new List<Funcionario>
				{
					new Funcionario { Nome = "Carla" },
					new Funcionario { Nome = "João" },
					new Funcionario { Nome = "Leticia" },
					new Funcionario { Nome = "Marcelo" }
				};
			}

			context.Categorias.AddRange(categorias);
			context.Funcionarios.AddRange(funcionarios);
			base.Seed(context);
		}
	}
}
