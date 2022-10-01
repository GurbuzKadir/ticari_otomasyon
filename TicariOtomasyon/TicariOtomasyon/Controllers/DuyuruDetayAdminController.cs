using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize(Roles = "A,B")]
    public class DuyuruDetayAdminController : Controller
    {

        // GET: DuyuruDetayAdmin
        Context c = new Context();
        public ActionResult Index(int id)
        {
            var deger = c.Duyurus.Where(x => x.DuyuruID == id).ToList();
            return View(deger);
        }
    }
}