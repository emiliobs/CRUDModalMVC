using CRUDModalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDModalMVC.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            return View(db.Students.OrderBy(s=>s.Name).ToList());
        }

        [HttpGet]
        public ActionResult AddEditRecord(int? id)
        {
            var student = db.Students.FirstOrDefault(s => s.StudenId == id);

            if (Request.IsAjaxRequest())
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;

                    return PartialView("_StudentData", student);
                }
            }
            else
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    return PartialView("StudentData", student);
                }
            }
            ViewBag.IsUpdate = false;
            return View("StudentData");
        }

        [HttpPost]
        public ActionResult AddEditRecord(Student student, string cmd)
        {
            var studentId = db.Students.FirstOrDefault(s=>s.StudenId == student.StudenId);

            if (ModelState.IsValid)
            {
                if (cmd == "Save")
                {
                    try
                    {
                        db.Students.Add(student);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch
                    {


                    }
                }
                else
                {
                    try
                    {
                        if (studentId != null)
                        {
                            studentId.Name = student.Name;
                            studentId.Age = student.Age;
                            studentId.Country = student.Country;
                            studentId.State = student.State;
                            db.SaveChanges();
                        }


                        return RedirectToAction("Index");
                    }
                    catch
                    {


                    }

                }


            }


            if (Request.IsAjaxRequest())
            {
                return PartialView("_StudentData", student);
            }
            else
            {
                return View("StudentData", student);
            }

        }

        public ActionResult Details(int Id)
        {

            var student = db.Students.FirstOrDefault(s=>s.StudenId == Id);

            if (student != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_StudentDetails", student);
                }
                else
                {
                    return View("StudenDdetails", student);
                }

            }

            return View("Index");

        }


        public ActionResult DeleteRecord(int id)
        {
            var student = db.Students.FirstOrDefault(s=>s.StudenId == id);

            if (student != null)
            {
                try
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
                catch
                {


                }

            }

            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}