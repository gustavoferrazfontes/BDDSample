using Demo.Web.Models;
using Financeiro.Core;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Web.Controllers
{
    public class TituloController : Controller
    {
        [HttpGet]
        public ActionResult CalcularTitulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalcularTitulo(TituloViewSpecficModel tituloViewSpecificModel)
        {
            var validade = new Validade(tituloViewSpecificModel.DataDaProposta, tituloViewSpecificModel.DataDoVencimento);
            var titulo = new Titulo(validade, tituloViewSpecificModel.TaxaIOF, (double)tituloViewSpecificModel.ValorDoTitulo, tituloViewSpecificModel.PercentualDeIOF);
            var calculo = titulo.CacularValorDoIOF();
            return RedirectToAction("ValorDOIOF", new RouteValueDictionary(
    new { action = "ValorDoIOF", valor = calculo }));
        }

        public ActionResult ValorDOIOF(double valor)
        {
            var iofCalculado = new IOFCalculadoSpecifModel() { valor = valor };
            return View(iofCalculado);
        }
    }
}