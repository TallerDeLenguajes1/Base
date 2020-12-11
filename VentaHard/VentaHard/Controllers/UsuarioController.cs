using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaHard.Entities;
using VentaHard.Repositorio;
using VentaHard.ViewModels;

namespace VentaHard.Controllers
{
    public class UsuarioController : Controller
    {       
        private readonly IMapper _mapper;
        
        public UsuarioController(IMapper mapper)
        {            
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            RepositorioUsuario repoUsuarios = new RepositorioUsuario();
            var listaUsuarios = repoUsuarios.GetAll();
            var listUsuariosViewModel = _mapper.Map<List<UsuarioViewModel>>(listaUsuarios);
            return View(listUsuariosViewModel);
        }

        public IActionResult Alta(int id)
        {
            return View(new UsuarioViewModel());            
        }

        [HttpPost]        
        public IActionResult CrearUsuario(Usuario usuarioParaAlta)
        {
            RepositorioUsuario repoUsuarios = new RepositorioUsuario();
            if (ModelState.IsValid)
            {                               
                repoUsuarios.AltaUsuario(usuarioParaAlta);                             
            }

            return Redirect("Index");
        }

        [HttpGet]
        [Route("/Usuario/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            RepositorioUsuario repoUsuarios = new RepositorioUsuario();
            if (id > 0)
            {
                Usuario UsuarioDTO = repoUsuarios.GetUsuario(id);
                var UsuariosViewModel = _mapper.Map<UsuarioViewModel>(UsuarioDTO);
                return View(UsuariosViewModel);
            }

            return Redirect("Index");
        }


        public IActionResult ModificarUsuario(UsuarioViewModel usuarioAModificar)
        {
            if (ModelState.IsValid)
            {
                RepositorioUsuario repoUsuarios = new RepositorioUsuario();
                Usuario UsuarioDTO = _mapper.Map<Usuario>(usuarioAModificar);
                repoUsuarios.ModificarUsuario(UsuarioDTO);
            }

            return Redirect("Index");
        }

        [HttpGet]
        [Route("/Usuario/Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            RepositorioUsuario repoUsuarios = new RepositorioUsuario();
            if (id > 0)
            {
                repoUsuarios.EliminarUsuario(id);                                
            }
            return RedirectToAction(actionName: "Index", controllerName: "Usuario");
        }
    }
}
