using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            if (Request.Files.Count > 0 && Path.GetFileName(Request.Files[0].FileName).ToString() != "")
            {
                Random rnd_gorsel = new Random();
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName) + "_" + rnd_gorsel.Next(1000, 100000) + "_" + rnd_gorsel.Next(1000, 100000);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/Urun/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Image/Urun/" + dosyaadi + uzanti;
            }

            p.Durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var sil = c.Uruns.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn1 = c.Uruns.Find(p.UrunID);
            if (Request.Files.Count > 0 && Path.GetFileName(Request.Files[0].FileName).ToString() != "")
            {
                Random rnd_gorsel = new Random();
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName) + "_" + rnd_gorsel.Next(1000, 100000) + "_" + rnd_gorsel.Next(1000, 100000);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                

                //Önceki resimi sil baş
                string delPath = Request.MapPath("~"+urn1.UrunGorsel.ToString()+"");
                if (System.IO.File.Exists(delPath))
                {
                    System.IO.File.Delete(delPath);
                }
                //Önceki resimi sil son

                string yol = "~/Image/Urun/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Image/Urun/" + dosyaadi + uzanti;

                urn1.UrunGorsel = p.UrunGorsel;
            }

            
            urn1.AlisFiyat = p.AlisFiyat;
            urn1.Durum = p.Durum;
            urn1.Kategoriid = p.Kategoriid;
            urn1.Marka = p.Marka;
            urn1.SatisFiyat = p.SatisFiyat;
            urn1.Stok = p.Stok;
            urn1.UrunAdi = p.UrunAdi;
            //urn1.UrunGorsel = p.UrunGorsel;
            urn1.Detay = p.Detay;
            urn1.Aciklama = p.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelID + "-" + x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            List<SelectListItem> deger4 = (from x in c.Carilers.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariID + "-" + x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            var deger = c.Uruns.Find(id);

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger.UrunID;
            ViewBag.dgr3 = deger.SatisFiyat;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger.Stok;
            ViewBag.dgr6 = deger.UrunAdi;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket par)
        {
            c.SatisHarekets.Add(par);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}