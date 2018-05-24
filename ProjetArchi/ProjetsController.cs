using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetArchi.Models;

namespace ProjetArchi
{
    public class ProjetsController : Controller
    {
        private ProjetArchi3DEntities db = new ProjetArchi3DEntities();

        // GET: Projets
        public ActionResult Index()
        {
            return View(db.Projets.ToList());
        }

        // GET: Projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projets projets = db.Projets.Find(id);
            if (projets == null)
            {
                return HttpNotFound();
            }
            return View(projets);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proj,avancement,date,id_mod,id_client,id_archi")] Projets projets)
        {
            if (ModelState.IsValid)
            {
                db.Projets.Add(projets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projets);
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projets projets = db.Projets.Find(id);
            if (projets == null)
            {
                return HttpNotFound();
            }
            return View(projets);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proj,avancement,date,id_mod,id_client,id_archi")] Projets projets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projets);
        }

        // GET: Projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projets projets = db.Projets.Find(id);
            if (projets == null)
            {
                return HttpNotFound();
            }
            return View(projets);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projets projets = db.Projets.Find(id);
            db.Projets.Remove(projets);
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
