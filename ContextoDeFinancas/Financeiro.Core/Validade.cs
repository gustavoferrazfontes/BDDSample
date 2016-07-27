using System;

namespace Financeiro.Core
{
    public class Validade
    {
        public DateTime DataDeProposta { get; private set; }
        public DateTime DataDeVencimento { get; private set; }


        public Validade(DateTime dataDeProposta, DateTime dataDeVencimento)
        {
            DataDeProposta = dataDeProposta;
            DataDeVencimento = dataDeVencimento;
        }

    }
}
