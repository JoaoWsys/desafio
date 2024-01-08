namespace Questao5.Application.Commands.Requests
{
    public class SaldoContaCorrenteCommandResult
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public decimal SaldoAtual { get; set; }
        public string? Erro { get; set; }
    }
}
