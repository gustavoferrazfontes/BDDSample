using Financeiro.Core;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using System;

namespace IOF.Tests
{
    public class DadoUmTitulo : SpecBase
    {
        protected Titulo titulo;
        private DateTime _dataDeProposta;
        private DateTime _dataDeVencimento;
        private double _taxaDeIOF;
        private double _valorDaCompra;
        private double _porcentualIOF;

        protected override void Establish_context()
        {
            base.Establish_context();
            _dataDeProposta = new DateTime(2012, 10, 31);
            _dataDeVencimento = new DateTime(2012, 11, 29);
            _taxaDeIOF = 1.5;
            _valorDaCompra = 353.18;
            _porcentualIOF = 0.38;
        }
        protected override void Because_of()
        {
            base.Because_of();
            var validade = new Validade(_dataDeProposta, _dataDeVencimento);
            titulo = new Titulo(validade, _taxaDeIOF, _valorDaCompra, _porcentualIOF);

        }
    }

    public class QuandoForCriarUmTitulo : DadoUmTitulo
    {

        [Test]
        public void EntaoGarantoQueTenhaDataDeProposta()
        {
            titulo.Validade.DataDeProposta.ShouldNotBeNull();
            titulo.Validade.DataDeProposta.ShouldNotEqual(new DateTime(1, 1, 1));
        }

        [Test]
        public void EntaoGarantoQueTenhaDataDeVencimento()
        {
            titulo.Validade.DataDeVencimento.ShouldNotBeNull();
            titulo.Validade.DataDeVencimento.ShouldNotEqual(new DateTime(1, 1, 1));
        }

        [Test]
        public void EntaoGarantoQueTenhaIOF()
        {
            titulo.IOF.ShouldNotBeNull();
        }

        [Test]
        public void EntaoGarantoQueTenhaTaxaDeIOFInformada()
        {
            titulo.IOF.TaxaDeIOF.ShouldBeGreaterThan(0);
        }

        [Test]
        public void EntaoGarantoQueTenhaPrazo()
        {
            titulo.IOF.Prazo.ShouldBeGreaterThan(0);
        }

        [Test]
        public void EntaoGarantoQueTenhaTaxaDoDia()
        {
            titulo.IOF.TaxaDoDia.ShouldBeGreaterThan(0);
        }

        [Test]
        public void EntaoGarantoQueTaxaDoDiaTenhaQuatroCasasDecimais()
        {
            titulo.IOF.TaxaDoDia.ToString().Split(',')[1].Length.ShouldEqual(4);
        }

        [Test]
        public void EntaoGarantoQueTenhaTaxaDoPeriodo()
        {
            titulo.IOF.TaxaDoPeriodo.ShouldBeGreaterThan(0);
        }

        [Test]
        public void EntaoGarantoQueTenhaValorDaCompra()
        {
            titulo.ValorDaCompra.ShouldBeGreaterThan(0);
        }
    }

    public class QuandoForCalcularOValorDeIOF : DadoUmTitulo
    {

        double valorAtualDoPrimeiroIOF;
        double valorAtualDoSegundoValorDoIOF;
        double valorAtualDoIOFDoTitulo;
        protected override void Because_of()
        {
            base.Because_of();
            valorAtualDoPrimeiroIOF = titulo.PrimeiroIOF();
            valorAtualDoSegundoValorDoIOF = titulo.SegundoValorDoIOF();
            valorAtualDoIOFDoTitulo = titulo.CacularValorDoIOF();
        }

        [Test]
        public void EntaoTenhoOValorDoPrimeiroIOF()
        {
            valorAtualDoPrimeiroIOF.ShouldEqual(0.42);
        }

        [Test]
        public void EntaoGarantoQueOPrimeiroIOFTenhaDuasCasasDecimais()
        {
            valorAtualDoPrimeiroIOF.ToString().Split(',').Length.ShouldEqual(2);
        }

        [Test]
        public void EntaoTenhoASegundaParteDoCalculo()
        {
            valorAtualDoSegundoValorDoIOF.ShouldEqual(1.342084);
        }

        [Test]
        public void EntaoTenhoOValorDeIOFDoTitulo()
        {
            valorAtualDoIOFDoTitulo.ShouldEqual(1.762084);
        }
    }
}
