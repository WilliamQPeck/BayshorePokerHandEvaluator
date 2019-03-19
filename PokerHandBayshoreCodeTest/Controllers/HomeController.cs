using PokerHandBayshoreCodeTest.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokerHandBayshoreCodeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HandCheck(string input)
        {
            if(input == null)
            {
                return View();
            }

            var model = new HandCheck(input);

            return View(model);
        }
    }
}