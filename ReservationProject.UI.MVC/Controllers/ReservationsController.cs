﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservationProject.DATA.EF;
using Microsoft.AspNet.Identity;
namespace ReservationProject.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin,Customer,Employee")]
    public class ReservationsController : Controller
    {
        private Reservation_SystemEntities db = new Reservation_SystemEntities();

        // GET: Reservations
       
        public ActionResult Index()
        {
            var reservations = db.Reservations.ToList();
            if (User.IsInRole("Customer"))
            {
                string userId = User.Identity.GetUserId();
                reservations = db.Reservations.Where(x => x.OwnerAssest.OwnerID == userId).ToList();
            }
            var locations = db.Locations.Include(l => l.Reservations);
            SelectList list = new SelectList(locations, "LocationID", "City");
            ViewBag.cityName = list;
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
      
        public ActionResult Create()
        {
            string loggedUser = User.Identity.GetUserId();

            var ownerPet = db.OwnerAssests.Where(r => r.OwnerID == loggedUser);
          

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "City", "ReservationMax");

            ViewBag.OwnerAssetID = new SelectList(ownerPet, "OwnerAssetID", "AssetName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,OwnerAssetID,LocationID,ReservationDate,ReservationMax")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                if (db.Reservations.Where(x => x.ReservationDate == reservation.ReservationDate && x.LocationID == reservation.LocationID).Count() < db.Locations.Find(reservation.LocationID).ReservationMax)
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("NoVacancy");     
                }  


            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName","ReservationMax", reservation.LocationID);
            ViewBag.OwnerAssetID = new SelectList(db.OwnerAssests, "OwnerAssetID", "AssetName", reservation.OwnerAssetID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", reservation.LocationID);
            ViewBag.OwnerAssetID = new SelectList(db.OwnerAssests, "OwnerAssetID", "AssetName", reservation.OwnerAssetID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,OwnerAssetID,LocationID,ReservationDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", reservation.LocationID);
            ViewBag.OwnerAssetID = new SelectList(db.OwnerAssests, "OwnerAssetID", "AssetName", reservation.OwnerAssetID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
