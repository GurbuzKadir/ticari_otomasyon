using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Duyurus.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()//view eklenecek +
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(Duyuru dyr)//+
        {
            dyr.Durum = false;
            c.Duyurus.Add(dyr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGetir(int id)//view eklenecek +
        {
            var duyurugtr = c.Duyurus.Find(id);
            return View("DuyuruGetir", duyurugtr);
        }
        public ActionResult DuyuruGuncelle(Duyuru d)//+
        {
            var dyr = c.Duyurus.Find(d.DuyuruID);
            dyr.DuyuruBaslik = d.DuyuruBaslik;
            dyr.DuyuruDetay = d.DuyuruDetay;
            dyr.Tarih = d.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)//+
        {
            var dyrsil = c.Duyurus.Find(id);
            c.Duyurus.Remove(dyrsil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGoster(int id)//+
        {
            var dyrtam = c.Duyurus.Find(id);
            dyrtam.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGeriAl(int id)//+
        {
            var dyrtam = c.Duyurus.Find(id);
            dyrtam.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}