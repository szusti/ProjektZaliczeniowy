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
using Cinema.Controller;


namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for Platnosc.xaml
    /// </summary>
    public partial class Platnosc : Window
    {
        private String user;
        private String selectedFilm;
        private String date;
        private String date0;
        private List<int> miejsca;
        private int screening_id;

        public Platnosc(String user, String selectedFilm, List<int> miejsca, String date, int screening_id, String date0)
        {
            InitializeComponent();
            this.user = user;
            this.selectedFilm = selectedFilm;
            this.date = date;
            this.miejsca = miejsca;
            this.screening_id = screening_id;
            this.date0 = date0;



        }
        private bool valid()
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

            return valid;
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow repertuar = new MainWindow(user);
            repertuar.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

            if (valid()) { 
                List<string> aa =new List<string>();
            for (int i = 0; i < miejsca.Count()/2; i++) { 
             aa.Add("R"+miejsca[i].ToString()+"M" + miejsca[i+1].ToString());
            }
            TicketCreator a = new TicketCreator(aa,selectedFilm,"1",date,"",screening_id.ToString());
                MessageBox.Show("Drukniete na pulpita");
            }
            Logowanie logowanie  = new Logowanie();
            logowanie.Show();
            this.Close();
        }
    }
}
