using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CadastroClientesAPI.Data;
using CadastroClientesAPI.Models;

namespace CadastroClientesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.CPF) ||
                cliente.DataNascimento == default || string.IsNullOrEmpty(cliente.NomeMae) || string.IsNullOrEmpty(cliente.Telefone) || string.IsNullOrEmpty(cliente.Endereco) || string.IsNullOrEmpty(cliente.Email))
            {
                return BadRequest("All fields are required.");
            }

            var cpfExists = _context.Clientes.Any(c => c.CPF == cliente.CPF);
            if (cpfExists)
            {
                return BadRequest("A client with this CPF already exists.");
            }

            //mudança no formato da hora
            cliente.DataNascimento = cliente.DataNascimento.Date.ToString("dd/MM/yyyy");

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { cpf = cliente.CPF }, cliente);
        }

        [HttpGet("{cpf}")]
        public IActionResult GetCliente(string cpf)
        {
            var clienteExists = _context.Clientes.Any(c => c.CPF == cpf);
            return Ok(clienteExists);
        }
    }
}
