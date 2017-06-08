using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cinema.Model {
    public class FilmWithImage {

        public int Id { get; private set; }
        public string Title { get; private set; }
        public ImageSource imageSrc { get; private set; }

        public List<DateTime> dates { get; private set; }
        public Dictionary<DateTime, List<string>> datesAndHours { get; private set; }


        public FilmWithImage(int id, string title, List<DateTime> dates, Dictionary<DateTime, List<string>> datesAndHours) {
            Model.FilmDBHelper DbHelper = new FilmDBHelper();
            //return "http://beebom.com/wp-content/uploads/2016/01/Reverse-Image-Search-Engines-Apps-And-Its-Uses-2016.jpg";
            imageSrc = new BitmapImage(new Uri(DbHelper.pobieranieDanychZBazy(id, "cover"), UriKind.Absolute));
            this.Id = id;
            this.Title = title;
            this.dates = dates;
            this.datesAndHours = datesAndHours;
    }
    }
}
