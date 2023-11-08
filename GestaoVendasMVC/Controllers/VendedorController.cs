using GestaoVendasMVC.Models;
using GestaoVendasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoVendasMVC.Controllers
{
    public class VendedorController : Controller
    {
        private readonly VendedorService _service;

        public VendedorController(VendedorService obj)
        {
            _service = obj;
        }

        public IActionResult Index()
        {
            var obj = _service.FindAll();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendedorModel obj)
        {
            if (ModelState.IsValid)
            {
                _service.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var obj = _service.FindById(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VendedorModel obj)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var obj = _service.FindById(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _service.FindById(id);
            if (ModelState.IsValid)
            {
                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
