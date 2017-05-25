using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for SalaKinowa.xaml
    /// </summary>
    public partial class SalaKinowa : Window
    {
        private String user;
        private String selectedFilm;
        private int screening_id = 1;
        private byte[][] sala;
        private String date;
        private String date0;
        List<int> miejsca = new List<int>();
        public SalaKinowa(String user, String selectedFilm, String date,int screening_id,string date0)
        {
            InitializeComponent();
            this.user = user;
            this.selectedFilm = selectedFilm;
            this.date = date;
            this.date0 = date0;
            this.screening_id = screening_id;
            if (user.Equals("user")){
                buttonclear.Visibility = System.Windows.Visibility.Hidden;
            };
            Cinema.Controller.Sala s = new Cinema.Controller.Sala();
            sala = s.sala(1, screening_id);//1 bo tylko 1 sala dostępna
            for (int i = 0; i < sala.Length; i++)
            {
                for (int j = 0; j < sala[i].Length; j++)
                {
                    Button a = new Button();
                    a.Content = (j + 1).ToString();
                    a.HorizontalAlignment = HorizontalAlignment.Left;
                    a.Margin = new Thickness(112 + j * 75, 130 + i * 35, 0, 0);
                    a.VerticalAlignment = VerticalAlignment.Top;
                    a.Width = 40;
                    if (sala[i][j] == 0)
                    {
                        a.Tag = new int[2] { i, j };
                        a.Click += new System.Windows.RoutedEventHandler(this.miejce_click);
                    }
                    else
                    {
                        a.Background = Brushes.Red;
                    }

                    a.Visibility = Visibility.Visible;
                    grid.Children.Add(a);
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow repertuar = new MainWindow(user);
            repertuar.Show();
            this.Close();

        }
        private void miejce_click(object sender, RoutedEventArgs e)
        {
            Button miejce = sender as Button;
            miejce.Background = Brushes.Green;
            sala[(miejce.Tag as int[])[0]][(miejce.Tag as int[])[1]] = 2;
            miejce.Click -= new System.Windows.RoutedEventHandler(this.miejce_click);
            miejce.Click += new System.Windows.RoutedEventHandler(this.miejce_cancel_click);
        }
        private void miejce_cancel_click(object sender, RoutedEventArgs e)
        {
            Button miejce = sender as Button;
            miejce.Background = Brushes.Transparent;
            sala[(miejce.Tag as int[])[0]][(miejce.Tag as int[])[1]] = 0;
            miejce.Click -= new System.Windows.RoutedEventHandler(this.miejce_cancel_click);
            miejce.Click += new System.Windows.RoutedEventHandler(this.miejce_click);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < sala.Length; i++)
            {
                for (int j = 0; j < sala[i].Length; j++)
                {
                    if (sala[i][j] == 2)
                    {
                        miejsca.Add((i + 1));
                        miejsca.Add((j + 1));
                    }
                }
            }

            if (miejsca.Count != 0)
            {
                PotwierdzeniePlatnosci potplatnosc = new PotwierdzeniePlatnosci(user, selectedFilm, miejsca, date,screening_id,this.date0);
                potplatnosc.Show();
                this.Close();
            }
            else
            {
               //PotwierdzeniePlatnosci potplatnosc = new PotwierdzeniePlatnosci(user, selectedFilm, null, date);
               // potplatnosc.Show();
               // this.Close();
            }

        }
        private void buttonclear_Click(object sender, RoutedEventArgs e)
        {

            Cinema.Controller.Sala s = new Cinema.Controller.Sala();
            s.czysc();//do czyszczenia z wszystkich sal
            
            //usuwa rezerwacje wszystkich miejsc które były wybrane w tym samym momencie co 1,1
            //jeśli podstawic pod 1,1 rząd i miejsce to mogłoby być usuwanie rezerwacji przez kasjera
            //MessageBox.Show( s.usun_rezerwacje(selectedFilm, 1,1, date, this.date0).ToString());
            SalaKinowa odswiez = new SalaKinowa(this.user, this.selectedFilm, this.date,this.screening_id, this.date0);
            odswiez.Show();
            this.Close();
        }
    }
    }
