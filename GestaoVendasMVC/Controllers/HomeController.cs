using GestaoVendasMVC.Models;
using GestaoVendasMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoVendasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginService _loginService;

        public HomeController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                LoginModel Usuario = _loginService.UserExists(login);
                if (Usuario != null)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", Usuario.Id.ToString());
                    HttpContext.Session.SetString("NomeUsuarioLogado", Usuario.Nome);
                    TempData["NomeUsuario"] = Usuario.Nome.ToString();
                    return RedirectToAction(nameof(Menu));
                }
                TempData["LoginError"] = "E-mail e/ou senha inválidos!";
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                _loginService.CreateUser(loginModel);
                return RedirectToAction(nameof(Menu));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
