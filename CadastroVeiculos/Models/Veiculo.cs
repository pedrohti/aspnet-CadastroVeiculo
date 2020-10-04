using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroVeiculos.Models
{
	public class Veiculo
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[MaxLength(7, ErrorMessage = "Máximo de 7 caracteres")]
		public string Placa { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
		public string Frota { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[MaxLength(4, ErrorMessage = "Máximo de 4 caracteres")]
		public string Ano { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[DisplayName("Data da Aquisição")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime DataAquisicao { get; set; }

		[ForeignKey("FuncionarioId")]
		public Funcionario Funcionario { get; set; }

		[ForeignKey("CategoriaId")]
		public Categoria Categoria { get; set; }

		[ScaffoldColumn(false)]
		[Required(ErrorMessage = "Campo Obrigatório")]
		public int FuncionarioId { get; set; }

		[ScaffoldColumn(false)]
		[Required(ErrorMessage = "Campo Obrigatório")]
		public int CategoriaId { get; set; }
	}
}