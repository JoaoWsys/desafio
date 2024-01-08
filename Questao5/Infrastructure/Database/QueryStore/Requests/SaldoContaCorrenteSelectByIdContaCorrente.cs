using AutoMapper;
using Dapper;
using FluentAssertions;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class SaldoContaCorrenteSelectByIdContaCorrente
    {
        private readonly ConnectionDB _connection = new();
        public async Task<SaldoContaCorrenteGetSumResponse> Execute(string IdContaCorrente)
        {
            var result = new SaldoContaCorrenteGetSumResponse();
            var connection = _connection.ConnectionOpen();

            string command = @"SELECT c.numero AS NumeroContaCorrente, c.nome AS NomeTitular,
                             COALESCE(SUM(CASE WHEN m.tipomovimento = 'C' THEN m.valor ELSE 0 END), 0) - COALESCE(SUM(CASE WHEN m.tipomovimento = 'D' THEN m.valor ELSE 0 END), 0) AS SaldoAtual
                             FROM contacorrente c
                             JOIN movimento m ON m.idcontacorrente = c.idcontacorrente
                             WHERE m.idcontacorrente = @idContaCorrente;";


            try
            {
                var response = await connection.QueryFirstAsync(command, new { idContaCorrente = IdContaCorrente });
                if (response != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Movimento, MovimentacaoContaCorrenteGetLastOneResponse>()
                            .ForMember(dest => dest.IdContaCorrente, opt => opt.MapFrom(src => src.IdContaCorrente));
                    });


                    var mapper = config.CreateMapper();
                    var mappedResponse = mapper.Map<MovimentacaoContaCorrenteGetLastOneResponse>(response);

                    response.DataHoraResposta = DateTime.Now;
                    connection.Close();
                    return response;
                }
                else
                {
                    connection.Close();
                    return result;
                };
            }
            catch (Exception ex)
            {
                connection.Close();
                return result;
            }

        }
    }
}
