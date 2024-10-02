using System.ComponentModel.DataAnnotations;

namespace Autos.DTOs.Autos.DTOs
{
    public class EditAutoDTO
    {
        //Contructor con parametros
        public EditAutoDTO(GetIdResultAuto get)
        {
            Id = get.Id;
            Marca = get.Marca;
            Modelo = get.Modelo;
            Year = get.Year;
            Precio = get.Precio;
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
        [Range(1, 9999, ErrorMessage = "El año no puede tener mas de 4 digitos.")]
        public int Year { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Precio {  get; set; }
    }
}
