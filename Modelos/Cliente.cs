using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CadastroClientesAPI.Models
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		public string CPF { get; set; }
		[Required]
		public DateTime DataNascimento { get; set; }
		[Required]
		public string NomeMae { get; set; }
		[Required]
		public string Telefone { get; set; }
		[Required]	
		public string Endereco { get; set; }
		[Required]
		public string Email { get; set; }

	}
}
