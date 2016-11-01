using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gym_sports_training.DAL;
using Gym_sports_training.Models.Entities;

namespace Gym_sports_training.Controllers
{
    public class HomeController : Controller
    {
        private GymContext db = new GymContext();

        // GET: TrainingSessions
        public ActionResult Index(string sortOrder)
        {
            ViewBag.PhoneSortParm = String.IsNullOrEmpty(sortOrder) ? "phone_desc" : "";
            ViewBag.TrainingStartSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var trainingSessions = db.TrainingSessions.Include(t => t.Client).Include(t => t.Coach);
            switch (sortOrder)
            {
                case "phone_desc":
                    trainingSessions = trainingSessions.OrderByDescending(s => s.Client.PhoneNumber);
                    break;
                case "Date":
                    trainingSessions = trainingSessions.OrderBy(s => s.TrainingTimeStart);
                    break;
                case "date_desc":
                    trainingSessions = trainingSessions.OrderByDescending(s => s.TrainingTimeStart);
                    break;
                default:
                    trainingSessions = trainingSessions.OrderBy(s => s.Client.PhoneNumber);
                    break;
            }
            return View(trainingSessions.ToList());
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
    }
}