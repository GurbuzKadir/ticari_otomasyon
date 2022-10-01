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
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0&&Path.GetFileName(Request.Files[0].FileName).ToString() != "")
            {
                Random rnd_gorsel = new Random();
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName) + "_" + rnd_gorsel.Next(1000,100000)+"_"+rnd_gorsel.Next(1000,100000);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/Personel/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel= "/Image/Personel/" + dosyaadi + uzanti;
            }
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAdi,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.PersonelID);
            if (Request.Files.Count > 0&& Path.GetFileName(Request.Files[0].FileName).ToString()!="")
            {
                Random rnd_gorsel = new Random();
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName) + "_" + rnd_gorsel.Next(1000, 100000) + "_" + rnd_gorsel.Next(1000, 100000);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);

                
                //Önceki resimi sil baş
                string delPath = Request.MapPath("~" + p.PersonelGorsel.ToString() + "");
                if (System.IO.File.Exists(delPath))
                {
                    System.IO.File.Delete(delPath);
                }
                //Önceki resimi sil son


                string yol = "~/Image/Personel/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/Personel/" + dosyaadi + uzanti;

                prsn.PersonelGorsel = p.PersonelGorsel;
            }

            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            //prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            prsn.PersonelAdres = p.PersonelAdres;
            prsn.PersonelTelefon = p.PersonelTelefon;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var sil = c.Personels.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.Where(x => x.Durum == true).ToList();
            return View(sorgu);
        }
    }
}