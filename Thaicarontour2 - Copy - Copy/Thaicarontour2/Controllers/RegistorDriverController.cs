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

    public class RegistorDriverController : Controller
    {
        private db_ctotEntities db = new db_ctotEntities();

        // GET: RegistorDriver
        public ActionResult RegistorDriver(Driver driver)
        {

            string Name_driver = Request.Form["Name"];
            string Email_driver = Request.Form["Email"];
            string Password_driver = Request.Form["Password"];
            string ConfirmPassword = Request.Form["ConfirmPassword"];
            string Tel_driver = Request.Form["Tel"];
            string Passport_driver = Request.Form["Passport"];
            string House_number_driver = Request.Form["House_number"];
            string District_driver = Request.Form["District"];
            string Area_driver = Request.Form["Area"];
            string province_driver = Request.Form["province"];
            string Codeid_driver = Request.Form["Codeid"];

            if (ModelState.IsValid)
            {
                if (Email_driver != null)
                {
                    var check = db.Drivers.Where(a => a.Email.Equals(Email_driver)).FirstOrDefault<Driver>();
                    if (check != null)
                    {
                        ViewBag.Message = "Emailนี้มีผู้ใช้แล้ว";
                        MessageBox.Show ("Email นี้มีผู้ใช้แล้ว");
                        
                        return View();
                    }
                    else
                    {
                        try
                        {
                            db.Drivers.SqlQuery("insert into Users(Name,Email,Password,Tel,Passport,House_number,District,Area,province,Codeid) values ('Name_driver','Email_driver','Password_driver','Tel_driver','Passport_driver','House_number_driver','District_driver','Area_driver','province_driver','Codeid_driver')");
                            db.Drivers.Add(driver);
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
        



    }
}