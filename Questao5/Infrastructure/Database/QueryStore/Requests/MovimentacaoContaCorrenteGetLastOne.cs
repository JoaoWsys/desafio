using AutoMapper;
using Dapper;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;
using System.Data.Common;
using System.Data.SqlClient;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class MovimentacaoContaCorrenteGetLastOne
    {
        private readonly ConnectionDB _connection = new();
        public async Task<MovimentacaoContaCorrenteGetLastOneResponse> Execute()
        {
            var connection = _connection.ConnectionOpen();
            
            string command = "SELECT * FROM movimento ORDER BY datamovimento DESC LIMIT 1;";
            try
            {
                object response = await connection.QueryFirstAsync<Movimento>(command);
                if (response != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Movimento, MovimentacaoContaCorrenteGetLastOneResponse>();
                    });

                    var mapper = config.CreateMapper();
                    var result = mapper.Map<MovimentacaoContaCorrenteGetLastOneResponse>(response);

                    return result;
                }
                else
                {
                    return new MovimentacaoContaCorrenteGetLastOneResponse();
                };
            }
            catch (Exception ex)
            {
                return new MovimentacaoContaCorrenteGetLastOneResponse();
            }
            
        }
    }
}