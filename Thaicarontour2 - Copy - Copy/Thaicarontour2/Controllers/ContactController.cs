using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Thaicarontour2.Models;
using System.Data.Entity.Validation;

namespace Thaicarontour2.Controllers
{
    public class ContactController : Controller
    {

        private db_ctotEntities db = new db_ctotEntities();
        
        // GET: Contact
        public ActionResult DU_Contact(Contact contact)
        {
          //  Contact contactD = new Contact();   
            string Name_contact = Request.Form["Name"];
            string Email_contact = Request.Form["Email"];
            string Tel_contact = Request.Form["Tel"];
            string Subject_contact = Request.Form["Subject"];
            string Message_contact = Request.Form["Message"];

            if (ModelState.IsValid)
            {
                if (Email_contact != null)
                    
                { 

                    var check = db.Users.Where(a => a.Email.Equals(Email_contact));
                    //var check = db.Contacts.Where()

                    if (check == null)
                    {
                        ViewBag.Message = "กรุณาสมัครสมาชิก";
                        return View();
                    }
                    else
                    {
                        try
                        {
                            db.Contacts.SqlQuery("insert into Contacts(Name,Email,Tel,Subject,Area,Message) values ('Name_contact','Email_contact','Tel_contact','Subject_contact','Message_contact')");
                            db.Contacts.Add(contact);
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
            return View();
        }
    }
}