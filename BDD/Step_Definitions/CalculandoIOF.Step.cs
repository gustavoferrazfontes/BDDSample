using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Financeiro.Core;
using System.Globalization;
using WatiN.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace BDD.Step_Definitions
{
    [Binding]
    public sealed class CalculandoIof
    {

        #region Propriedades
        private IWebDriver _driver;
        #endregion

        #region Setup

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        [AfterScenario()]
        public void AfterScenario()
        {

            _driver.Close();
        }

        #endregion

        #region Primeira Parte

        [Given(@"que estou em uma tela de operação de titulos")]
        public void DadoQueEstouEmUmaTelaDeOperacaoDeTitulos()
        {
            _driver.Navigate().GoToUrl("http://localhost:60030/titulo/CalcularTitulo");

        }

        [Given(@"a data da Proposta (.*)")]
        public void CarregarDataDeProposta(string dp)
        {
            _driver.FindElement(By.Id("DataDaProposta")).SendKeys(dp);
        }

        [Given(@"a data de Vencimento (.*)")]
        public void CarregarDataDeVencimento(string dv)
        {
            _driver.FindElement(By.Id("DataDoVencimento")).SendKeys(dv);
        }

        [Given(@"a Taxa de IOF de (.*)%")]
        public void CarregarTaxaDeIof(double taxaDeIof)
        {
            _driver.FindElement(By.Id("TaxaIOF")).SendKeys(taxaDeIof.ToString());
        }


        [Given(@"o percentual de IOF informado é de (.*)%")]
        public void CarregarPercentualDeIof(double percentualDeIof)
        {
            _driver.FindElement(By.Id("PercentualDeIOF")).SendKeys(percentualDeIof.ToString());
        }

        [Given(@"o valor de Compra do Titulo de R\$ (.*)")]
        public void CarregarValorDeCompra(double valorDeCompra)
        {
            _driver.FindElement(By.Id("ValorDoTitulo")).SendKeys(valorDeCompra.ToString());
        }

        [When(@"for solicitado o valor do IOF do titulo")]
        public void QuandoForSolicitadoOValorDoIOFDoTitulo()
        {
            _driver.FindElement(By.Id("Calcular")).Click();
        }

        [Then(@"teremos o valor de IOF do titulo de R\$ (.*)")]
        public void EntaoTeremosOValorDeIOFDoTituloDeR(string valorEsperado)
        {
            var result = _driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual(result, valorEsperado);
        }

        #endregion

    }
}
