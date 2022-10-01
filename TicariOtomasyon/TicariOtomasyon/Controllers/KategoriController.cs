using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();//tablolar
        public ActionResult Index()
        {
            var degerler = c.Kategoris.Where(x => x.Durum == true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            k.Durum = true;
            c.Kategoris.Add(k);
            c.SaveChanges();
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var sil = c.Kategoris.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

            //var ktg = c.Kategoris.Find(id);
            //c.Kategoris.Remove(ktg);
            //c.SaveChanges();
            //return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAdi = k.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}