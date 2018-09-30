using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseStudentApp.Models;
using BaseStudentApp.ViewModel;
using BaseStudentApp.Repository;
using System.Web.Helpers;
using System.ComponentModel.DataAnnotations;


namespace BaseStudentApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MasterLista()
        {
            List<IspitiStudenataVM> sviIspiti = new List<IspitiStudenataVM>();
            using (StudentDBEntities st = new StudentDBEntities())
            {
              
                var s = st.Studenti.OrderByDescending(a => a.IdStudent).ToList();
                foreach (var i in s)
                {
                     
                    var sviIspitiStudenata = st.Ispiti.Where(a => a.BiSt.Equals(i.BiStudent)).ToList();
                    sviIspiti.Add(new IspitiStudenataVM { Studenti = i, Ispiti = sviIspitiStudenata });
                    
                }
            }
            return View(sviIspiti);
        }


    }

}
