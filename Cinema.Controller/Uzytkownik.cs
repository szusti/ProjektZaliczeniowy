using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Cinema.Model;
namespace Cinema.Controller  
{
    public class Uzytkownik
    {         
        public bool walidacja(string a, string b)
        {        
            Regex rgxlog = new Regex(@"[a-z]{3,16}[0-9_-]*$");
            Regex rgxpas = new Regex(@"[a-z]{3,18}[0-9_-]*$");
          return rgxlog.IsMatch(a) && rgxpas.IsMatch(b) ? true : false;
        }
        public bool logowanie(string login, string haslo)
        {
            Cinema.Model.UzytkownikB a = new UzytkownikB();
                return a.operacjeNaBazie(login, haslo);
          
        }
        public string getUserPosition(String position)
        {
            Cinema.Model.UzytkownikB a = new UzytkownikB();
            return a.getUserPositionB(position);
        }
        public string addUSer(string login,string password,string position) {
            Cinema.Model.UzytkownikB a = new UzytkownikB();
            if (walidacja(login, password))
            {

                return a.insertNewUSer(login, password, a.genID(), position); ;
            }else return "rejestracja nie powiodla sie";
        }
        public List<String> getAllPosition()
        {
            Cinema.Model.UzytkownikB a = new UzytkownikB();
            return a.getUserPositions();
        }
    }
}