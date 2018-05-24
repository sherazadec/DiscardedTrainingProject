using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetArchi.Models;

namespace ProjetArchi.Views
{
    public class ArchitectesController : Controller
    {
        private ProjetArchi3DEntities db = new ProjetArchi3DEntities();

        // GET: Architectes
        public ActionResult Index()
        {
            var architectes = db.Architectes.Include(a => a.Personnes);
            return View(architectes.ToList());
        }

        // GET: Architectes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architectes architectes = db.Architectes.Find(id);
            if (architectes == null)
            {
                return HttpNotFound();
            }
            return View(architectes);
        }

        // GET: Architectes/Create
        public ActionResult Create()
        {
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom");
            return View();
        }

        // POST: Architectes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_archi,Num_Archi,xid")] Architectes architectes)
        {
            //try catch à ajouter - gestion d'erreurs
            if (ModelState.IsValid)
            {
                db.Architectes.Add(architectes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architectes.xid);
            return View(architectes);
        }

        // GET: Architectes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architectes architectes = db.Architectes.Find(id);
            if (architectes == null)
            {
                return HttpNotFound();
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architectes.xid);
            return View(architectes);
        }

        // POST: Architectes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_archi,Num_Archi,xid")] Architectes architectes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(architectes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xid = new SelectList(db.Personnes, "id", "Nom", architectes.xid);
            return View(architectes);
        }

        // GET: Architectes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Architectes architectes = db.Architectes.Find(id);
            if (architectes == null)
            {
                return HttpNotFound();
            }
            return View(architectes);
        }

        // POST: Architectes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Architectes architectes = db.Architectes.Find(id);
            db.Architectes.Remove(architectes);
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
