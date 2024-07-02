using ObsUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObsUygulaması.Controllers
{
    public class LoginController : Controller
    {
        private obssaEntities db = new obssaEntities();
        // GET: Login
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult StudentLogin()
        {
            return View();
        }
        public ActionResult AnaGiris()
        {
            return View();
        }
       

        

        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
            using (var context = new obssaEntities())
            {
                var student = context.Admin.FirstOrDefault(s => s.Username == username && s.Password == password);
                if (student != null)
                {
                    Session["OgrenciNo"] = username;

                    return RedirectToAction("AdminInfo", "Home");
                }
                else
                {
                    return RedirectToAction("AnaGiris", "Home");
                }
            }

            //Kullanıcı bulunamadı veya şifre geçersiz, hata mesajı gösterme
            ViewBag.ErrorMessage = "Kullanıcı bulunamadı veya şifre geçersiz. Lütfen doğru ad ve soyad giriniz.";
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(string OgrNo, string password)
        {
            using (var context = new obssaEntities())
            {
                var student = context.Ogrenci.FirstOrDefault(s => s.No == OgrNo && s.Sifre == password);
                if (student != null)
                {
                    Session["OgrenciNo"] = OgrNo;

                    return RedirectToAction("OgrenciGiris", "Home");
                }
                else
                {
                    return RedirectToAction("AnaGiris", "Home");
                }
            }

            //Kullanıcı bulunamadı veya şifre geçersiz, hata mesajı gösterme
            ViewBag.ErrorMessage = "Kullanıcı bulunamadı veya şifre geçersiz. Lütfen doğru ad ve soyad giriniz.";
            return View();
        }

       
        

    }
}