using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models; 

namespace OgrenciNotMvc.Controllers
{
    public class SinavNotlariController : Controller
    {
        // GET: SinavNotlari
        DbMvcOkulEntities3 sn = new DbMvcOkulEntities3();
        public ActionResult Index()
        {
            var sinavNotlari = sn.TBLNOTLAR.ToList();
            return View(sinavNotlari);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR tbn)
        {
            sn.TBLNOTLAR.Add(tbn);
            sn.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SinavGetir(int id)
        {
            var not = sn.TBLNOTLAR.Find(id);
            return View("SinavGetir", not);
        }
        [HttpPost]
        public ActionResult SinavGetir(Class1 model, TBLNOTLAR p, int SINAV1=0, int SINAV2=0, int SINAV3=0, int PROJE=0)
        {
            if (model.islem == "HESAPLA")
            {
                bool durum;
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                if (ORTALAMA < 50)
                {
                    durum = false;
                    
                }
                else
                {
                    durum = true;
                    
                }
                ViewBag.drm = durum;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var snv = sn.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                snv.DURUM = p.DURUM;
                sn.SaveChanges();
                return RedirectToAction("Index", "SinavNotlari");

            }
            return View();
        }
    }
}