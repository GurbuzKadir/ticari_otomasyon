using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            var deger2 = c.Uruns.Count().ToString();
            var deger3 = c.Personels.Count().ToString();
            var deger4 = c.Kategoris.Count().ToString();

            var deger5 = c.Uruns.Sum(x=>x.Stok).ToString();
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            var deger7 = c.Uruns.Count(x=>x.Stok<=20).ToString();
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAdi).FirstOrDefault();

            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAdi).FirstOrDefault();
            var deger10 = c.Uruns.Count(x => x.UrunAdi=="Buzdolabı").ToString();
            var deger11 = c.Uruns.Count(x => x.UrunAdi=="Laptop").ToString();
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();

            var deger13 = c.Uruns.Where(u => u.UrunID == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAdi).FirstOrDefault();
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();

            string bugun="";
            if ((DateTime.Now.Month)<10)
            {
                bugun = ""+DateTime.Now.Year.ToString()+"-0"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString()+"";
            }
            else
            {
                bugun = "" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "";
            }
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == ""+bugun+"").ToString();
            
            var deger16 = "";
            try
            {
                deger16 = c.SatisHarekets.Where(x => x.Tarih == "" + bugun + "").Sum(y => (decimal?)y.ToplamTutar).ToString();
            }
            catch
            {
                deger16 = "-";
            }

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;

            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;

            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;

            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            ViewBag.d16 = deger16;
            return View();
        }
    }
}