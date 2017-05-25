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
    /// Interaction logic for InfoOFilmie.xaml
    /// </summary>
    public partial class InfoOFilmie : Window
    {
        public InfoOFilmie(string jakiFilm)
        {
            InitializeComponent();
            Cinema.Controller.InfoOFilmie a = new Cinema.Controller.InfoOFilmie();

            String jakiFilmWybrany = jakiFilm;      
            int idFilmu = a.getId(jakiFilm);

            image.Source = new BitmapImage(
        new Uri(a.setOkladka(idFilmu), UriKind.Absolute));
            obsadaZBazy.Content=a.setObsada(idFilmu);
            rezyserZBazy.Content = a.setRezyser(idFilmu);
            dlugoscZBazy.Content = a.setDlugosc(idFilmu);
            opisZBazy.Content = a.setOpis(idFilmu);
          
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
