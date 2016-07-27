using System;

namespace Financeiro.Core
{
    public class Titulo
    {
        public Guid IdTitulo { get; private set; }
        public Validade Validade { get; private set; }
        public IOF IOF { get; private set; }
        public double ValorDaCompra { get; private set; }

        public Titulo(Validade validade, double taxaDeIOF, double valorDaCompra, double percentualIOF)
        {
            IdTitulo = Guid.NewGuid();
            Validade = validade;
            ValorDaCompra = valorDaCompra;
            IOF = new IOF(validade.DataDeVencimento, Validade.DataDeProposta, taxaDeIOF, percentualIOF);
        }

        public double PrimeiroIOF()
        {
            var primeiroValorIOF = Math.Round(((IOF.TaxaDoPeriodo * ValorDaCompra) / 100), 2);
            return primeiroValorIOF;
        }

        public double SegundoValorDoIOF()
        {
            return ValorDaCompra * IOF.PorcentualIOF;
        }

        public double CacularValorDoIOF()
        {
            return PrimeiroIOF() + SegundoValorDoIOF();
        }
    }
}
