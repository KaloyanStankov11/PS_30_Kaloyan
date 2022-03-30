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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
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

        private void resetAll()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear(); 
                }
            }
        }

        private void showStudent(Student s)
        {
            Nametxt.Text = s.name;
            ForeNametxt.Text = s.forename;
            SurNametxt.Text = s.surname;
            Facultytxt.Text = s.faculty;
            Spectxt.Text = s.specialty;
            OKStxt.Text = s.degree;
            Stattxt.Text = s.status;
            Fnumtxt.Text = s.fNum.ToString();
            Coursetxt.Text = s.course.ToString();
            Potoktxt.Text = s.potok.ToString();
            Grouptxt.Text = s.group.ToString();
        }

        private void makeInactive()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void makeActive()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            Student s = StudentData.testStudents[0];
            showStudent(s);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            resetAll();
        }

        private void Disablebtn_Click(object sender, RoutedEventArgs e)
        {
            makeInactive();
        }

        private void Enablebtn_Click(object sender, RoutedEventArgs e)
        {
            makeActive();
        }
    }

   
}
