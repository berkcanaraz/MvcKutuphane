using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.DTO;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKITAP.Count();
            var deger3 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);

            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            LinqKartDto linqKartDto = new LinqKartDto();

            linqKartDto.KitapCount = db.TBLKITAP.Count();
            linqKartDto.UyelerCount = db.TBLUYELER.Count();
            linqKartDto.CezalarToplam = db.TBLCEZALAR.Sum(x => x.PARA);
            linqKartDto.AktifOlmayanKitapCount = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            linqKartDto.KategoriCount = db.TBLKATEGORI.Count();
            linqKartDto.EnFazlaKitapYazar = db.EnFazlaKitapYazar().FirstOrDefault();
            linqKartDto.YayınEviGroup = db.TBLKITAP.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault().Key;
            linqKartDto.IletisimCount = db.TBLILETISIM.Count();
            linqKartDto.AktifOlmayanKitapCount = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            //var deger12 = db.EnFazlaKitapAlan().FirstOrDefault();

            


            //ViewBag.dgr1 = deger1;
            //ViewBag.dgr2 = deger2;
            //ViewBag.dgr3 = deger3;
            //ViewBag.dgr4 = deger4;
            //ViewBag.dgr5 = deger5;
            //ViewBag.dgr8 = deger8;
            //ViewBag.dgr9 = deger9;
            //ViewBag.dgr11 = deger11;
            //ViewBag.dgr12 = deger12;
            return View(linqKartDto);
        }
    }
}