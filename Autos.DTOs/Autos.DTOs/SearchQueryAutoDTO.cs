using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos.DTOs.Autos.DTOs
{
    public class SearchQueryAutoDTO
    {
        [Display(Name = "Marca")]
        public string? Marca_Like { get; set; }

        [Display(Name = "Modelo")]
        public string? Modelo_Like { get; set; }

        [Display(Name = "Pagina")]
        public int Skip { get; set; }

        [Display(Name = "CantReg x Pagina")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
}
