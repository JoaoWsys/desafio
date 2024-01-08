using MediatR;
using Microsoft.Win32;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class MovimentacaoContaCorrenteCommandHandler : IRequestHandler<MovimentacaoContaCorrenteCommand, MovimentacaoContaCorrenteCommandResult>
    {
        public async Task<MovimentacaoContaCorrenteCommandResult> Handle(MovimentacaoContaCorrenteCommand command, CancellationToken cancellationToken)
        {
            var movimentacao = new Movimento
            {  
                DataMovimento = DateTime.Now,
                IdContaCorrente = command.IdContaCorrente,
                IdMovimento = Guid.NewGuid().ToString().ToUpper(),
                TipoMovimento = command.TipoMovimento,
                Valor = command.Valor
            };

            var insert = new MovimentacaoContaCorrenteInsert();
            var response = insert.Execute(movimentacao);
            var result = new MovimentacaoContaCorrenteCommandResult();

            if (!response.result)
            {
                result.Erro = "Tem erros";
                return result;
            }
            else
            {
                var registro = new MovimentacaoContaCorrenteGetLastOne().Execute().Result;
                result.IdMovimento = registro.IdMovimento;
                return result;
            }
        }
    }
}
 