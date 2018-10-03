using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BaseStudentApp.Models
{
 
    [Table("Student")]
    public partial class Student
    {
        [DisplayName("ID Studenta")]
        public int IdStudent { get; set; }
        [DisplayName("BI")]
        public string BiStudent { get; set; }
        [DisplayName("Ime")]
        public string sName { get; set; }
        [DisplayName("Prezime")]
        public string sLastname { get; set; }
        [DisplayName("Grad")]
        public string City { get; set; }
        public List<Ispit> ispiti { get; set; }
    }
}
