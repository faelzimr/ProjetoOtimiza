using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Otimiza.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Edit()
        {
            ViewBag.Title = "Editar o Veículo";

            return View();
        }
        public ActionResult Info()
        {
            ViewBag.Title = "Visualizar o Veículo";

            return View();
        }
        public ActionResult New()
        {
            ViewBag.Title = "Novo Veículo";

            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Title = "Galeria de Fotos";

            return View();
        }
    }
}
