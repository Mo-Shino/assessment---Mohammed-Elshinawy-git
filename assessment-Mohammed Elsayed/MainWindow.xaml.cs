using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace assessment_Mohammed_Elsayed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Email = txtEmail.Text;
            string Pass = txtPass.Password;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Pass))
            {
                MessageBox.Show("enter all values");
                return;
            }

            using (var context = new db_Medical_Appointment_System())
            {
                var signd = context.tbl_User.FirstOrDefault(u=> u.Email == Email && u.Password == Pass);
                if (signd != null)
                {
                    if (signd.UserRole == "Doctor")
                    {
                        docPage docPage = new docPage();
                        docPage.Show();
                        this.Close();
                    }
                    else if (signd.UserRole == "Receptionist")
                    {
                        RecepPage recepPage = new RecepPage();
                        recepPage.Show();
                        this.Close();
                    }
                    else MessageBox.Show("who are you");
                }
                else MessageBox.Show("wrong username and pass");
            }
        }
    }
}