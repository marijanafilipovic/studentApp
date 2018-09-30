using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseStudentApp.Models;

namespace BaseStudentApp.ViewModel
{   
    public class IspitiStudenataVM
    {


        //internal Student Sudent;
        public Student Studenti { get; set; }
        public List<Ispit> Ispiti { get; set; }
        //public IspitiStudenataVM(int IdStudent, string BiStudent, string sName, string sLastname, string City, int Id, string BiSt, string Predmet, string Ocena)
        //{
        //    BiStudent = BiSt;
        //}

        


    }

    //    public List<Student> listaStudenti()
    //    {
    //        List<Student> studenti = new List<Student>();
    //        return (studenti);
    //    }

}