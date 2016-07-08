using MVCBierenApplication.Models;
using MVCBierenApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBierenApplication.Controllers
{
    public class BierController : Controller
    {
        private BierService bierService = new BierService();
        // GET: Bier
        public ActionResult Index()
        {
            List<Bier> bieren = bierService.FindAll();

            return View(bieren);
        }

        public ActionResult Verwijderen(int id)
        {
            var bier = bierService.Read(id);
            return View(bier);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bier = bierService.Read(id);
            this.TempData["bier"] = bier;
            bierService.Delete(id);
            return RedirectToAction("Verwijderd");
        }

        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);

        }
    }


}