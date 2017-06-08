using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Cinema.Model;
namespace Cinema.Controller
{
    public class InfoOFilmie
    {
        Model.FilmDBHelper DbHelper = new FilmDBHelper();
        public List<string> listaFilmow()
        {
            return DbHelper.GetAllFilmsTitles();
        }
        public string setOkladka(int index)
        {
            //return "http://beebom.com/wp-content/uploads/2016/01/Reverse-Image-Search-Engines-Apps-And-Its-Uses-2016.jpg";
            return DbHelper.pobieranieDanychZBazy(index, "cover");
        }
        public string setObsada(int index)
        {        
            return DbHelper.pobieranieDanychZBazy(index,"cast");
        }
        public string setRezyser(int index)
        {            
            return DbHelper.pobieranieDanychZBazy(index, "director");
        }
        public string setDlugosc(int index)
        {
            return DbHelper.pobieranieDanychZBazy(index, "duration_min");
        }
        public string setOpis(int index)
        {
            return DbHelper.pobieranieDanychZBazy(index, "description");
        }
        public int getId(String filmName)
        {
            return DbHelper.GetFilmId(filmName);
        }
    }
}
