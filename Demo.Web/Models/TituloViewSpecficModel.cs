using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models
{
    public class TituloViewSpecficModel
    {
        [Display(Name = "Data da proposta")]
        [Required(ErrorMessage = "Data da proposta é obrigatória")]
        public DateTime DataDaProposta { get; set; }
        [Display(Name = "Data do vencimento")]
        [Required(ErrorMessage = "Data do vencimento é obrigatoria")]
        public DateTime DataDoVencimento { get; set; }
        [Display(Name = "Taxa de IOF")]
        [Required(ErrorMessage = "Taxa do IOF é obrigatória")]
        public double TaxaIOF { get; set; }
        [Display(Name = "Valor do titulo")]
        [Required(ErrorMessage = "Valor do titulo é obrigatório")]
        public decimal   ValorDoTitulo { get; set; }
        [Display(Name = "Percentual de IOF")]
        [Required(ErrorMessage = "Percentual de IOF é obrigatório")]
        public double PercentualDeIOF { get; set; }
    }
}