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
using Cinema.Controller;
namespace Cinema.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //zmienna wysylana do interfejsu InfoOFilmie 
        private String selectedFilm;
        //kto sie zalogowal
        private String user;
        private int id_film;
        public MainWindow(String user) {
            InitializeComponent();
            this.user = user;
            listView.Items.Add("Najpierw wybierz datę");
            //List<string> tab = new Cinema.Controller.KalendarzFilmow().getGodziny();
            //for (int i = 0; i < tab.Count; i++) comboBox.Items.Add(tab[i]);
        }  


        private void calendar_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            comboBox.Items.Clear();
            DateTime? date = calendar.SelectedDate;
            string a = date.ToString();
            Console.WriteLine("Zmienna a to: " + a);
            string day = date.Value.Day.ToString(); 
            string month = date.Value.Month.ToString();
            string year = date.Value.Year.ToString();
            //string a = date.ToString(); //moje nie ruszać (Kamil)
            //string b = a.Substring(8, 2);
            //string c = a.Substring(5, 2);
            //string d = a.Substring(0, 4);
            List<string> films = new List<string>();
            KalendarzFilmow filmCalendary = new KalendarzFilmow();
            films = filmCalendary.GetFilms(year, month, day);
            listView.ItemsSource = films;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                String test = listView.SelectedItem.ToString();
                if (!test.Equals("Najpierw wybierz datę")) {
                    wybranyFilm.Content = test;
                    selectedFilm = test;
                    comboBox.Items.Clear();
                    Cinema.Controller.InfoOFilmie a = new Cinema.Controller.InfoOFilmie();
                    id_film = a.getId(selectedFilm);
                    DateTime? date = calendar.SelectedDate;
                    //string aa = date.ToString(); //dla Kamila bo ma dziwne ustawienia daty
                    //string b = aa.Substring(8, 2);
                    //string c = aa.Substring(5, 2);
                    //string d = aa.Substring(0, 4);
                    string aa = date.ToString();
                    string b = aa.Substring(0, aa.IndexOf('.'));
                    string c = aa.Substring(aa.IndexOf('.') + 1, aa.IndexOf('.'));
                    string d = aa.Substring(aa.IndexOf(c) + 3, 4);
                    List<string> tabgodziny = new Cinema.Controller.KalendarzFilmow().getGodziny(id_film, d, c, b);
                    for (int i = 0; i < tabgodziny.Count; i++) comboBox.Items.Add(tabgodziny[i]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedFilm == null)
            {
                    selectedFilm = "Matrix";
            }
            InfoOFilmie iOF = new InfoOFilmie(selectedFilm);
            iOF.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if(selectedFilm != null && comboBox.SelectedItem != null)
            {
                string date = comboBox.SelectedItem.ToString();
                Cinema.Controller.KalendarzFilmow ac = new Cinema.Controller.KalendarzFilmow();
                int id_screening = ac.id_screening_wybranego(id_film, date, calendar.SelectedDate.Value.ToShortDateString());
                SalaKinowa salakinowa = new SalaKinowa(user, selectedFilm, date, id_screening,calendar.SelectedDate.Value.ToShortDateString());
                salakinowa.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            this.Close();
        }
    }
}
