using CadastroVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using CadastroVeiculos.Data.Config;
using System.Data.Entity.Migrations;

namespace CadastroVeiculos.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext() : base("DbCadastroVeiculo")
		{
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;
			Database.SetInitializer(new DbInitializer<BancoContext>());
		}

		public DbSet<Veiculo> Veiculos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Categoria> Categorias { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar").HasMaxLength(50));

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Configurations.Add(new VeiculoConfig());
			modelBuilder.Configurations.Add(new FuncionarioConfig());
			modelBuilder.Configurations.Add(new CategoriaConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}