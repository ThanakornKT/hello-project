using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Thaicarontour2.Models;
using System.Data.Entity.Validation;
namespace Thaicarontour2.Controllers
{

    public class RegistorUserController : Controller
    {
        private db_ctotEntities db = new db_ctotEntities();

        // GET: Registor
        public ActionResult RegistorUser(User user)
        {

            string Name_user = Request.Form["Name"];
            string Email_user = Request.Form["Email"];
            string Password_user = Request.Form["Password"];
            string ConfirmPassword = Request.Form["ConfirmPassword"];
            string Tel_user = Request.Form["Tel"];
            string Passport_user = Request.Form["Passport"];
            string House_number_user = Request.Form["House_number"];
            string District_user = Request.Form["District"];
            string Area_user = Request.Form["Area"];
            string province_user = Request.Form["province"];
            string Codeid_user = Request.Form["Codeid"];

            if (ModelState.IsValid)
            {
                if (Email_user != null)
                {
                    var check = db.Users.Where(a => a.Email.Equals(Email_user)).FirstOrDefault<User>();
                    if (check != null)
                    {
                        ViewBag.Message = "Emailนี้มีผู้ใช้แล้ว";
                        return View();
                    }
                    else
                    {
                        try
                        {
                            db.Users.SqlQuery("insert into Users(Name,Email,Password,Tel,Passport,House_number,District,Area,province,Codeid) values ('Name_user','Email_user','Password_user','Tel_user','Passport_user','House_number_user','District_user','Area_user','province_user','Codeid_user')");
                            db.Users.Add(user);
                            db.SaveChanges();
                        }
                        catch (DbEntityValidationException ex)
                        {
                            var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                            var fullErrorMessage = string.Join("; ", errorMessages);
                            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                        }
                    }
                }
            }



            /* String sql = "SELECT * FROM testTable";
             sql = "INSERT INTO tastTable(id,name) VALUES('15','Mark')";
             MySqlConnection conn = new MySqlConnection("host=localhost;user=test;password=123456;database=testDatabase");
             MySqlCommand cmd = new MySqlCommand(sql, conn);
             conn.Open();*/
            return View();
        }

        public ActionResult RegistorDriver()
        {
            return View();
        }
    }
}