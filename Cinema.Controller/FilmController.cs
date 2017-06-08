using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Model;
using MySql.Data.MySqlClient;

namespace Cinema.Controller {
    public class FilmsController {

        Model.FilmDBProvider filmsCalendarProvider = new FilmDBProvider();
        public List<String> GetFilms(String year, String month, String day) {
            return filmsCalendarProvider.GetFilmsTitles(year, month, day);
        }
        public List<String> getGodziny(int idfilmu, String year, String month, String day) {
            return filmsCalendarProvider.GetHoursOfFilm(idfilmu, year, month, day);
        }
        public int id_screening_wybranego(int idfilmu, string godzina, string data) {
            return filmsCalendarProvider.screening_id(idfilmu, godzina, data);
        }

        public List<Film> GetFilmsEntities(String year, String month, String day) {
          
            List<Film> films = new List<Film>();
            List<int> filmsId = filmsCalendarProvider.GetAllFilmsId(year, month, day);

            filmsId.ForEach(x => films.Add(CreateEntity(x, year, month, day)));
            return films;
        }

        private Film CreateEntity(int filmId, string year, string month, string day) {
            FilmDBHelper filmsDetailsProvider = new FilmDBHelper();
            List<string> hours = new List<string>();
            filmsCalendarProvider.GetHoursOfFilm(filmId, year, month, day).ForEach(x => hours.Add(DateTime.Parse(x).ToString("HH:mm")));
            string title = filmsDetailsProvider.GetFilmTitle(filmId);
            Console.WriteLine(title);
            Film film = new Film(filmId, title, hours);
            return film;
        }

        public List<FilmWithImage> GetFilmsWithImageEntities() {
            FilmDBHelper filmsDetailsProvider = new FilmDBHelper();
            List<int> filmsId = filmsDetailsProvider.GetAllFilmsIds();
            List<FilmWithImage> films = new List<FilmWithImage>();
            filmsId.ForEach(x => films.Add(CreateFilmWithImageEntities(x)));
            return films;
        }

        private FilmWithImage CreateFilmWithImageEntities(int filmId) {
            FilmDBHelper filmsDetailsProvider = new FilmDBHelper();
            List<DateTime> dates = new List<DateTime>();
            Dictionary<DateTime, List<string>> datesAndHours = new Dictionary<DateTime, List<string>>();
            filmsCalendarProvider.GetDatesOfFilm(filmId).ForEach(x => dates.Add(DateTime.Parse(x)));
            dates.ForEach(x => datesAndHours.Add(x, filmsCalendarProvider.GetHoursOfFilm(filmId, x.Year.ToString(), x.Month.ToString(), x.Day.ToString())));
            string title = filmsDetailsProvider.GetFilmTitle(filmId);
            Console.WriteLine(title);
            FilmWithImage film = new FilmWithImage(filmId, title, dates, datesAndHours);
            return film;
        }

    }
}
