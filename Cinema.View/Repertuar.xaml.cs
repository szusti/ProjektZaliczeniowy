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
using Cinema.Model;

namespace Cinema.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //zmienna wysylana do interfejsu InfoOFilmie 
        private Film selectedFilm;
        //kto sie zalogowal
        private String user;
        private int id_film;
        public MainWindow(String user) {
            InitializeComponent();
            this.user = user;
            listView.Items.Add(new Film(-1,"Najpierw wybierz datę",null));
            //List<string> tab = new Cinema.Controller.KalendarzFilmow().getGodziny();
            //for (int i = 0; i < tab.Count; i++) comboBox.Items.Add(tab[i]);
        }  


        private void calendar_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            if (listView.ItemsSource == null) listView.Items.Clear();
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

            FilmsController filmCalendary = new FilmsController();
            listView.ItemsSource = filmCalendary.GetFilmsEntities(year, month, day);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Film film = listView.SelectedItem as Film;
                if (!film.Title.Equals("Najpierw wybierz datę")) {
                    wybranyFilm.Content = film.Title;
                    selectedFilm = film;
                    DateTime? date = calendar.SelectedDate;
                    filmsHours.ItemsSource = film.Hours;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedFilm == null)
            {
                    selectedFilm = new Film(0,"Matrix", null);
            }
          InfoOFilmie iOF = new InfoOFilmie(selectedFilm.Title);
            iOF.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if(selectedFilm != null && filmsHours.SelectedItem != null)
            {
                string date = filmsHours.SelectedItem.ToString();
                Cinema.Controller.FilmsController ac = new Cinema.Controller.FilmsController();
                int id_screening = ac.id_screening_wybranego(id_film, date, calendar.SelectedDate.Value.ToShortDateString());
                SalaKinowa salakinowa = new SalaKinowa(user, selectedFilm.Title, date, id_screening,calendar.SelectedDate.Value.ToShortDateString());
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

        private void hours_selectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
