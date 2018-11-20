using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum veniam culpa eum deleniti, voluptates perspiciatis? Nisi eveniet et enim nulla ipsa, voluptatibus fugiat harum assumenda! Aperiam perferendis provident soluta praesentium?.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum veniam culpa eum deleniti, voluptates perspiciatis? Nisi eveniet et enim nulla ipsa, voluptatibus fugiat harum assumenda! Aperiam perferendis provident soluta praesentium?.";

            return View();
        }
    }
}