namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class SaldoContaCorrenteGetSumResponse
    {
        public decimal SaldoContaCorrente { get; set; }
        public DateTime DataHoraResposta { get; set; }
        public decimal SaldoAtual { get; set; } 
        public string NomeTitular { get; set; }
        public int NumeroContaCorrente { get; set; }
    }
}
