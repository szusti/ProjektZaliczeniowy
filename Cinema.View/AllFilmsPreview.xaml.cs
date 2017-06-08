using Cinema.Controller;
using Cinema.Model;
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

namespace Cinema.View {
    /// <summary>
    /// Interaction logic for AllFilmsPreview.xaml
    /// </summary>
    public partial class AllFilmsPreview : Window {
        FilmWithImage selectedFilm;
        MainWindow repertuar;

        string user;
        public AllFilmsPreview(string user, MainWindow repertuar) {
            this.user = user;
            this.repertuar = repertuar;
            InitializeComponent();
            LoadAllFilms();
        }

        public void LoadAllFilms() {
            FilmsController controller = new FilmsController();
            filmsList.ItemsSource = controller.GetFilmsWithImageEntities();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (filmsList.SelectedItem != null) {
                selectedFilm = filmsList.SelectedItem as FilmWithImage;
                if (!selectedFilm.Title.Equals("Najpierw wybierz datę")) {
                    dateList.ItemsSource = selectedFilm.dates;
                    if (selectedFilm.dates != null && selectedFilm.dates.Count > 0) {
                        dateList.SelectedItem = selectedFilm.dates[0];
                        hourList.ItemsSource = selectedFilm.datesAndHours[selectedFilm.dates[0]];
                        hourList.SelectedItem = selectedFilm.datesAndHours[selectedFilm.dates[0]][0];
                    }

                    else {
                        hourList.ItemsSource = null;
                    }
                }
            }
        }

        private void buy_ticket(object sender, RoutedEventArgs e) {
            if (selectedFilm != null && hourList.SelectedItem != null && dateList.SelectedItem != null) {
                string dateTemp = dateList.SelectedItem.ToString();
                string date = DateTime.Parse(dateTemp).ToShortDateString();
                string hour = hourList.SelectedItem.ToString();
                Cinema.Controller.FilmsController ac = new Cinema.Controller.FilmsController();
                int id_screening = ac.id_screening_wybranego(selectedFilm.Id, hour, date);
                repertuar.Close();
                SalaKinowa salakinowa = new SalaKinowa(user, selectedFilm.Title, hour, id_screening, date);
                salakinowa.Show();

                this.Close();
            }
        }
    }
}
