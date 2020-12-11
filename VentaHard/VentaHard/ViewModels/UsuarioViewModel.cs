using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentaHard.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]        
        public string NombreUsuario { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Telefono { get; set; }
    }
}
