using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseStudentApp.Models;

namespace BaseStudentApp.ViewModel
{   
    public class IspitiStudenataVM
    {
        public List<Student> Studenti { get; set; }
        public List<Ispit> Ispiti { get; set; }
        


    }

    //    public List<Student> listaStudenti()
    //    {
    //        List<Student> studenti = new List<Student>();
    //        return (studenti);
    //    }

}