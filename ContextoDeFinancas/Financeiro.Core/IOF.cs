using System;

namespace Financeiro.Core
{
    public class IOF
    {
        public int Prazo { get; private set; }
        public double TaxaDoDia { get; private set; }
        public double TaxaDoPeriodo { get; private set; }
        public double TaxaDeIOF { get; private set; }
        public double PorcentualIOF { get; set; }


        public IOF(DateTime dataVencimento, DateTime dataProposta, double taxaIOF, double porcentualIOF)
        {
            TaxaDeIOF = taxaIOF;
            PorcentualIOF = porcentualIOF / 100;
            Prazo = (dataVencimento - dataProposta).Days;
            TaxaDoDia = Math.Round(((taxaIOF/100) / 365)*100, 4);
            TaxaDoPeriodo = TaxaDoDia * Prazo;
        }
    }
}
