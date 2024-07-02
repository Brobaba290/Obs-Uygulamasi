using ObsUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObsUygulaması.Controllers
{
    public class OgrenciDersViewModel
    {
        public Ogrenci Ogrenci { get; set; }
        public List<Ders> Dersler { get; set; }
    }
}