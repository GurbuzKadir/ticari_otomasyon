using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context(); 
        public ActionResult Index()
        {
            var degerler = c.KargoDetays.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();

            string[] karakterler = { "A", "B", "C", "D","E","F","G","H","I","J","K","L","M","N","O","Q","P","R","S","T","U","V","W","Y","Z"};

            int k1, k2, k3;

            k1 = rnd.Next(0, 25);
            k2 = rnd.Next(0, 25);
            k3 = rnd.Next(0, 25);

            int s1, s2, s3;

            s1 = rnd.Next(100,999);
            s2 = rnd.Next(10,99);
            s3 = rnd.Next(10,99);

            string kod1 = s1.ToString() + karakterler[k1].ToString() + s2.ToString() + karakterler[k2].ToString() + s3.ToString() + karakterler[k3].ToString();

            ViewBag.takipkod = kod1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            d.Durum = true;
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);
        }
    }
}