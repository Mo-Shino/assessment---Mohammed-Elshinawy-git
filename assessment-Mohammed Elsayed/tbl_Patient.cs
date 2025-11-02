using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_Mohammed_Elsayed
{
    internal class tbl_Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string Notes { get; set; }
    }
}
