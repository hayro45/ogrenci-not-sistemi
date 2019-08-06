using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int Sayi1=1, int Sayi2=1)
        {
            int topla = (Sayi1+Sayi2);
            int cikar = (Sayi1-Sayi2);
            int bol = (Sayi1/Sayi2);
            int carp = (Sayi1 * Sayi2);
            ViewBag.tpl = topla;
            ViewBag.ckr = cikar;
            ViewBag.bl = bol;
            ViewBag.crp = carp;
            return View();
        }
    }
}