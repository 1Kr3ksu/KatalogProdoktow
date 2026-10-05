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
            // Pobierz tekst z pola z cena i zmień go na liczbę 
            // Pobierz tekst z pola z ilością i zmień go na liczbę
            //Jeślij wartości są niepoprawne lub ujemne wypisz komunikat w polu wynik albo rzuć wyjątek
                string CenaText = CenaTextBox.Text;
                if (double.TryParse(CenaText , out double cena))
                {
                 if (cena <0)
                {
                    WynikTextblock.Text = "Błąd: Cena nie może być ujemna!";
                    return;
                }    
                }
                else
                {
                WynikTextblock.Text = "Błąd: Wprowadź poprawną liczbę w polu cena!";
                return;
            }
                string IloscText = IloscTextBox.Text;
                if (int.TryParse(IloscText , out int ilosc))
                {
                if (ilosc < 0)
                {
                    WynikTextblock.Text = "Błąd: Ilość nie może być ujemna!";
                    return;
                }
                }
                else
                {
                WynikTextblock.Text = "Błąd: Wprowadź poprawną liczbę w polu ilość!";
                return;
                }

            //Oblicz wartosć zamówienia i wypisz ją w polu wynik
            double suma = cena * ilosc ;
            WynikTextblock.Text = $"Wartość zamówienia: {suma} zł";
        }
    }
}
