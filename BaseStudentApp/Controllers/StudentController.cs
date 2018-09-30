using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseStudentApp.Models;
using BaseStudentApp.Repository;

namespace BaseStudentApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult getStudent()
        {
            StudentRepository StudRep = new StudentRepository();
            ModelState.Clear();
            return View(StudRep.getStudent());
        }

        // GET: Student/Details/5
        public ActionResult Details(int IdStudent)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult addStudent()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult addStudent(Student Student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentRepository studRepo = new StudentRepository();
                    if (studRepo.addStudent(Student))
                    {
                        ViewBag.Message = "Dodali ste sutedenta.";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult UpdateStudentDetails(int? id)
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = db.Studenti.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            //  StudentRepository StudRepo = new StudentRepository();

            // return View(StudRepo.getStudent().Find(Student => Student.IdStudent == IdStudent));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult UpdateStudentDetails(int IdStudent, Student obj)
        {
            try
            {
                StudentRepository StudRepo = new StudentRepository();
                StudRepo.UpdateStudent(obj);
                return RedirectToAction("getStudent");
            }
            catch
            {
                return View();
            }
        }


        // GET: Ispit/Delete/5
        public ActionResult Delete(int? id)
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Student student = db.Studenti.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
           
        }
        // POST: Ispit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                Student student = db.Studenti.Find(id);
                db.Studenti.Remove(student);
                db.SaveChanges();
            }
            return RedirectToAction("getStudent");
        }
      

    }

}

