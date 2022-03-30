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

namespace Wpfhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length >= 2)
            {
                string s = "";
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        s = s + ((TextBox)item).Text;
                        s = s + '\n';
                    }
                }
                MessageBox.Show("Здрасти " + s + "!!! Това е твоята първа програма на Visual Studio 2012!");
            }
            else
            {
                MessageBox.Show("Името трябва да е дълго поне 2 символа! Моля коригирайте!");
            }
        }

        private void facButton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(facTxt.Text);
            int fac = 1;
            if (n < 0)
            {
                MessageBox.Show("Некоректна стойност за n");
            }else if(n==0 || n == 1)
            {
                MessageBox.Show(n + "! = 1");
            }
            else
            {
                for(int i = n; i>1; i--)
                {
                    fac *= i;
                }
                MessageBox.Show(n + "! = " + fac);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
