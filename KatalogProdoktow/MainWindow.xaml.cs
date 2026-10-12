using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogProdoktow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            double suma = cena * ilosc;

            // Rabat 10%, jeśli zaznaczono promocję
            if (PromocjaCheckBox.IsChecked == true)
            {
                suma *= 0.90;
            }

            // Wyświetlenie wszystkich informacji
            WynikTextblock.Text =
                $"Nazwa produktu: {nazwa}\n" +
                $"Kategoria: {kategoria}\n" +
                $"Cena: {cena:F2} zł\n" +
                $"Ilość: {ilosc}\n" +
                $"Promocja: {promocja}\n" +
                $"Wartość zamówienia: {suma:F2} zł";
        }
    }
}
