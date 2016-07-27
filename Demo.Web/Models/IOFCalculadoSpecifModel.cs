using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models
{
    public class IOFCalculadoSpecifModel
    {
        
        [Display(Name ="Valor do IOF:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double valor { get; set; }
    }
}