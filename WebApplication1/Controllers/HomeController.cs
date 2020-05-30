using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DataLibrary;
using static DataLibrary.Business_Logic.HoroscopeProcessor;
using Microsoft.Ajax.Utilities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult CalculateHoroscope()
        {
            ViewBag.Message = "Calculate your Horoscope.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculateHoroscope(DateModel model)
        {
            if (ModelState.IsValid)
            {
                int recordscreated = 
                CreateUser(model.Name, model.Gender, model.DateOfBirth);
                return RedirectToAction("ViewUSer");
            }

            return View();
        }

        public ActionResult ViewUSer()
        {
            ViewBag.Message = "UserList";

            var data = LoadHoroscopes();
            List<DateModel> Users = new List<DateModel>();

            foreach (var row in data)
            {
                Users.Add(new DateModel
                {
                    Name = row.Name,
                    DateOfBirth = row.DateOfBirth,
                    Gender = row.Gender,
                    Horoscope = row.Horoscope,
                    prediction = row.prediction

                });
            }

            return View(Users);
        }
    }
}