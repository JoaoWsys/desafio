using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentacaoContaCorrenteCommand : IRequest <MovimentacaoContaCorrenteCommandResult>
    {
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimento { get; set; }
    }
}
