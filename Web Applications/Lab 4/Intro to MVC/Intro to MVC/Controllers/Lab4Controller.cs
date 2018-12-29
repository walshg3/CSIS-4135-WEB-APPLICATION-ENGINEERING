using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaffleGenerator;



namespace Intro_to_MVC.Controllers
{
    public class Lab4Controller : Controller
    {
        public IActionResult Index()
        {
            ViewData["TimePhrase"] = GetTimeDisplay();

            return View("Index");
        }
        public IActionResult Waffles(){
            ViewData["TimePhrase"] = GetTimeDisplay();

            return View("Waffles");
        }
        public string GetTimeDisplay()
        {
            if (DateTime.Now.Hour < 12)
            {
                return "Good Morning";
            }
            else if (DateTime.Now.Hour < 18)
            {
                return "Good Afternoon";
            }
            else
            {
                return "Good Evening";
            }
        }



    }
}