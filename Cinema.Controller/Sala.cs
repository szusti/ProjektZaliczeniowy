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

        public byte[][] sala(int id_screening)
        {
            //1 bo nie ma innej w baze
            int id_sala = salaB.numer_audytorium(id_screening);
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

        public void rezerwacjamiejsce(int row, int number,int screening_id,int rezerwation_id,int dl_rzedu)//int ilosc miejcs w rzedzie dl tablicy
        {
            salaB.rezerwacjamiejsce(rezerwation_id, (salaB.numer_audytorium(screening_id)-1)*1000+((row - 1) * dl_rzedu) + number,screening_id);
        }
        public void czysc()
        {
            salaB.czysc();
        }
        public int usun_rezerwacje(string film_id, int row, int numer,string godzina,string data,int screening_id, int dl_rzedu)
        {
            return salaB.usun_rezerwacje(film_id, (salaB.numer_audytorium(screening_id) - 1) * 1000 + (row-1)* dl_rzedu + numer, data+" "+godzina);
        }
        public int del_rezerwacje(int screening_id, int row, int numer, int dl_rzedu)
        {
            return salaB.del_rezerwacje(screening_id, (salaB.numer_audytorium(screening_id) - 1) * 1000 + (row - 1) * dl_rzedu + numer);
        }
        public int audytorium_num(int screening_id)
        {
            return salaB.numer_audytorium(screening_id);
        }
        }
}
