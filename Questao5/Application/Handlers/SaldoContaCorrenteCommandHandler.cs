using MediatR;
using Microsoft.Win32;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class SaldoContaCorrenteCommandHandler : IRequestHandler<SaldoContaCorrenteCommand, SaldoContaCorrenteCommandResult>
    {
        public async Task<SaldoContaCorrenteCommandResult> Handle(SaldoContaCorrenteCommand command, CancellationToken cancellationToken)
        {
            var consulta = new SaldoContaCorrenteSelectByIdContaCorrente();
            var response = consulta.Execute(command.IdContaCorrente).Result;
            var result = new SaldoContaCorrenteCommandResult();

            if (response == null)
            {
                result.Erro = "Tem erros";
                return result;
            }
            else
            {
                result.Data = response.DataHoraResposta;
                result.SaldoAtual = response.SaldoAtual;
                result.Nome = response.NomeTitular;
                result.Numero = response.NumeroContaCorrente;
                return result;
            }
        }
    }
}
 