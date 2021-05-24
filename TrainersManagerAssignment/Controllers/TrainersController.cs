using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainersManagerAssignment.DAL;
using TrainersManagerAssignment.Models;
using System.Data.Entity.Infrastructure;

namespace TrainersManagerAssignment.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trainers
        public ViewResult Index(string sortOrder,string searchString)
        {
            ViewBag.FNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName" : "";
            ViewBag.LNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
            ViewBag.SubjectSortParm = String.IsNullOrEmpty(sortOrder) ? "Subject" : "";
            var trainers = from t in db.Trainers
                           select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainers = trainers.Where(t => t.LastName.Contains(searchString)
                                          || t.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "FirstName":
                    trainers = trainers.OrderByDescending(t => t.FirstName);
                    break;
                case "LastName":
                   trainers = trainers.OrderBy(t => t.LastName);
                    break;
                case "Subject":
                    trainers = trainers.OrderByDescending(t => t.Subject);
                    break;
                default:
                    trainers = trainers.OrderBy(t => t.FirstName);
                    break;
            }
            return View(trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Subject")] Trainer trainer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainers.Add(trainer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please Try again");
            }

            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainerToUpdate = db.Trainers.Find(id);
            if (TryUpdateModel(trainerToUpdate, "",
                new string[] { "FirstName", "LastName", "Subject" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes.Please try again");
                }
            }
            return View(trainerToUpdate);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id,bool?saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.Please try again.";
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Trainer trainer = db.Trainers.Find(id);
                db.Trainers.Remove(trainer);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
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
