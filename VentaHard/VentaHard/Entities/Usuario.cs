using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaHard.Entities
{
    public class Usuario
    {
        private int idUsuario;
        private string nombreUsuario;
        private string telefono;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
