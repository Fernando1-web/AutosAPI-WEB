using System.ComponentModel.DataAnnotations;

namespace Autos.DTOs.Autos.DTOs
{
    public class EditAutoDTO
    {
        //Contructor con parametros
        public EditAutoDTO(GetIdResultAuto get)
        {
            Id = get.Id;
        }

        //Constructo vacio
        public EditAutoDTO()
        {
        }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de 30 caracteres")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener mas de 60 caracteres")]
        public string Modelo { get; set; }

        [Display(Name = "Año")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede tener mas de 4 caracteres")]
        public int Year { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Precio {  get; set; }
    }
}
