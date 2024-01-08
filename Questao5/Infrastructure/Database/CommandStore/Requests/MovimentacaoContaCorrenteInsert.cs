using Dapper;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class MovimentacaoContaCorrenteInsert
    {
        private readonly ConnectionDB _connection = new();

        public MovimentacaoContaCorrenteInsertResponse Execute(Movimento movimento)
        {
            var response = new MovimentacaoContaCorrenteInsertResponse();
            var connection = _connection.ConnectionOpen();
            string command = "INSERT INTO movimento values (@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento, @valor)";
            try
            {
                response.result = connection.Execute(command, new { idmovimento = movimento.IdMovimento, idcontacorrente = movimento.IdContaCorrente, datamovimento = movimento.DataMovimento, tipomovimento = movimento.TipoMovimento, valor = movimento.Valor }) == 1 ? true : false;
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                connection.Close();
                return response;
            }
            
        }

    }
}
