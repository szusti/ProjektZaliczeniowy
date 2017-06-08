using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Cinema.Model
{
    public class FilmDBHelper
    {

        MySqlConnection cn = new MySqlConnection(@"server=lamp.ii.us.edu.pl;user id=ii302052;persistsecurityinfo=True;database=ii302052;password=123456Op*;");

        public List<string> GetAllFilmsTitles()
        {
            List<string> tab = new List<string>();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select title from movie", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            while (a.Read())
            {
                a.Read();
                tab.Add(a.GetString("title"));
            }
            a.Close();
            cn.Close();
            return tab;
        }

        public List<int> GetAllFilmsIds() {
            List<int> filmsId = new List<int>();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select id from movie", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            while (a.Read()) {
                a.Read();
                filmsId.Add(a.GetInt32("id"));
            }
            a.Close();
            cn.Close();
            return filmsId;
        }

        public int GetFilmId(String nazwaFilmu)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select id from movie where title =" + "'"+nazwaFilmu+"'", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                a.Read();
                int c = a.GetInt32("id");
                a.Close();
                cn.Close();
                return c;
            }
            else
            {
                return 0;
            }
        }
        public string GetFilmTitle(int index)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select title from movie where id ="+index, cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                a.Read();
                string c = a.GetString("title");
                a.Close();
                cn.Close();
                return c;
            }
            else
            {
                cn.Close();
                return "Blad Bazy";
            }
        }
        public string pobieranieDanychZBazy(int index, string kol)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select " + kol + " from movie where id =" + index, cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                a.Read();
                string c = a.GetString(kol);
                a.Close();
                cn.Close();
                return c;
            }
            else
            {
                cn.Close();
                return "Blad Bazy";
            }
        }
    }
}
