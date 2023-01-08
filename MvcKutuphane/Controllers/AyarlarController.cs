﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kullanicilar = db.TBLADMIN.ToList();
            return View(kullanicilar);
        }
        public ActionResult Index2()
        {
            var kullanicilar = db.TBLADMIN.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN t)
        {
            db.TBLADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var adminsil = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(adminsil);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var adm = db.TBLADMIN.Find(id);
            return View("AdminGuncelle",adm);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN p)
        {
            var adm = db.TBLADMIN.Find(p.ID);
            adm.Kullanici = p.Kullanici;
            adm.Sifre = p.Sifre;
            adm.Yetki = p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}