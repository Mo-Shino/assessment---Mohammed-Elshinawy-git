using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_Mohammed_Elsayed
{
    internal class tbl_attributes
    {
        [Key]
        public int AppointmentID { get; set; }
        public string DateTime { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }


        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public tbl_User tbl_User { get; set; }


        public int PatientID { get; set; }
        [ForeignKey(nameof(PatientID))]
        public tbl_Patient tbl_Patient { get; set; }
    }
}
