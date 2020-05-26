using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationProject.DATA.EF;
using System.IO;

namespace ReservationProject.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OwnerAssestsController : Controller
    {
        private Reservation_SystemEntities db = new Reservation_SystemEntities();

        // GET: OwnerAssests
        public ActionResult Index()
        {
            var ownerAssests = db.OwnerAssests.Include(o => o.UserDetail);
            return View(ownerAssests.ToList());
        }

        // GET: OwnerAssests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerAssest ownerAssest = db.OwnerAssests.Find(id);
            if (ownerAssest == null)
            {
                return HttpNotFound();
            }
            return View(ownerAssest);
            //Testing get hub
        }

        // GET: OwnerAssests/Create
        public ActionResult Create()
        {
            

            ViewBag.OwnerID = new SelectList(db.UserDetails, "UserID", "UserID");
            return View();
    

        }

        // POST: OwnerAssests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerAssetID,AssetName,OwnerID,AssetPhoto,Notes,IsActive,DateAdded")] OwnerAssest ownerAssest, HttpPostedFileBase Images)
        {

            if (ModelState.IsValid)
            {
                string imageName = "noImage.png";
                if (Images != null)
                {
                    imageName = Images.FileName;
                    string ext = imageName.Substring(imageName.LastIndexOf('.'));
                    string[] goodExts = { ".jpg", ".jpeg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()))
                    {
                        Images.SaveAs(Server.MapPath("~/Content/img/" + imageName));
                    }
                    else
                    {
                        imageName = "noImage.png";
                    }

                }
                ownerAssest.AssetPhoto = imageName;




                ownerAssest.DateAdded = DateTime.Now;
                db.OwnerAssests.Add(ownerAssest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.UserDetails, "UserID", "UserID", ownerAssest.OwnerID);
            return View(ownerAssest);
        }

        // GET: OwnerAssests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerAssest ownerAssest = db.OwnerAssests.Find(id);
            if (ownerAssest == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.UserDetails, "UserID", "UserID", ownerAssest.OwnerID);
            return View(ownerAssest);
        }

        // POST: OwnerAssests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerAssetID,AssetName,OwnerID,AssetPhoto,Notes,IsActive,DateAdded")] OwnerAssest ownerAssest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerAssest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.UserDetails, "UserID", "UserID", ownerAssest.OwnerID);
            return View(ownerAssest);
        }

        // GET: OwnerAssests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerAssest ownerAssest = db.OwnerAssests.Find(id);
            if (ownerAssest == null)
            {
                return HttpNotFound();
            }
            return View(ownerAssest);
        }

        // POST: OwnerAssests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnerAssest ownerAssest = db.OwnerAssests.Find(id);
            db.OwnerAssests.Remove(ownerAssest);
            db.SaveChanges();
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
