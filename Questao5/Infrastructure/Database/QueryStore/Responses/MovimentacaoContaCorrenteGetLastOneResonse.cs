using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class MovimentacaoContaCorrenteGetLastOneResponse
    {
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
