using Microsoft.AspNetCore.Mvc;
using ObsUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObsUygulaması.Controllers
{
    public class HomeController : Controller
    {
        private obssaEntities db = new obssaEntities();


        public ActionResult Index()
        {
            return RedirectToAction("/AnaGiris");
        }
        

        public ActionResult AdminInfo()
        {
            return View();
        }

        public ActionResult YeniKayıt()
        {
            return View();
        }
              
        public ActionResult DersEkle()
        {
            return View();
        }
        public ActionResult AnaGiris()
        {
            return View();
        }
        public ActionResult DersListele()
        {
            return View(db.Ders.ToList());
        }
        public ActionResult NotListele()
        {
            return View(db.Not.ToList());
        }
        public ActionResult OgrenciListele()
        {
            return View(db.Ogrenci.ToList());
        }
        public ActionResult OgrenciDuyuruListele()
        {
            return View(db.Duyuru.ToList());
        }

        public ActionResult GetOgrenciAdSoyad(int ogrenciId)
        {
            using (var context = new obssaEntities())
            {
                var ogrenci = context.Ogrenci.FirstOrDefault(o => o.Id == ogrenciId);
                if (ogrenci != null)
                {
                    return Json(ogrenci.AdSoyad, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult OgrenciDersGetir()
        {
            // Session'dan öğrenci numarasını al
            var OgrNo = Session["OgrenciNo"] as string;

            if (OgrNo != null)
            {
                using (var context = new obssaEntities())
                {
                    var student = context.Ogrenci.FirstOrDefault(s => s.No == OgrNo);
                    if (student != null)
                    {
                        var dersler = context.Not
                                             .Where(n => n.OgrId == student.Id)
                                             .Select(n => n.Ders)
                                             .ToList();

                        var viewModel = new OgrenciDersViewModel
                        {
                            Ogrenci = student,
                            Dersler = dersler
                        };

                        return View(viewModel);
                    }
                }
            }

            ViewBag.ErrorMessage = "Öğrenci bilgileri alınamadı.";
            return View();
        }
        public ActionResult OgrenciBilgileri()
        {
            // Session'dan öğrenci numarasını al
            var OgrNo = Session["OgrenciNo"] as string;

            if (OgrNo != null)
            {
                // Öğrenci numarasını kullanarak öğrenci bilgilerini veritabanından al
                using (var context = new obssaEntities())
                {
                    var student = context.Ogrenci.FirstOrDefault(s => s.No == OgrNo);
                    if (student != null)
                    {
                        return View(student);
                    }
                }
            }

            // Öğrenci bilgileri bulunamazsa veya hata oluşursa, hata mesajı gösterme
            ViewBag.ErrorMessage = "Öğrenci bilgileri alınamadı.";
            return View();
        }
        public ActionResult StudentInfo()
        {
            // Session'dan öğrenci numarasını al
            var OgrNo = Session["OgrenciNo"] as string;

            if (OgrNo != null)
            {
                // Öğrenci numarasını kullanarak öğrenci bilgilerini veritabanından al
                using (var context = new obssaEntities())
                {
                    var student = context.Ogrenci.FirstOrDefault(s => s.No == OgrNo);
                    if (student != null)
                    {
                        return View(student);
                    }
                }
            }

            // Öğrenci bilgileri bulunamazsa veya hata oluşursa, hata mesajı gösterme
            ViewBag.ErrorMessage = "Öğrenci bilgileri alınamadı.";
            return View();
        }


        public ActionResult OgrenciGiris()
        {

            return View(db.Duyuru.ToList());
        }

        public ActionResult OgrenciNotGetir()
        {
            // Session'dan öğrenci numarasını al
            var OgrNo = Session["OgrenciNo"] as string;

            if (OgrNo != null)
            {
                // Öğrenci numarasını kullanarak öğrenci bilgilerini ve notlarını veritabanından al
                using (var context = new obssaEntities())
                {
                    var student = context.Ogrenci.FirstOrDefault(s => s.No == OgrNo);
                    if (student != null)
                    {
                        var notlar = context.Not
                                   .Where(n => n.OgrId == student.Id)
                                   .Include(n => n.Ders) // Ders ilişkili verisini sorguya dahil et
                                    .ToList();

                        var viewModel = new OgrenciNotViewModel
                        {
                            Ogrenci = student,
                            Notlar = notlar
                        };

                        return View(viewModel);
                    }
                }
            }

            // Öğrenci bilgileri bulunamazsa veya hata oluşursa, hata mesajı gösterme
            ViewBag.ErrorMessage = "Öğrenci bilgileri alınamadı.";
            return View();
        }
    }
}