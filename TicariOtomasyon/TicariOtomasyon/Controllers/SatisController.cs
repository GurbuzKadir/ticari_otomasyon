using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunID + "-" + x.UrunAdi,
                                               Value = x.UrunID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariID + "-" + x.CariAd +" "+x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelID + "-" + x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunID + "-" + x.UrunAdi,
                                               Value = x.UrunID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariID + "-" + x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelID + "-" + x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();


            var deger = c.SatisHarekets.Find(id);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            ViewBag.dgr4 = deger.Adet;
            ViewBag.dgr5 = deger.Fiyat;
            ViewBag.dgr6 = deger.ToplamTutar;

            ViewBag.dgr7 = deger.Urun.Stok;
            

            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket st)
        {
            var deger = c.SatisHarekets.Find(st.SatisID);
            deger.Cariid = st.Cariid;
            deger.Adet = st.Adet;
            deger.Fiyat = st.Fiyat;
            deger.Personelid = st.Personelid;
            deger.Tarih = st.Tarih;
            deger.ToplamTutar = st.ToplamTutar;
            deger.Urunid = st.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
        
    }
}