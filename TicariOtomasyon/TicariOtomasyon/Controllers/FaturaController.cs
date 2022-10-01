using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir",fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var faturaa = c.Faturalars.Find(f.FaturaID);
            faturaa.FaturaSeriNo = f.FaturaSeriNo;
            faturaa.FaturaSiraNo = f.FaturaSiraNo;
            faturaa.FaturaSaat = f.FaturaSaat;
            faturaa.FaturaTarih = f.FaturaTarih;
            faturaa.TeslimAlan = f.TeslimAlan;
            faturaa.TeslimEden = f.TeslimEden;
            faturaa.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();

            ViewBag.id1 = id;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(int id,FaturaKalem fk)
        {
            fk.Faturaid = id;
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}