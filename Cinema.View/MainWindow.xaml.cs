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
using Cinema.Controller;
namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        private String user;
        public Logowanie()
        {
           
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Cinema.Controller.Uzytkownik m = new Uzytkownik();
            bool zalogowanie = m.logowanie(nameTestBox.Text, passwordTestBox.Text);
            namelabel.Content = zalogowanie; 
            if(zalogowanie == true)
            {
                user = m.getUserPosition(nameTestBox.Text);
                //namelabel.Content = user; -- Do celow testowych

                MainWindow repertuar = new MainWindow(user);
                repertuar.Show();
                this.Close();
            }
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            user = "user";
            MainWindow repertuar = new MainWindow(user);
            repertuar.Show();
            this.Close();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Registration a = new Registration();
            a.Show();
            this.Close();
        }
    }
}
