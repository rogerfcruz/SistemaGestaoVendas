﻿using GestaoVendasMVC.Models;
using GestaoVendasMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoVendasMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService obj)
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
        public IActionResult Create(ClienteModel obj)
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
        public IActionResult Edit(int id, ClienteModel obj)
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
