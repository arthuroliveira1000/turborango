using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurboRango.Dominio;
using TurboRango.Web.Models;

namespace TurboRango.Web.Controllers
{
    [Authorize]
    public class RestaurantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurantes
        public ActionResult Index()
        {
            var model = db.Restaurantes.Include(x => x.Localizacao).Include(x => x.Contato).ToList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Lista()
        {
            var model = db.Restaurantes.Include(x => x.Localizacao).Include(x => x.Contato).Include(x => x.Prato).ToList();
            return View(model);
        }

        // GET: Restaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Include(x => x.Localizacao).Include(x => x.Contato).Include(x => x.Prato).FirstOrDefault(x => x.id == id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, Nome, Capacidade, Categoria, Contato, Localizacao, Prato, HorarioRegistro")] Restaurante restaurante)
        {
            ModelState.Remove("Localizacao.id");
            ModelState.Remove("Contato.id");
            ModelState.Remove("Prato.id");
            if (ModelState.IsValid)
            {
                restaurante.HorarioRegistro = DateTime.Now;
                db.Restaurantes.Add(restaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Include(x => x.Localizacao).Include(x => x.Contato).Include(x => x.Prato).FirstOrDefault(x => x.id == id);


            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, Nome, Capacidade, Categoria, Contato, Localizacao, Prato, HorarioRegistro")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurante).State = EntityState.Modified;
                db.Entry(restaurante.Contato).State = EntityState.Modified;
                db.Entry(restaurante.Localizacao).State = EntityState.Modified;
                db.Entry(restaurante.Prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Include(x => x.Localizacao).Include(x => x.Contato).Include(x => x.Prato).FirstOrDefault(x => x.id == id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            db.Entry(restaurante).State = EntityState.Deleted;
            if (restaurante.Contato != null)
            {
                db.Entry(restaurante.Contato).State = EntityState.Deleted;
            }
            if (restaurante.Localizacao != null)
            {
                db.Entry(restaurante.Localizacao).State = EntityState.Deleted;
            }
            if (restaurante.Prato != null)
            {
                db.Entry(restaurante.Prato).State = EntityState.Deleted;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult Restaurantes()
        {
            var todos = db.Restaurantes
                .Include(_ => _.Localizacao)
                .Include(_ => _.Prato)
                .ToList();

            return Json(new
            {
                restaurantes = todos,
            }, JsonRequestBehavior.AllowGet
            );
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
