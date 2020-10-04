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
	}
}
