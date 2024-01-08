using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Handlers;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaCorrenteController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("MovimentacaoContaCorrente")]
        public async Task<IActionResult> Get([FromQuery] MovimentacaoContaCorrenteCommand command)
        {
            // Exemplo de consulta usando Dapper
            var result = await _mediator.Send(command);

            if (result.Erro == null)
            {
                return Ok($"Identificação do Movimento:  {result.IdMovimento}");
            }
            else
            {
                return BadRequest(result.Erro);
            }
        }

        // Lembre-se de fechar a conexão quando a instância do controlador for destruída (pode ser feito no método Dispose, por exemplo).
        // Não é necessário fechar a conexão após cada consulta, pois o Dapper gerencia isso internamente.
        // No entanto, é uma boa prática fechar a conexão quando ela não for mais necessária.
        //public void Dispose()
        //{
        //    _dbConnection.Close();
        //}
    }
}
