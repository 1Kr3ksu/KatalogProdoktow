using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KatalogProdoktow
{
    public class Produkt
    {
        public string Nazwa { get; set; } = "";

        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value < 0 ? 0 : value; }
        }

        private int ilosc;
        public int Ilosc
        {
            get { return ilosc; }
            set { ilosc = value < 0 ? 0 : value; Zmiana(nameof(Ilosc)); }
        }

        public string Kategoria { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Zmiana(string nazwaWlasciwosci)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWlasciwosci));
        }
    }
}
