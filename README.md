# ProjektZaliczeniowy
Projekt zaliczeniowy PZ
0) Gui
1.logowanie  (-> user/admin)
a)zabezpieczenie (podział dostępności w zalezności kto się zalogował)
b)wyświetlanie elementów w zależności od użytkownika
3.rezerwacja miejsca
a)wizualizacja sali z miejscami
b)sprawdzenie dostepnosc miejsc
c) rezerwacja 
2.wybor filmu 
a)informacje o filmie(podpiecie pod filweb)
b)kalendarz nadawania
c)promocja na filmy(studenty,piatki itp)

4)platnosc
a)wybor platnosci
b)paragon/bilet

5. Modyfikacje przez kasjera
a) Rezerwacje (zmiana miejsc, dat, usuwanie)

6. Modyfikacje przez admina
a) Repertuar(filmy,czas,sale)
b) Promocje
c) Sale


baza danych 
*)Raport dla kierownika/statystyka

Wersja nr 2
1. interfejs (jako szablon, bez wypełnionych danych. Albo robimy je na początku, i każdy będzie wypełniał tą gwiazdkę którą będzie implementował, albo na samym końcu jedna osoba zrobi interfejs i podepnie pozostałe klasy)
//Druga Kolumna
- Rozroznienie funkcji użytkownika (kasjer/automat,admin)
- filmów
- rezerwacji
 
//Trzecia kolumna
 * Stworzenie interfejsu logowania
 * stworzenie interfejsu przeglądania filmów (rzeczy z karteczki nr 2)
 * interfejs graficzny sali
  * interfejs rezerwacji
 * interfejs płatności
 * kalendarz
 * ograniczenie widoczności funkcji w zależności od rodzaju użytkownika
 
2. filmy
//Druga Kolumna
- baza filmów
- kalendarz
- modyfikacje
//Trzecia kolumna
* Pobranie danych z bazy filmów 
* Wyswietlenie listy filmów 
* wyświetlanie informacji o wybranym filmie 
* wyświetlanie kalendarza z dniami w które można obejrzeć film
* wyświetlanie aktualnych promocji 
* modyfikacja kalendarza(admin )
* modyfikacja promocji (admin)
 
3.Kino
//Druga Kolumna
- Sala
- Co gdzie leci teraz
//Trzecia kolumna 
* wizualizacja sali
* wyświetlanie dostępności miejsc 
* rezerwacja miejsca
* modyfikacja miejsc(kasjer może np. usunąć rezerwacje, albo przenieśc ją)
 
4. Płatność 
//Druga Kolumna
- Jak
- dowód
//Trzecia kolumna
* Wybor sposobu płatności 
* zapis płatności? 
* wydruk(pdf?) Paragonu /biletu
