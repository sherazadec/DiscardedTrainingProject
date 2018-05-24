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
    public class ArchivesController : Controller
    {
        private ProjetArchi3DEntities db = new ProjetArchi3DEntities();

        // GET: Archives
        public ActionResult Index()
        {
            var archives = db.Archives.Include(a => a.Personnes).Include(a => a.Projets);
            return View(archives.ToList());
        }

        // GET: Archives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            return View(archives);
        }

        // GET: Archives/Create
        public ActionResult Create()
        {
            ViewBag.xid_personnes = new SelectList(db.Personnes, "id", "Nom");
            ViewBag.xid_proj = new SelectList(db.Projets, "id_proj", "id_proj");
            return View();
        }

        // POST: Archives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_archive,xid_proj,Images,fichiers,xid_personnes")] Archives archives)
        {
            if (ModelState.IsValid)
            {
                db.Archives.Add(archives);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xid_personnes = new SelectList(db.Personnes, "id", "Nom", archives.xid_personnes);
            ViewBag.xid_proj = new SelectList(db.Projets, "id_proj", "id_proj", archives.xid_proj);
            return View(archives);
        }

        // GET: Archives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            ViewBag.xid_personnes = new SelectList(db.Personnes, "id", "Nom", archives.xid_personnes);
            ViewBag.xid_proj = new SelectList(db.Projets, "id_proj", "id_proj", archives.xid_proj);
            return View(archives);
        }

        // POST: Archives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_archive,xid_proj,Images,fichiers,xid_personnes")] Archives archives)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archives).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xid_personnes = new SelectList(db.Personnes, "id", "Nom", archives.xid_personnes);
            ViewBag.xid_proj = new SelectList(db.Projets, "id_proj", "id_proj", archives.xid_proj);
            return View(archives);
        }

        // GET: Archives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archives archives = db.Archives.Find(id);
            if (archives == null)
            {
                return HttpNotFound();
            }
            return View(archives);
        }

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Archives archives = db.Archives.Find(id);
            db.Archives.Remove(archives);
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
