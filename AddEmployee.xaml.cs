using BL;
using DAL;
using DAL.Models;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    ///  

    public delegate bool AddEmployeeDelegate(Employee employee);

    public partial class AddEmployee : Window
    {
        public event AddEmployeeDelegate EventAddEmployee;

        InterviewsMBL interviews = new InterviewsMBL();
        Employee newEmployee;

        public AddEmployee()
        {
            InitializeComponent();
        }

        //פונקציה המפעילה את האירוע כאשר עובד נוסף
        public bool EmployeeAdd(Employee employee)
        {
            return EventAddEmployee?.Invoke(employee) ?? false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || FirstNameTextBox.Text == "" || LastNameTextBox.Text == "" || AgeTextBox.Text == "" || StartOfWorkingYearTextBox.Text == ""
                || CityAddressTextBox.Text == "" || StreetAddressTextBox.Text == "" || JobTitleTextBox.Text == "" || PhoneNumberTextBox.Text == "" || MailAddressTextBox.Text == "")
                MessageBox.Show("All fields must be filled");
            else
            {
                //קבלת כל הנתונים מהטופס
                newEmployee = new Employee()
                {
                    //Id = int.Parse(IdTextBox.Text),
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Age = int.Parse(AgeTextBox.Text),
                    StartOfWorkYear = int.Parse(StartOfWorkingYearTextBox.Text),
                    City = CityAddressTextBox.Text,
                    Street = StreetAddressTextBox.Text,
                    RoleInCompany = JobTitleTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Email = MailAddressTextBox.Text
                };

                try
                {
                    ChackData.ChackDetails(newEmployee);
                    interviews.AddEmployye(newEmployee);
                    //בדיקה האם העובד נוסף בהצלחה
                    if (EmployeeAdd(newEmployee))
                        MessageBox.Show("Employee added Successfully");
                    else
                        MessageBox.Show("Failed to add employee");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}