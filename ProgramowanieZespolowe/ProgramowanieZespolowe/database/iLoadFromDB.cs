using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieZespolowe.database
{
    interface iLoadFromDB{
        /// <summary>
        /// Zwraca liste wszystkich dostepnych tabel
        /// </summary>
        List<String> getTables();
        /// <summary>
        /// pobranie calej zawartosci jednej tabeli
        /// <param name="table">Nazwa tabeli</param>
        /// </summary>
        String[] getTable(String table);
        /// <summary>
        /// Zwraca Liste wszystkich kolumn danej tabeli
        /// </summary>
        /// <param name="table">Nazwa danej tabeli</param>
        List<String> getColumns(String table);
        /// <summary>
        /// Zwraca Liste wszystkich kolumn kilku tabel
        /// </summary>
        /// <param name="table">lista tabeli</param>
        /// <returns>Kazda tabela w osobnym wierszu gdzie [0] nazwa tabeli [1...] jej kolumny</returns>  
        /// <returns
        String[] getColumns(List<String> tables);
        /// <summary>
        /// Zwraca zawartosc danej kolumny
        /// </summary>
        /// <param name="table">Nazwa danej tabeli</param>
        /// <param name="column">Nazwa danej kolumny</param>
        List<String> getColumn(String table, String column);
        /// <summary>
        /// Zwraca zawartosc kilku kolumn
        /// </summary>
        /// <param name="table">Nazwa danej tabeli</param>
        /// <param name="">lista kolumn do wyswietlenia</param>
        /// <returns>Pierwszy wiersz to nazwy kolumn</returns>
        String[] getColumn(String table, List<String> columns);
        /// <summary>
        /// Zwraca zawartosc kilku kolumn z wiecej niz jednej tabeli
        /// </summary>
        /// <param name="tables">Nazwa danej tabeli</param>
        /// <param name="columns">lista kolumn do wyswietlenia</param>
        /// <returns>???</returns>
        String[] getColumn(List<String> tables, List<String> columns);
        /// <summary>
        /// Zwraca wszystkie wiersze danej tabeli tylko dla okreslonych kolumn
        /// </summary>
        /// <param name="table">Nazwa danej tabeli</param>
        /// <param name="columns">lista kolumn</param>
        /// <returns>Pierwszy wiersz to nazwy kolumn</returns>
        String[] getRows(String table, List<String> columns);
        /// <summary>
        /// Zwraca wszystkie wiersze wiecej niz jednej tabeli tylko dla okreslonych kolumn
        /// </summary>
        /// <param name="tables">Lista tablic</param>
        /// <param name="columns">Tablica okreslonych kolumn, gdzie dla kazdego wiersza:
        /// [0] z jakiej tabeli
        /// [1] jakiej kolumny
        /// [3] wymagania do tej kolumny
        /// </param>
        /// <returns>????</returns>
        String[] getRows(List<String> tables, String[] columns);
        /// <summary>
        /// Zwraca wszystkie wiersze danej tabeli tylko dla okreslonych kolumn o danych wymaganiach
        /// </summary>
        /// <param name="table">Nazwa danej tabeli</param>
        /// <param name="columns">Lista kolumn</param>
        /// <param name="columnsreq">Wymagania kolumn, gdzie dla kazdego wiersza:
        /// [0] zawiera nazwe kolumny
        /// [1...] zawiera wymagania do danej kolumny
        /// </param>
        /// <returns></returns>
        String[] getRows(String table, List<String> columns, String[] columnsreq);
        /// <summary>
        /// Zwraca wszystkie wiersze danej wiecej niz jednej tabeli tylko dla okreslonych kolumn o danych wymaganiach
        /// </summary>
        /// <param name="tables">Nazwa danych tabeli</param>
        /// <param name="columns">Lista kolumn</param>
        /// <param name="columnsreq">Wymagania kolumn, gdzie dla kazdego wiersza:
        /// [0] zawiera nazwe tabeli
        /// [1] zawiera nazwe kolumny
        /// [3] wymagania danej kolumny</param>
        /// <returns>????</returns>
        String[] getRows(List<String> tables, List<String> columns, String[] columnsreq);
    }
}
