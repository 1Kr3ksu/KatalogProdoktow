using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace KatalogProdoktow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();
        public MainWindow()
        {
            InitializeComponent();
            ListaProduktow.ItemsSource = produkty;
            KategorieComboBox.ItemsSource = new string[] { "Elektronika", "Odzież", "Książki", "Meble" };
            KategorieComboBox.SelectedIndex = 0;
            produkty.Add(new Produkt { Nazwa = "Laptop", Cena = 3500, Ilosc = 5, Kategoria = "Elektronika" });
            produkty.Add(new Produkt { Nazwa = "Koszula", Cena = 200, Ilosc = 15, Kategoria = "Elektronika" });

        }


        private void Oblicz(object sender, RoutedEventArgs e)
        {
            string nazwa = NazwaTextBox.Text;
            string kategoria = KategorieComboBox.Text;
            string promocja = PromocjaCheckBox.IsChecked == true ? "Tak" : "Nie";

            // Sprawdzenie ceny
            string cenaText = CenaTextBox.Text;

            if (!double.TryParse(cenaText, out double cena))
            {
                WynikTextblock.Text = "Błąd: Wprowadź poprawną cenę!";
                return;
            }

            if (cena < 0)
            {
                WynikTextblock.Text = "Błąd: Cena nie może być ujemna!";
                return;
            }

            // Sprawdzenie ilości
            string iloscText = IloscTextBox.Text;

            if (!int.TryParse(iloscText, out int ilosc))
            {
                WynikTextblock.Text = "Błąd: Wprowadź poprawną ilość!";
                return;
            }

            if (ilosc < 0)
            {
                WynikTextblock.Text = "Błąd: Ilość nie może być ujemna!";
                return;
            }



            // Obliczenie wartości zamówienia
            double wartoscZamowienia = cena * ilosc;

            // Rabat 10%, jeśli zaznaczono promocję
            if (PromocjaCheckBox.IsChecked == true)
            {
                wartoscZamowienia *= 0.90;
            }

            // Wyświetlenie wszystkich informacji
            WynikTextblock.Text = $"{NazwaTextBox.Text} ({kategoria}): {wartoscZamowienia:F2} zł";

        }
        private void DodajProdukt(object sender, RoutedEventArgs e)
        {
            string nazwa = NazwaTextBox.Text;
            double cena = double.Parse(CenaTextBox.Text);
            int ilosc = int.Parse(IloscTextBox.Text);
            string kategoria = KategorieComboBox.SelectedItem as string ?? "brak kategorii";

            produkty.Add(new Produkt { Nazwa = nazwa, Cena = cena, Ilosc = ilosc, Kategoria = kategoria });

        }

        private void UsunProdukt(object sender, RoutedEventArgs e)
        {
            if (ListaProduktow.SelectedItem is Produkt wybranyProdukt)
            {
                produkty.Remove(wybranyProdukt);
            }
            else
            {
                MessageBox.Show("Nie wybrano produktu do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
