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
    public class CamberDetailController : Controller
    {
        private TempHumidityEntities1 db = new TempHumidityEntities1();

        // GET: /CamberDetail/
        public ActionResult Index()
        {
            try
            {
                return View(db.ChamberDtls.ToList());
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
        // GET: /CamberDetail/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ChamberDtl chamberdtl = db.ChamberDtls.Find(id);
                if (chamberdtl == null)
                {
                    return HttpNotFound();
                }
                return View(chamberdtl);
            }
            catch 
            {

                return View("Error");
            }
           
        }

        // GET: /CamberDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CamberDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChamberId,ChamberName,Status,Description,Remarks")] ChamberDtl chamberdtl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ChamberDtls.Add(chamberdtl);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(chamberdtl);
            }
            catch
            {

                return View("Error");
            }
           
        }

        // GET: /CamberDetail/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ChamberDtl chamberdtl = db.ChamberDtls.Find(id);
                if (chamberdtl == null)
                {
                    return HttpNotFound();
                }
                return View(chamberdtl);
            }
            catch 
            {

                return View("Error");
            }
           
        }

        // POST: /CamberDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChamberId,ChamberName,Status,Description,Remarks")] ChamberDtl chamberdtl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chamberdtl).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(chamberdtl);
            }
            catch 
            {

                return View("Error");
            }
          
        }

        // GET: /CamberDetail/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ChamberDtl chamberdtl = db.ChamberDtls.Find(id);
                if (chamberdtl == null)
                {
                    return HttpNotFound();
                }
                return View(chamberdtl);
            }
            catch 
            {

                return View("Error");
            }
           
        }

        // POST: /CamberDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                ChamberDtl chamberdtl = db.ChamberDtls.Find(id);
                db.ChamberDtls.Remove(chamberdtl);
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
