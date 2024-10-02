using System.ComponentModel.DataAnnotations;

namespace Autos.DTOs.Autos.DTOs
{
    public class GetIdResultAuto
    {
        public int Id { get; set; }
       
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Año")]
        public int Year { get; set; }

        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
