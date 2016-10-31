using Gym_sports_training.Models.Entities.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gym_sports_training.Controllers
{
    public class HomeController : Controller
    {
        private GymDbContext db = new GymDbContext();

        // GET: TrainingSessions
        public async Task<ActionResult> Index()
        {
            return View(await db.TrainingSessions.ToListAsync());
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