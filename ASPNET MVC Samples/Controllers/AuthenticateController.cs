using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Samples.Controllers
{
    public class AuthenticateController : Controller
    {

        private SHELLMVCEntities db = new SHELLMVCEntities();

        // GET: Authenticate
        public ActionResult SignIn()
        {
            ViewBag.Type = new SelectList(db.UserTypes, "Type", "Type");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Include = "User,Password")] UserLogin userLogin)
        {

            var IsUserExist = (from n in db.UserLogins where n.User == userLogin.User && n.Password == userLogin.Password select n).Any();
            if (Convert.ToBoolean(IsUserExist))
            {
                var Usertype = (from n in db.UserLogins where n.User == userLogin.User && n.Password == userLogin.Password select n.Type).FirstOrDefault();

                var UserStation = (from n in db.UserLogins where n.User == userLogin.User && n.Password == userLogin.Password select n.Station).FirstOrDefault();
                Session["UserType"] = Usertype.ToString();
                Session["UserStation"] = UserStation;
                return RedirectToAction("Index", "ViewData");

            }



            return Content("<script language='javascript' type='text/javascript'>alert('Sorry User Not Exist!');</script>");


        }
	}
}