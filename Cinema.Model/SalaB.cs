using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cinema.Model
{
    public class SalaB
    {
        MySqlConnection cn = new MySqlConnection(@"server=lamp.ii.us.edu.pl;user id=ii302052;persistsecurityinfo=True;database=ii302052;password=123456Op*;;allow zero datetime=yes;Allow User Variables=True");

        public int[] wielkosc(int id)
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT max(row),max(number) from seat where auditorium_id=" + id, cn);
            MySqlDataReader a = cmd.ExecuteReader();
            int[] wartosci = new int[2];
            while (a.Read())
            {
                wartosci[0] = a.GetInt32(0);
                wartosci[1] = a.GetInt32(1);
            }
            cn.Close();
            return wartosci;

        }
        public List<int> miejca_zarezerwowane(int id_screening)
        {

            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT seat_id,row,number FROM seat join seat_reserved on seat.id = seat_reserved.seat_id where screening_id=" + id_screening, cn);
            MySqlDataReader a = cmd.ExecuteReader();

            if (a.HasRows == false)
            {
                return null;
            }
            List<int> zajete = new List<int>();
            while (a.Read())
            {
                zajete.Add(a.GetInt32(1));
                zajete.Add(a.GetInt32(2));
            }
            cn.Close();
            return zajete;
        }
        public int rezerwacja(int screenid, int user_id, int user_id2)
        {
            user_id = 2;
            user_id2 = 2;
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("Set @idv:= (Select max(id) from reservation) + 1; " +
                "  Insert into  reservation values (@idv," + screenid + ",2,'brak',true,2,false,true);"+
                " select @idv", cn);
            MySqlDataReader a = cmd.ExecuteReader();
            int id_rez=-1;
            while (a.Read())
            {
                id_rez=a.GetInt32(0);
            }
                cn.Close();
            return id_rez;
        }
        public void rezerwacjamiejsce(int reservation_id, int seatid, int screening_id)
        {

            cn.Open();
            //Set @id = Select max(id) from seat_reserved+1
            // MySqlCommand cmd = new MySqlCommand("  Insert into  seat_reserved values (" + seatid + "," + seatid + "," + reservation_id + "," + screening_id + ")", cn);
            // MySqlCommand cmd = new MySqlCommand(" DECLARE id int"+
            //     " Set @id = (Select max('id') from seat_reserved)+1"  +
            MySqlCommand cmd = new MySqlCommand(" Set @idv  := (Select max(id) from seat_reserved)+1;" +
                 " Insert into  seat_reserved values (@idv, " + seatid + "," + reservation_id + "," + screening_id + ")", cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public void czysc()
        {
            cn.Open();
            //dodaje jedno miejsce żeby int się incrementował po wykasowaniu wszystkiego
            MySqlCommand cmd = new MySqlCommand("delete from seat_reserved; insert into seat_reserved values(1,1,15,1)", cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public int usun_rezerwacje(string film,int seat,string start)
        {
            cn.Open();

            MySqlCommand cmd = new MySqlCommand(
                " Set @idfilm:= (Select id from movie where title='" + film + "');"+
                " Set @idrez := (Select reservation.id from reservation join seat_reserved on reservation.id = seat_reserved.reservation_id join screening on reservation.screening_id=screening.id where screening.screening_start='" + start + "' and screening.movie_id=@idfilm  and  seat_reserved.seat_id=" + seat + ");" +
                " delete from seat_reserved where reservation_id=@idrez;" +
                " delete from reservation where id=@idrez", cn);
           // MySqlCommand cmd = new MySqlCommand("delete from seat_reserved; insert into seat_reserved values(1,1,15,1)", cn);
           int ret= cmd.ExecuteNonQuery();

            cn.Close();
            return ret;
        }
    }
}
