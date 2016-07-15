using MVCBierenApplication.Models;
using MVCBierenApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        private MVCBierenEntities db = new MVCBierenEntities();
        private BierService bierService = new BierService();
        // GET: Bier
        public ActionResult Index()
        {
            List<Bier> bieren = bierService.FindAll();

            return View(bieren);
        }

        // GET: Plant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bier bier = db.Bieren.Find(id);
            if (bier == null)
            {
                return HttpNotFound();
            }
            return View("Verwijderen", bier);
        }

        // POST: Plant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bier bier = db.Bieren.Find(id);
            this.TempData["bier"] = bier;
            db.Bieren.Remove(bier);
            db.SaveChanges();
            return RedirectToAction("Verwijderd", bier);
        }

        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);

        }

        // GET: Plant/Create
        public ActionResult Create()
        {
            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam");
            return View("Toevoegen");
        }

        // POST: Plant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BierNr,Naam,BrouwerNr,SoortNr,Alcohol")] Bier bier)
        {
            if (ModelState.IsValid)
            {
                db.Bieren.Add(bier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Naam");
            return View("Toevoegen");
        }
    }
}