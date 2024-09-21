using System.ComponentModel.DataAnnotations;

namespace Autos.DTOs.Autos.DTOs
{
    public class CreateAutoDTO
    {
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(30, ErrorMessage ="El campo no puede contener mas de 30 caracteres")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo no puede contener mas de 60 caracteres")]
        public string Modelo { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(4, ErrorMessage = "El campo no puede contener mas de 4 caracteres")]
        public int Year { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Precio { get; set; }
    }
}
