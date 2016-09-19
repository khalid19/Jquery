using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxJqueryJsonSample.DAL;
using AjaxJqueryJsonSample.Model;


namespace AjaxJqueryJsonSample.Controllers
{
    
    public class ContactController : Controller
    {
        private PersonalInformationDbContext db=new PersonalInformationDbContext();
        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetContacts()
        {
            //List<Contact> all = db.Contacts.Include(x => x.Country).Include(x => x.State).ToList();

            List<Contact> all = null;

            using (PersonalInformationDbContext db = new PersonalInformationDbContext())
            {
                var contacts = (from a in db.Contacts
                                join b in db.Countries on a.CountryId equals b.CountryId
                                join c in db.States on a.StateId equals c.StateId
                                select new
                                {
                                    a,
                                    b.CountryName,
                                    c.StateName


                                });

                if (contacts != null)
                {
                    all = new List<Contact>();

                    foreach (var i in contacts)
                    {


                         Contact con = i.a;
                        con.StateName = i.StateName;
                        con.CountryName = i.CountryName;
                        
                        
                      
                        all.Add(con);

                    }
                }





            }

            return new JsonResult { Data = all, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            //return Json(all, JsonRequestBehavior.AllowGet);
        }
        private List<Country> GetCountry()
        {
            using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
            {
                return dc.Countries.OrderBy(a => a.CountryName).ToList();
            }
        }

        //Fetch State from database
        private List<State> GetState(int countryID)
        {
            using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
            {
                return dc.States.Where(a => a.CountryId.Equals(countryID)).OrderBy(a => a.StateName).ToList();
            }
        }

        //return states as json data
        public JsonResult GetStateList(int countryID)
        {
            using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
            {
                return new JsonResult { Data = GetState(countryID), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Get contact by ID
        public Contact GetContact(int contactID)
        {
            Contact contact = null;
            using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
            {
                var v = (from a in dc.Contacts
                         join b in dc.Countries on a.CountryId equals b.CountryId
                         join c in dc.States on a.StateId equals c.StateId
                         where a.CountryId.Equals(contactID)
                         select new
                         {
                             a,
                             b.CountryName,
                             c.StateName
                         }).FirstOrDefault();
                if (v != null)
                {
                    contact = v.a;
                    contact.CountryName = v.CountryName;
                    contact.StateName = v.StateName;
                }
                return contact;
            }
        }


        public ActionResult Save(int id = 0)
        {
            List<Country> Country = GetCountry();
            List<State> States = new List<State>();

            if (id > 0)
            {
                var c = GetContact(id);
                if (c != null)
                {
                    ViewBag.Countries = new SelectList(Country, "CountryId", "CountryName", c.CountryId);
                    ViewBag.States = new SelectList(GetState(c.CountryId), "StateId", "StateName", c.StateId);
                }
                else
                {
                    return HttpNotFound();
                }
                return PartialView("Save", c);
            }
            else
            {
                ViewBag.Countries = new SelectList(Country, "CountryId", "CountryName");
                ViewBag.States = new SelectList(States, "StateId", "StateName");
                return PartialView("Save");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Contact c)
        {
            string message = "";
            bool status = false;
            if (ModelState.IsValid)
            {
                using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
                {
                    if (c.CountryId > 0)
                    {
                        var v = dc.Contacts.Where(a => a.ContactId.Equals(c.ContactId)).FirstOrDefault();
                        if (v != null)
                        {
                            v.ContactPerson = c.ContactPerson;
                            v.ContactNo = c.ContactNo;
                            v.CountryId = c.CountryId;
                            v.StateId = c.StateId;
                        }
                        else
                        {
                            return HttpNotFound();
                        }
                    }
                    else
                    {
                        dc.Contacts.Add(c);
                    }
                    dc.SaveChanges();
                    status = true;
                    message = "Successfully Saved.";
                }
            }
            else
            {
                message = "Error! Please try again.";
            }

            return new JsonResult { Data = new { status = status, message = message } };
        }

        public ActionResult Delete(int id)
        {
            var c = GetContact(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return PartialView(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteContact(int id)
        {
            bool status = false;
            string message = "";
            using (PersonalInformationDbContext dc = new PersonalInformationDbContext())
            {
                var v = dc.Contacts.Where(a => a.ContactId.Equals(id)).FirstOrDefault();
                if (v != null)
                {
                    dc.Contacts.Remove(v);
                    dc.SaveChanges();
                    status = true;
                    message = "Successfully Deleted!";
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return new JsonResult { Data = new { status = status, message = message } };
        }
	}
}