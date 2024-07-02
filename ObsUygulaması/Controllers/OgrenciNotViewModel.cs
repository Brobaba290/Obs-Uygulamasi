using ObsUygulaması.Models;
using System.Collections.Generic;

namespace ObsUygulaması.Controllers
{
    public class OgrenciNotViewModel
    {
        public Ogrenci Ogrenci { get; set; }
        public List<Not> Notlar { get; set; }
    }
}