using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Yapilacaks.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult YeniYapilacak()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYapilacak(Yapilacak yapil)
        {
            yapil.Durum = false;
            c.Yapilacaks.Add(yapil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YapilacakSil(int id)
        {
            var yapsil = c.Yapilacaks.Find(id);
            c.Yapilacaks.Remove(yapsil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YapilacakTamamla(int id)
        {
            var yaptam = c.Yapilacaks.Find(id);
            yaptam.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YapilacakGeriAl(int id)
        {
            var yaptam = c.Yapilacaks.Find(id);
            yaptam.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}