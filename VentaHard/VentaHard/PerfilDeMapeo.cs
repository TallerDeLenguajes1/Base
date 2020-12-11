using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaHard.Entities;
using VentaHard.ViewModels;

namespace VentaHard
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
