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
    public class RéponsesQuestionnaireProjetController : Controller
    {
        private ProjetArchi3DEntities db = new ProjetArchi3DEntities();

        // GET: RéponsesQuestionnaireProjet
        public ActionResult Index()
        {
            var réponsesQuestionnaireProjet = db.RéponsesQuestionnaireProjet.Include(r => r.QuestionnaireCréationProjet);
            return View(réponsesQuestionnaireProjet.ToList());
        }

        // GET: RéponsesQuestionnaireProjet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RéponsesQuestionnaireProjet réponsesQuestionnaireProjet = db.RéponsesQuestionnaireProjet.Find(id);
            if (réponsesQuestionnaireProjet == null)
            {
                return HttpNotFound();
            }
            return View(réponsesQuestionnaireProjet);
        }

        // GET: RéponsesQuestionnaireProjet/Create
        public ActionResult Create()
        {
            ViewBag.xidQuest = new SelectList(db.QuestionnaireCréationProjet, "idQuest", "Question");
            return View();
        }

        // POST: RéponsesQuestionnaireProjet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRep,Reponses,xidQuest,xidProjet")] RéponsesQuestionnaireProjet réponsesQuestionnaireProjet)
        {
            if (ModelState.IsValid)
            {
                db.RéponsesQuestionnaireProjet.Add(réponsesQuestionnaireProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.xidQuest = new SelectList(db.QuestionnaireCréationProjet, "idQuest", "Question", réponsesQuestionnaireProjet.xidQuest);
            return View(réponsesQuestionnaireProjet);
        }

        // GET: RéponsesQuestionnaireProjet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RéponsesQuestionnaireProjet réponsesQuestionnaireProjet = db.RéponsesQuestionnaireProjet.Find(id);
            if (réponsesQuestionnaireProjet == null)
            {
                return HttpNotFound();
            }
            ViewBag.xidQuest = new SelectList(db.QuestionnaireCréationProjet, "idQuest", "Question", réponsesQuestionnaireProjet.xidQuest);
            return View(réponsesQuestionnaireProjet);
        }

        // POST: RéponsesQuestionnaireProjet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRep,Reponses,xidQuest,xidProjet")] RéponsesQuestionnaireProjet réponsesQuestionnaireProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(réponsesQuestionnaireProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.xidQuest = new SelectList(db.QuestionnaireCréationProjet, "idQuest", "Question", réponsesQuestionnaireProjet.xidQuest);
            return View(réponsesQuestionnaireProjet);
        }

        // GET: RéponsesQuestionnaireProjet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RéponsesQuestionnaireProjet réponsesQuestionnaireProjet = db.RéponsesQuestionnaireProjet.Find(id);
            if (réponsesQuestionnaireProjet == null)
            {
                return HttpNotFound();
            }
            return View(réponsesQuestionnaireProjet);
        }

        // POST: RéponsesQuestionnaireProjet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RéponsesQuestionnaireProjet réponsesQuestionnaireProjet = db.RéponsesQuestionnaireProjet.Find(id);
            db.RéponsesQuestionnaireProjet.Remove(réponsesQuestionnaireProjet);
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
