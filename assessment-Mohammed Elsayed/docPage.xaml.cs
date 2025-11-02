using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for docPage.xaml
    /// </summary>
    public partial class docPage : Window
    {
        public docPage()
        {
            InitializeComponent();
            loud();
        }
        private void loud()
        {
            using (var context = new db_Medical_Appointment_System() )
            {
                var datagridsours = context.tbl_attributes.Where(e=>e.DateTime == "02-11-2025")
                    .Select(n => new
                    {
                        appointmentID = n.AppointmentID,
                        patientID = n.PatientID,
                        patientName = n.tbl_Patient.PatientName,
                        dateTime = n.DateTime,
                        statu = n.Status,
                    }).ToList();

                if (datagridsours != null)
                {
                    DocDataGrid.ItemsSource = datagridsours;
                }
                else MessageBox.Show("no");
            }
        }

        private void DocDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var hi = DocDataGrid.SelectedItem;
            if (hi != null)
            {
                dynamic no = hi ;
                txtID.Text = no.appointmentID.ToString();

                combooo.SelectedItem = no.statu;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (combooo.SelectedItem == null)
            {
                MessageBox.Show("eror");
                return;
            }
            using (var context = new db_Medical_Appointment_System())
            {
                if (!int.TryParse(txtID.Text , out int id))
                {
                    MessageBox.Show("noo");
                }

                var no = context.tbl_attributes.FirstOrDefault(c => c.AppointmentID == id);
                if (no != null)
                {
                    if (combooo.SelectedItem is ComboBoxItem hi)
                    {
                        no.Status = hi.Content.ToString();

                        context.SaveChanges();
                        loud();
                    }
                }
            }

        }
    }
}
