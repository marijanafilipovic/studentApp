//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BaseStudentApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Table("Ispit")]
    public partial class Ispit
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("BI")]
        public string BiSt { get; set; }
        [DisplayName("Predmet")]
        public string Predmet { get; set; }
        [DisplayName("Ocena")]
        public string Ocena { get; set; }
    }
}
