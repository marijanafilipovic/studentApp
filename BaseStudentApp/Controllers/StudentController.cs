using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseStudentApp.Repository;
using BaseStudentApp.Models;

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
                if(ModelState.IsValid)
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
        public ActionResult UpdateStudentDetails(int IdStudent)
        {
            StudentRepository StudRepo = new StudentRepository();

            return View(StudRepo.getStudent().Find(Student => Student.IdStudent == IdStudent));
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
        

        // GET: Student/Delete/5
        [HttpGet]
        public ActionResult deleteStudent(int? IdStudent)
        {
            if(IdStudent == null)
            {
                return View();
            }
            StudentRepository Student = new StudentRepository();
            Student.deleteStudent(IdStudent);
            if (Student == null)
            { 
                return ViewBag.Message("Student nepostoji na listi.");
            }
            else
            { 
                return View(Student);
            }
        }
        [HttpPost, ActionName("deleteStudent")]
        public ActionResult delete(int? id)
        {
            
                StudentRepository StudRepo = new StudentRepository();
                if (StudRepo.deleteStudent(id))
                {
                return RedirectToAction("getStudent");

            }
            else
            {
                return RedirectToAction("index");
            }
        }
             }
        
}
