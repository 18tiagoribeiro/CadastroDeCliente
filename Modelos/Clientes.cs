using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CadastroClientesAPI.Models
{
	public class Cliente
	{
		public string Nome { get; set; }
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
		public string NomeMae {  get; set; }

	}
}
