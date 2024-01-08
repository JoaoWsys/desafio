using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class SaldoContaCorrenteCommand : IRequest <SaldoContaCorrenteCommandResult>
    {
        public string IdContaCorrente { get; set; }
    }
}
