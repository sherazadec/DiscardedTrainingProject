using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetArchi.Models;

namespace ProjetArchi.Controllers
{
    public class QuestionnaireCréationProjetController : Controller
    {
        private ProjetArchi3DEntities db = new ProjetArchi3DEntities();

        // GET: QuestionnaireCréationProjet
        public ActionResult Index()
        {
            var questionnaireCréationProjet = db.QuestionnaireCréationProjet.Include(q => q.Clients);
            return View(questionnaireCréationProjet.ToList());
        }

        // GET: QuestionnaireCréationProjet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireCréationProjet questionnaireCréationProjet = db.QuestionnaireCréationProjet.Find(id);
            if (questionnaireCréationProjet == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireCréationProjet);
        }

        // GET: QuestionnaireCréationProjet/Create
        public ActionResult Create()
        {
            ViewBag.xidClient = new SelectList(db.Clients, "id_client", "admin");
            return View();
        }

        // POST: QuestionnaireCréationProjet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idQuest,xidClient,Question_1,Question_2,Question_3,Question_4,Question_5,Question_6,Checked")] QuestionnaireCréationProjet questionnaireCréationProjet)
        {
            if (ModelState.IsValid)
            {
                db.QuestionnaireCréationProjet.Add(questionnaireCréationProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidClient = new SelectList(db.Clients, "id_client", "admin", questionnaireCréationProjet.xidClient);
            return View(questionnaireCréationProjet);
        }

        // GET: QuestionnaireCréationProjet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireCréationProjet questionnaireCréationProjet = db.QuestionnaireCréationProjet.Find(id);
            if (questionnaireCréationProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidClient = new SelectList(db.Clients, "id_client", "admin", questionnaireCréationProjet.xidClient);
            return View(questionnaireCréationProjet);
        }

        // POST: QuestionnaireCréationProjet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idQuest,xidClient,Question_1,Question_2,Question_3,Question_4,Question_5,Question_6,Checked")] QuestionnaireCréationProjet questionnaireCréationProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionnaireCréationProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidClient = new SelectList(db.Clients, "id_client", "admin", questionnaireCréationProjet.xidClient);
            return View(questionnaireCréationProjet);
        }

        // GET: QuestionnaireCréationProjet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionnaireCréationProjet questionnaireCréationProjet = db.QuestionnaireCréationProjet.Find(id);
            if (questionnaireCréationProjet == null)
            {
                return HttpNotFound();
            }
            return View(questionnaireCréationProjet);
        }

        // POST: QuestionnaireCréationProjet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionnaireCréationProjet questionnaireCréationProjet = db.QuestionnaireCréationProjet.Find(id);
            db.QuestionnaireCréationProjet.Remove(questionnaireCréationProjet);
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
