using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using Thaicarontour2.Models;
using System.Data.Entity.Validation;
namespace Thaicarontour2.Controllers
{
    
    public class IndexController : Controller
    {
        private db_ctotEntities db = new db_ctotEntities();
        // GET: Register

       /* public ActionResult Index()
        {
            return View();
        }*/

        
        public ActionResult Index()
        {
            User user = new User();
            string Email_user = Request.Form["Email"];
            string Password_user = Request.Form["Password"];

            if (ModelState.IsValid)
            {
                if (Email_user != null & Password_user != null)
                {
                    var check = db.Users.Where(a => a.Email.Equals(Email_user) && a.Password.Equals(Password_user)).FirstOrDefault();

                    if (check != null)
                    {
                        


                        Session["Name"] = check.Name;
                        Session["Email"] = check.Email;
                        Session["Password"] = check.Password;
                        Session["Tel"] = check.Tel;
                        Session["Passport"] = check.Passport;
                        Session["District"] = check.District;
                        Session["Area"] = check.Area;
                        Session["province"] = check.province;
                        Session["Codeid"] = check.Codeid;
                        Session["House_number"] = check.House_number;
                        return RedirectToAction("cartype", "cartype");

                    }
                    else
                    {
                        ViewBag.Message = "อีเมลล์หรือรหัสผ่านไม่ถูกต้อง";
                        return View();
                    }
                }

            }

            //return RedirectToAction("cartype", "cartype");
            return View();
        }
            
        
    }
}



//string Email_user = Request.Form["Email"];
            //string Password_user = Request.Form["Password"];
            //if (ModelState.IsValid)
            //{
            //    if (Email_user != null & Password_user != null)
            //    {
            //        var check = db.Users.Where(a => a.Email.Equals(Email_user) && a.Password.Equals(Password_user)).FirstOrDefault();
            //    }

            //    else
            //    {
            //        ViewBag.Message = "อีเมลล์หรือรหัสผ่านไม่ถูกต้อง";
                  //return View();
//    }


//}

//return RedirectToAction("cartype", "Index");

//string Email_driver = Request.Form["Email"];
//string Password_driver = Request.Form["Password"];
//string sql = "SELECT * FROM User WHERE Email='" + Email_driver + "'AND Password '" + Password_driver + "'";

//var check = db.Drivers.Where(a => a.Email.Equals(Email_driver)).FirstOrDefault<Driver>();
//if (sql != null)
//{
//    MessageBox.Show("ยินดีต้อนรับสู่ Thai Car On Tour");
//}
//else
//{
//    MessageBox.Show("รหัสผ่านไม่ถูกต้อง");
//}

//String sql = "SELECT * FROM register";
//sql = "INSERT INTO register (name,Username, password,tel,email)VALUES ('" + Name_registor + "','" + Username_registor + "','" + Password_registor + "','" + Tel_registor + "','" + Email_registor + "',')";
//MySqlConnection conn = new MySqlConnection("host=localhost;user=test;password=123456;database=carthaiontour");
//MySqlCommand cmd = new MySqlCommand(sql, conn);
//conn.Open();
//cmd.ExecuteNonQuery();
//conn.Close();
