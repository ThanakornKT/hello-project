using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thaicarontour2.Models;

namespace Thaicarontour2.Controllers
{

    public class EditprofileController : Controller
    {
        private db_ctotEntities db = new db_ctotEntities();

        // GET: Editprofile
        public ActionResult Editprofile()
        {
            var email = this.Session["Email"];

            User profile = db.Users.Find(email);
            if (profile == null)
            {
                //MessageBox.Show("กรุณาสมัครสมาชิก");
                return RedirectToAction("Index", "Index");
            }
            //if (id == 1)
            //{
            //    ViewBag.ok = "OK";
            //    return View(profile);
            //}
            return View(profile);


            //return View();
            
        }
    }
}