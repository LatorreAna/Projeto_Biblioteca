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
            return View();
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult RegistrarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaUsuarioAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario u)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaUsuarioAdmin(this);

            u.Senha = Criptografo.TextoCriptografado(u.Senha);
            
            UsuarioService us = new UsuarioService();
            us.incluirUsuario(u);
            return RedirectToAction("ListarUsuarios");
        }
        public IActionResult ListarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaUsuarioAdmin(this);
            UsuarioService us = new UsuarioService();
            return View(us.Listar());
        }

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaUsuarioAdmin(this);
            UsuarioService us = new UsuarioService();
            return View(us.ListarId(id));
        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario uEditado)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaUsuarioAdmin(this);

            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario u = new Usuario();
                u = bc.Usuarios.Find(uEditado.Id);

                if(u.Senha != uEditado.Senha)
                {
                    uEditado.Senha = Criptografo.TextoCriptografado(uEditado.Senha);
                }
            }

            UsuarioService us = new UsuarioService();
            us.editarUsuario(uEditado);

            return RedirectToAction("ListarUsuarios");
        }

        public IActionResult ExcluirUsuario(int id)
        {
            UsuarioService us = new UsuarioService();
            us.excluirUsuario(id);
            return RedirectToAction("ListarUsuarios");
        }
    }
}