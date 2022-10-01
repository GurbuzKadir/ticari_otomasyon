using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dept = c.Departmans.Find(id);
            return View("DepartmanGetir", dept);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept1 = c.Departmans.Find(d.DepartmanID);
            dept1.DepartmanAdi = d.DepartmanAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt_adi = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdi).FirstOrDefault();
            ViewBag.d_adi = dpt_adi;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            var dpt1_adi = c.Personels.Where(x => x.PersonelID == id).Select(y => y.Departmanid).FirstOrDefault();
            var dep_ad = c.Departmans.Where(x => x.DepartmanID == dpt1_adi).Select(y => y.DepartmanAdi).FirstOrDefault();


            ViewBag.p_adi = per;
            ViewBag.d_adi = dep_ad;
            return View(degerler);
        }
    }
}