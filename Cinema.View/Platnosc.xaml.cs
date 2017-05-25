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
using System.Drawing;



namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for Platnosc.xaml
    /// </summary>
    public partial class Platnosc : Window
    {
        private String user;
        
        public Platnosc(String user)
        {
            InitializeComponent();
            this.user = user;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            if (String.IsNullOrEmpty(CreditCardNumber_textbox.Text) || CreditCardNumber_textbox.Text.Any(c => Char.IsLetter(c)) || CreditCardNumber_textbox.Text.Length != 16)
            {
                CreditCardNumber_textbox.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;

            }
            else
            {
                CreditCardNumber_textbox.BorderBrush = new SolidColorBrush(Colors.DarkGray);
            }

            if (String.IsNullOrEmpty(ExpireDateMm_textbox.Text) || ExpireDateMm_textbox.Text.Any(c => Char.IsLetter(c)) || ExpireDateMm_textbox.Text.Length != 2 || Convert.ToInt32(ExpireDateMm_textbox.Text) > 12)
            {
                ExpireDateMm_textbox.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            else
            {
                ExpireDateMm_textbox.BorderBrush = new SolidColorBrush(Colors.DarkGray);

            }

            if (String.IsNullOrEmpty(ExpireDateYy_textbox.Text) || ExpireDateYy_textbox.Text.Any(c => Char.IsLetter(c)) || ExpireDateYy_textbox.Text.Length != 2)
            {
                ExpireDateYy_textbox.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            else
            {
                ExpireDateYy_textbox.BorderBrush = new SolidColorBrush(Colors.DarkGray);

            }

            if (String.IsNullOrEmpty(SecurityCode_passwordBox.Password) || SecurityCode_passwordBox.Password.Any(c => Char.IsLetter(c)) || SecurityCode_passwordBox.Password.Length < 3)
            {
                SecurityCode_passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            else
            {
                SecurityCode_passwordBox.BorderBrush = new SolidColorBrush(Colors.DarkGray);

            }

            if (valid)
            {
                MainWindow mw = new MainWindow(user);
                mw.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow repertuar = new MainWindow(user);
            repertuar.Show();
            this.Close();
        }
    }
}
