using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Listar(Usuario user)
        {
            _ = new UsuarioService();

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem()
        {
            return View();
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