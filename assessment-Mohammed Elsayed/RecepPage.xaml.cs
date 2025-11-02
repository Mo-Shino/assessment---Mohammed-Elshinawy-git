using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace assessment_Mohammed_Elsayed
{
    /// <summary>
    /// Interaction logic for RecepPage.xaml
    /// </summary>
    public partial class RecepPage : Window
    {
        public RecepPage()
        {
            InitializeComponent();
            loud();
        }

        private void loud()
        {
            using (var context = new db_Medical_Appointment_System())
            {
                var hi = context.tbl_attributes.Include(u => u.tbl_Patient)
                    .Select(x => new
                    {
                        Id = x.AppointmentID.ToString(),
                        patientID = x.PatientID.ToString(),
                        patientName = x.tbl_Patient.PatientName,
                        dateTime = x.DateTime,
                        reason = x.Reason,
                        dateOfBirth = x.tbl_Patient.DateOfBirth,
                        phone = x.tbl_Patient.Phone,
                        notes = x.tbl_Patient.Notes,
                        Statue = x.Status,
                    }).ToList();

                RecepDataGrid.ItemsSource = hi;
                
                
                var no = context.tbl_Patient
                    .Select(x => new
                    {
                       id = x.PatientID.ToString(),
                       name = x.PatientName,
                    }).ToList();

                oo.ItemsSource = no;
            }
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("noo");
                return;
            }
            using (var context = new db_Medical_Appointment_System())
            {
                var apt = context.tbl_attributes.FirstOrDefault(c => c.AppointmentID == int.Parse(txtid.Text));
                apt.Status = txtStatus.Text;
                apt.Reason = txtReason.Text;
                apt.DateTime = txtDateTime.Text;
                apt.PatientID = int.Parse(txtPatientID.Text);

                context.SaveChanges();
                loud();
            }
        }

        private void RecepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var hi = RecepDataGrid.SelectedItem;
            if (hi != null)
            {
                dynamic no = hi;
                txtid.Text = no.Id.ToString();
                txtDateTime.Text = no.dateTime;
                txtReason.Text = no.reason;
                txtStatus.Text = no.Statue;
                txtDateOfBirth.Text = no.dateOfBirth;
                txtPatientName.Text = no.patientName;
                txtPatientNotes.Text = no.notes;
                txtPhone.Text = no.phone;
                txtPatientID.Text = no.patientID;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("writ");
                return;
            }
            using (var context = new db_Medical_Appointment_System())
            {
                var serch = context.tbl_attributes.Include(u => u.tbl_Patient).FirstOrDefault(x => x.tbl_Patient.PatientName == txtSearch.Text);

                if (serch != null)
                {
                    var hi = context.tbl_attributes.Include(u=>u.tbl_Patient)
                        .Where(c => c.tbl_Patient.PatientName == serch.tbl_Patient.PatientName)
                        .Select(x => new
                        {
                            Id = x.AppointmentID.ToString(),
                            patientID = x.PatientID.ToString(),
                            patientName = x.tbl_Patient.PatientName,
                            dateTime = x.DateTime,
                            reason = x.Reason,
                            dateOfBirth = x.tbl_Patient.DateOfBirth,
                            phone = x.tbl_Patient.Phone,
                            notes = x.tbl_Patient.Notes,
                            Statue = x.Status,
                        }).ToList();

                    RecepDataGrid.ItemsSource = hi;
                }
                else MessageBox.Show("noooooo");
            }
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDateOfBirth.Text) || string.IsNullOrEmpty(txtPatientName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtPatientNotes.Text))
            {
                MessageBox.Show("enter all");
                return;
            }
            using (var context = new db_Medical_Appointment_System())
            {
                var add = new tbl_Patient
                {
                    PatientName = txtPatientName.Text,
                    Phone = txtPhone.Text,
                    DateOfBirth = txtDateOfBirth.Text,
                    Notes = txtPatientNotes.Text,
                };

                context.tbl_Patient.Add(add);
                context.SaveChanges();
                loud();
            }
        }


        private void addAppointmentbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtmmm.Text)|| string.IsNullOrEmpty(txtPatientID.Text)|| string.IsNullOrEmpty(txtReason.Text)|| string.IsNullOrEmpty(txtStatus.Text)|| string.IsNullOrEmpty(txtDateTime.Text))
            {
                MessageBox.Show("enter all");
                return;
            }
            using (var context = new db_Medical_Appointment_System())
            {
                var add = new tbl_attributes
                {
                    DateTime = txtDateTime.Text,
                    Reason = txtReason.Text,
                    Status = txtStatus.Text,
                    UserID = int.Parse(txtmmm.Text),
                    PatientID = int.Parse(txtPatientID.Text),
                };


                context.tbl_attributes.Add(add);
                context.SaveChanges();
                loud();
            }
        }

        private void Deleteebtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new db_Medical_Appointment_System())
            {
                var move = context.tbl_attributes.FirstOrDefault(u=>u.AppointmentID == int.Parse(txtid.Text));
                if (move != null)
                {
                    context.Remove(move);
                    context.SaveChanges();
                    loud();
                }
            }
        }
    }
}
