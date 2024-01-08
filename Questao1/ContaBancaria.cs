using System.Dynamic;
using System.Globalization;

namespace Questao1
{
    internal class ContaBancaria {

        #region atrributes
        private readonly int Numero;
        private string Titular;
        private double Saldo;
        #endregion

        #region constructors
        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial;
        }

        public ContaBancaria(int numero, string titular)
        {
            this.Numero = numero;
            this.Titular = titular;
        }
        #endregion

        #region methods
        public void Deposito(double deposito)
        {
            this.Saldo += deposito;
        }

        public void Saque(double saque)
        {
            double taxa = 3.50;
            this.Saldo -= saque + taxa;
        }

        public void AlteracaoNomeTitular(string titular)
        {
            this.Titular = titular;
        }

        public override string ToString()
        {
            return $"Conta: {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
        #endregion
    }
}
