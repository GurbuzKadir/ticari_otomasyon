using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class DuyuruDetayCariController : Controller
    {
        // GET: DuyuruDetayCari
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var deger = c.Duyurus.Where(x => x.DuyuruID == id).ToList();
            return View(deger);
        }
    }
}