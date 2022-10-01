using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class DuyuruCariController : Controller
    {
        // GET: DuyuruCari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Duyurus.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
    }
}