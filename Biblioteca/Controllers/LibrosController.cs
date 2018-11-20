using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: Libros
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Categorias).Include(l => l.Idiomas);
            return View(libros.ToList());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Categoria");
            ViewBag.Idioma = new SelectList(db.Idiomas, "Id", "Idioma");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Resumen,Autor,Editorial,Lanzamiento,Idioma,Paginas,Categoria")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Categoria", libros.Categoria);
            ViewBag.Idioma = new SelectList(db.Idiomas, "Id", "Idioma", libros.Idioma);
            return View(libros);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Categoria", libros.Categoria);
            ViewBag.Idioma = new SelectList(db.Idiomas, "Id", "Idioma", libros.Idioma);
            return View(libros);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Resumen,Autor,Editorial,Lanzamiento,Idioma,Paginas,Categoria")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id", "Categoria", libros.Categoria);
            ViewBag.Idioma = new SelectList(db.Idiomas, "Id", "Idioma", libros.Idioma);
            return View(libros);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libros libros = db.Libros.Find(id);
            db.Libros.Remove(libros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
