using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Thaicarontour2.Models;

namespace Thaicarontour2.Controllers
{
    public class CartypeController : Controller
    {
        db_ctotEntities db = new db_ctotEntities();
        // GET: Cartype
        public ActionResult cartype()
        {
            var email = this.Session["Email"];

            User profile = db.Users.Find(email);
            if (profile == null)
            {
                //MessageBox.Show("กรุณาสมัครสมาชิก");
                return RedirectToAction("Index", "Index");
            }
            return View();
        }
    }
}