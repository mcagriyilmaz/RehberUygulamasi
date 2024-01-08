using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RehberUygulamasi.Models;
using System.Diagnostics;


namespace RehberUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RehberContext context = new RehberContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            var degerler = context.rehbers.ToList();
            return View(degerler);
           
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult KullaniciEkle(Rehber rehber)
        {
            if(rehber.Id!= null && rehber.Ad!= null)
            {
                context.rehbers.Add(rehber);
                context.SaveChanges();
                TempData["success"] = " Başarılı Bir Şekilde Kişi Eklendi";
            }
            else
                return View();
            

            return RedirectToAction("KullaniciGuncelle");
        }
        
        public IActionResult KullaniciSil(int id )
        {
            var reh = context.rehbers.Find(id);
            context.rehbers.Remove(reh);
            context.SaveChanges();
            TempData["success"] = "Başarılı Bir Şekilde Kişi Silindi";
            return RedirectToAction("KullaniciGuncelle");
        }
        
        public IActionResult KullaniciGetir(int id)
        {
            var getir = context.rehbers.Find(id);
            return View("KullaniciGetir", getir);
        }
        public IActionResult KullaniciGuncelle()
        {
            var degerler = context.rehbers.ToList();
            return View(degerler);
            TempData["success"] = "Rehberdeki Kişi Başarılı Bir Şekilde Güncellendi";
        }
        public IActionResult RehberGuncelle(Rehber r)
        {
            var reh = context.rehbers.Find(r.Id);
            
            reh.Ad = r.Ad;
            reh.Soyad= r.Soyad;
            reh.TelefonNumarasi= r.TelefonNumarasi;
            reh.Mail= r.Mail;
            reh.Adres=  r.Adres;
            reh.DogumTarih= r.DogumTarih;
            reh.Hakkinda= r.Hakkinda;
            context.SaveChanges();
            return RedirectToAction("KullaniciGuncelle");
            TempData["success"] = "Rehbere Kişi Başarılı Bir Şekilde Güncellendi";

        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}