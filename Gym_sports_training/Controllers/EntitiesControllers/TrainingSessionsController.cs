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

namespace Gym_sports_training.Controllers.EntitiesControllers
{
    public class TrainingSessionsController : Controller
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

        //public ActionResult Index(string timeOrder)
        //{
        //    var trainingSessions = db.TrainingSessions.Include(t => t.Client).Include(t => t.Coach);
        //    var sortedTrainings = from s in trainingSessions
        //                          select s;

        //    sortedTrainings = sortedTrainings.OrderBy(s => s.TrainingTimeStart);
        //    ViewBag.DateSortParm = sortedTrainings.OrderByDescending(s => s.TrainingTimeStart);
        //    return View(sortedTrainings.ToList());
        //}

        // GET: TrainingSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            return View(trainingSession);
        }

        // GET: TrainingSessions/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.CoachId = new SelectList(db.Coaches, "Id", "Name");
            return View();
        }

        // POST: TrainingSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,CoachId,TrainingTimeStart")] TrainingSession trainingSession)
        {
            if (ModelState.IsValid)
            {
                db.TrainingSessions.Add(trainingSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", trainingSession.ClientId);
            ViewBag.CoachId = new SelectList(db.Coaches, "Id", "Name", trainingSession.CoachId);
            return View(trainingSession);
        }

        // GET: TrainingSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", trainingSession.ClientId);
            ViewBag.CoachId = new SelectList(db.Coaches, "Id", "Name", trainingSession.CoachId);
            return View(trainingSession);
        }

        // POST: TrainingSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,CoachId,TrainingTimeStart")] TrainingSession trainingSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", trainingSession.ClientId);
            ViewBag.CoachId = new SelectList(db.Coaches, "Id", "Name", trainingSession.CoachId);
            return View(trainingSession);
        }

        // GET: TrainingSessions/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            return View(trainingSession);
        }

        // POST: TrainingSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TrainingSession trainingSession = db.TrainingSessions.Find(id);
                db.TrainingSessions.Remove(trainingSession);
                db.SaveChanges();
            }
            catch
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
