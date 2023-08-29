using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult admin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Listar()
        {
            UsuarioService usuarioService = new UsuarioService();

            return RedirectToAction("ListarUsuarios");
        }

        public IActionResult ListarUsuarios(Usuario user)
        {
            return View(user);
        }

        public IActionResult incluirUsuario()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult editarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario user = us.ObterPorId(id);
            return View(user);
        }

        public IActionResult excluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario user = us.ObterPorId(id);
            return View(user);
        }
    }
}