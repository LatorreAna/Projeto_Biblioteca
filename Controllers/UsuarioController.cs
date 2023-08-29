using System.Collections.Generic;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult admin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Listar()
        {
            return RedirectToAction("ListarUsuarios");
        }

        public IActionResult ListarUsuarios()
        {
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.Listar());
        }

        public IActionResult RegistrarUsuarios(Usuario user)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService usuarioService = new UsuarioService();
            usuarioService.registrarUsuario(user);
            return RedirectToAction("ListarUsuarios");
        }

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }

        public IActionResult excluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }
    }
}