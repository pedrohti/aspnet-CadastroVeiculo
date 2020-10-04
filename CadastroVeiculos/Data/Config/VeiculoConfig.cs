using CadastroVeiculos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CadastroVeiculos.Data.Config
{
	public class VeiculoConfig : EntityTypeConfiguration<Veiculo>
	{
		public VeiculoConfig()
		{
			HasKey(v => v.Id);
			
			Property(v => v.Placa)
				.IsRequired()
				.HasColumnAnnotation("IX_Placa", new IndexAnnotation(new IndexAttribute { IsUnique = true }));
			
			Property(v => v.Frota)
				.IsRequired()
				.HasColumnAnnotation("IX_Frota", new IndexAnnotation(new IndexAttribute { IsUnique = true }));

			Property(v => v.Ano)
				.IsRequired()
				.HasMaxLength(4);

			ToTable("Veiculos");
		}
	}
}