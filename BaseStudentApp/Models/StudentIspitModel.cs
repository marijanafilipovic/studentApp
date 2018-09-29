namespace BaseStudentApp.Models
{
    using System;
    using System.Collections.Generic;

    public class StudentIspitModel
    {
        public int IdStudent { get; set; }
        public string BiStudent { get; set; }
        public string sName { get; set; }
        public string sLastname { get; set; }
        public string City { get; set; }
        public int Id { get; set; }
        public string BiSt { get; set; }
        public string Predmet { get; set; }
        public string Ocena { get; set; }

        public StudentIspitModel(int IdStudent, string BiStudent, string sName, string sLastname, string City, int Id, string BiSt, string Predmet, string Ocena)
        {
            BiStudent = BiSt;
        }


    }
}