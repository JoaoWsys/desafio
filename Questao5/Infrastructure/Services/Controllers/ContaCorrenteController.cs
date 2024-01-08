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

        [HttpPost("MovimentacaoContaCorrente")]
        public async Task<IActionResult> MovimentacaoContaCorrente([FromBody] MovimentacaoContaCorrenteCommand command)
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


        [HttpGet("SaldoContaCorrente")]
        public async Task<IActionResult> SaldoContaCorrente([FromQuery] SaldoContaCorrenteCommand command)
        {
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
    }
}
