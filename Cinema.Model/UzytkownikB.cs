using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Cinema.Model
{
    public class UzytkownikB
    {

        MySqlConnection cn = new MySqlConnection(@"server=lamp.ii.us.edu.pl;user id=ii302052;persistsecurityinfo=True;database=ii302052;password=123456Op*;");
        public bool operacjeNaBazie(string login, string haslo)
        {
            bool test=false;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select username from user where username='" + login + "'", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                a.Close();
                cmd.CommandText = "select password from user where username = '" + login + "'";
                a = cmd.ExecuteReader();
                a.Read();
                if (haslo == a.GetString("password")) test = true; 
            }
            else  test = false;
            cn.Close();
            return test;


        }
        public String getUserPositionB(String login)
        {
            String position = "null";
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select position from user where username='" + login + "'", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                a.Read();
                position = a.GetString("position");
                a.Close();
            }
            return position;
        }

        public List<string> getUserPositions()
        {
            List<string> tab = new List<string>();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select DISTINCT position from user", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            while (a.Read())
            {
                tab.Add(a.GetString(0));
            }
            a.Close();
            cn.Close();
            return tab;
        }
        public bool checkExistUser(String login)
    {
        cn.Open();
            bool te=true;
            MySqlCommand cmd = new MySqlCommand("select position from user where username='" + login + "'", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                te = false;
            }
            
                cn.Close();
        return te;
    }

        public int genID()
        {
            cn.Open();
            int l = 999;
            MySqlCommand cmd = new MySqlCommand("select count(*) from user", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            if (a.Read())
            {
                l=a.GetInt32(0);
            }
            cn.Close();
            return l+1 ;
        }


        public string insertNewUSer(string login, string password, int id, string position)
        {

            
            if (checkExistUser(login))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user(  id , username ,  password ,  position ) VALUES(" + id + " , '" + login + "' ,  '" + password + "' , '" + position + "')", cn);
                MySqlDataReader a = cmd.ExecuteReader();
                a.Read();
                return "rejestracja powiodla sie";
            }else return "rejestracja nie powiodla sie ";
        }
    }
}