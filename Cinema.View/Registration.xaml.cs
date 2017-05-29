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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Cinema.Controller.Uzytkownik m = new Uzytkownik();
        public Registration()
        {  List<String> a = m.getAllPosition();
            InitializeComponent();
            for(int i=0;i<a.Count();i++)

            positionComboBox.Items.Add(a[i]);
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
           
            string a= m.addUSer(nameTextBox.Text, passwordTestBox.Password, positionComboBox.SelectedItem.ToString());
            namelabel.Content = a;
            if (a == "Rejestracja powiodła się") {
                Logowanie w = new Logowanie();
                w.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logowanie w = new Logowanie();
            w.Show();
            this.Close();
        }
    }
}
