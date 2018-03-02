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
    public class HumidityController : Controller
    {
        private TempHumidityEntities1 db = new TempHumidityEntities1();

        // GET: /Humidity/
        public ActionResult Index()
        {
            try
            {
                return View(db.Humidities.ToList());
            }
            catch 
            {
                return View("Error");
                
            }
 
        }
        public ActionResult ErrorPage()
        {
            return View();
        }
        // GET: /Humidity/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Humidity humidity = db.Humidities.Find(id);
                if (humidity == null)
                {
                    return HttpNotFound();
                }
                return View(humidity);
            }
            catch
            {
                
                 return View("Error");
            }
            
        }

        // GET: /Humidity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Humidity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChamberName,CurHumidity,SetHumidity,Status,Remarks,id")] Humidity humidity)
        {
            try
            {
                humidity.TimeStamp = DateTime.Now.Date;
                if (ModelState.IsValid)
                {
                    db.Humidities.Add(humidity);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(humidity);
            }
            catch 
            {

                return View("Error");
            }
           
        }

        // GET: /Humidity/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Humidity humidity = db.Humidities.Find(id);
                if (humidity == null)
                {
                    return HttpNotFound();
                }
                return View(humidity);
            }
            catch 
            {

                return View("Error");
            }
          
        }

        // POST: /Humidity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChamberName,CurHumidity,SetHumidity,TimeStamp,Status,Remarks,id")] Humidity humidity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(humidity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(humidity);
            }
            catch
            {

                return View("Error");
            }
           
        }

        // GET: /Humidity/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Humidity humidity = db.Humidities.Find(id);
                if (humidity == null)
                {
                    return HttpNotFound();
                }
                return View(humidity);
            }
            catch 
            {

                return View("Error");
            }
            
        }

        // POST: /Humidity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Humidity humidity = db.Humidities.Find(id);
                db.Humidities.Remove(humidity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

                return View("Error");
            }
           
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
