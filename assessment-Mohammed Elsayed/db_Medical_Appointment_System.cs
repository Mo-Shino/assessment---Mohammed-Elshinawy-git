using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment_Mohammed_Elsayed
{
    internal class db_Medical_Appointment_System : DbContext
    {
        public DbSet <tbl_User> tbl_User {  get; set; }
        public DbSet <tbl_Patient> tbl_Patient {  get; set; }
        public DbSet <tbl_attributes> tbl_attributes {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM172-LAB3\\SQLEXPRESS;Initial Catalog=db_Medical_Appointment_System;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
