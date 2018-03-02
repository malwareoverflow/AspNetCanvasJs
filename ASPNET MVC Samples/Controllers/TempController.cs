using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNET_MVC_Samples;

namespace ASPNET_MVC_Samples.Controllers
{
    public class TempController : Controller
    {
        private TempHumidityEntities1 db = new TempHumidityEntities1();

        // GET: /Temp/
        public ActionResult Index()
        {
            return View(db.Temps.ToList());
        }

        // GET: /Temp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // GET: /Temp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Temp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChamberName,CurTemp,SetTemp,Status,Remarks,id")] Temp temp)
        {
            temp.TimeStamp = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Temps.Add(temp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temp);
        }

        // GET: /Temp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // POST: /Temp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChamberName,CurTemp,SetTemp,TimeStamp,Status,Remarks,id")] Temp temp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temp);
        }

        // GET: /Temp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // POST: /Temp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temp temp = db.Temps.Find(id);
            db.Temps.Remove(temp);
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
