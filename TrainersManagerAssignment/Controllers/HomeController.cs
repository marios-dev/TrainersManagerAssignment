using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainersManagerAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This MVC project was done in a hurry since "+
                "our team assignment is on the way and the foundation's certification"+
                " was right on the corner, thank you for everything <3";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For more info on our Trainers Manager please donate "+
                "or give us your best feedback <3";

            return View();
        }
    }
}