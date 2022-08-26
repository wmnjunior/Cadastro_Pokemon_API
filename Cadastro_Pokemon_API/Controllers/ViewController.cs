using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cadastro_Pokemon_API.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public ActionResult Index()
        {
            ViewBag.Mensagem = "Cadastro Pokemon API/@wmnjunior - GIT";
            return View();
        }
    }
}