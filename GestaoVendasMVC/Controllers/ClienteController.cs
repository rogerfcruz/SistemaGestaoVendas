using GestaoVendasMVC.Models;
using GestaoVendasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoVendasMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.FindAll();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Create(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var cliente = _clienteService.FindById(id.Value);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Edit(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var cliente = _clienteService.FindById(id.Value);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteService.FindById(id);
            if (ModelState.IsValid)
            {
                _clienteService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
    }
}
