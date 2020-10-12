using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreMysql.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMysql.controllers
{
    [Route("default")]
    public class UsuarioController : Controller
    {
        DataContext db = new DataContext();

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.usuario = db.Usuario.ToList();
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Usuario usuarios)
        {
            db.Usuario.Add(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Usuario.Remove(db.Usuario.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Usuario.Find(id));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Usuario usuarios)
        {
            db.Entry(usuarios).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Buscar")]
        public IActionResult Buscar(string nome)
        {
            ViewBag.usuario = db.Usuario.Where(x => x.nome.Contains(nome));
            return View("Index");
        }
    }
}
