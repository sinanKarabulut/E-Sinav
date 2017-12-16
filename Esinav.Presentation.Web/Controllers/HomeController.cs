using Esinav.Application.Location;
using Esinav.Domain.Location.Entity;
using Esinav.Domain.Location.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Esinav.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private IServiceCRUDSehir _sehirCRUDService;
        private IServiceCRUDIlce _ilceCRUDService;
        public HomeController(IServiceCRUDSehir sehirCRUDService,IServiceCRUDIlce ilceCRUDService)
        {
            this._sehirCRUDService = sehirCRUDService;
            this._ilceCRUDService = ilceCRUDService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SehirKaydet()
        {
            Sehir sehir = _sehirCRUDService.CreateNew();
            sehir.Sehir_Adi = "Ankara";
            _sehirCRUDService.Insert(sehir);
            return View();
        }
    }
}