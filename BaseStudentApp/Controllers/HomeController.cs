using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseStudentApp.Models;
using BaseStudentApp.ViewModel;


namespace BaseStudentApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Podaci()
        {
            List<StudentIspitModel> fullLista = new List<StudentIspitModel>();
            using (StudentDBEntities dbCtx = new StudentDBEntities())
            {
                var list = (from p in dbCtx.Ispiti
                            join s in dbCtx.Studenti
                            on p.BiSt equals s.BiStudent
                            select new
                            {
                                s.IdStudent,
                                s.BiStudent,
                                s.sName,
                                s.sLastname,
                                s.City,
                                p.Id,
                                p.BiSt,
                                p.Ocena,
                                p.Predmet
                            }).ToList();
                foreach(var item in list)
                {
                    fullLista.Add(new StudentIspitModel(item.IdStudent,item.BiStudent, item.sName, item.sLastname, item.City, item.Id, item.Predmet, item.Ocena, item.BiSt));
                }
              
            }

                return View(fullLista);
        }
        public ActionResult List()
        {
            List<IspitiStudenataVM> sviIspiti = new List<IspitiStudenataVM>();
            //using (StudentDBEntities st = new StudentDBEntities())
            //{
            //    var s = st.Studenti.OrderByDescending(a => a.IdStudent);
            //    foreach (var i in s)
            //    {
            //        var sviIspitiStudenata = st.Ispiti.Where(a => a.BiSt.Equals(i.BiStudent)).ToList();
            //        sviIspiti.Add(new IspitiStudenataVM { Ispiti = sviIspitiStudenata, Studenti = s });
            //    }
            //}
            return View(sviIspiti);
        }


        //public ActionResult FullList()
        //{

        //    List<IspitiStudenataVM> ispitiStudenata = new List<IspitiStudenataVM>();
        //    using (StudentDBEntities db = new StudentDBEntities())
        //    {
        //        var studenti = db.Studenti.ToList();
        //        var ispiti = db.Ispiti.ToList();
        //        var mixModel = new IspitiStudenataVM
        //        {
        //            Studenti =  studenti,
        //            Ispiti = ispiti
        //        };
        //        return View(mixModel);
        //        //foreach(var i in studenti)
        //{
        //    var detaljiIspita = db.Ispiti.Where(a => a.BiSt == (i.BiStudent)).ToList();
        //    ispitiStudenata.Add(new IspitiStudenataVM { Studenti = i, Ispiti = detaljiIspita });
        //}
        //}
        //return View(ispitiStudenata);
        //   }
        //}
    }
}