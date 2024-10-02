using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos.DTOs.Autos.DTOs
{
    public class SearchResultAutoDTO
    {
        public int CountRow { get; set; }
        public List<AutosDTO> Data { get; set; }
        public class AutosDTO
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
}

