using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Model;

namespace Cinema.Controller
{
    public class Sala
    {

        Model.SalaB salaB = new SalaB();

        public byte[][] sala(int id_sala,int id_screening)
        {
            //1 bo nie ma innej w baze
            id_sala = 1;
            //2 wartosci z bazy
            int[] wielkosc = salaB.wielkosc(id_sala);
            //utworzenie tablicy byte[row][number] wypełninej 0
            byte[][] sala = new byte[wielkosc[0]][];
            for (int i = 0; i < sala.Length; i++)
            {
                sala[i] = new byte[wielkosc[1]];
            }
            for (int i = 0; i < sala.Length; i++)
            {
                for (int j = 0; j < sala[i].Length; j++)
                {
                    sala[i][j] = 0;
                }
            }
            List<int> zajete = salaB.miejca_zarezerwowane(id_screening);
            if (zajete == null)
            {
                return sala;
            }
            for (int i = 0; i < zajete.Count - 1; i = i + 2)//zajete.Length
            {
                sala[zajete.ElementAt(i) - 1][zajete.ElementAt(i + 1) - 1] = 1;
            }
            return sala;
        }


        public int rezerwacja_nowa(int screenid, int user_id, int user_id2)
        {
          return  salaB.rezerwacja(screenid,2,2);
        }

        public void rezerwacjamiejsce(int row, int number,int screening_id,int rezerwation_id)//int ilosc miejcs w rzedzie dl tablicy
        {
            salaB.rezerwacjamiejsce(rezerwation_id, ((row - 1) * 7) + number,screening_id);
        }
        public void czysc()
        {
            salaB.czysc();
        }
        public int usun_rezerwacje(string film_id, int row, int numer,string godzina,string data)
        {
            return salaB.usun_rezerwacje(film_id, (row-1)*7+numer, data+" "+godzina);
        }
        public int del_rezerwacje(int rep_id, int row, int numer)
        {
            return salaB.del_rezerwacje(rep_id, (row - 1) * 7 + numer);
        }
    }
}
