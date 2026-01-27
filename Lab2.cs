using System;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1 - Osoba");
            Osoba o1 = new Osoba("Jan", "Kowalski", 30);
            o1.WyswietlInformacje();

            Console.WriteLine("\nZadanie 2 - BankAccount");
            BankAccount konto = new BankAccount("Jan Kowalski", 1000);
            konto.Wplata(500);
            konto.Wyplata(200);
            Console.WriteLine($"Saldo: {konto.Saldo}");

            Console.WriteLine("\nZadanie 3 - Student");
            Student s1 = new Student("Anna", "Nowak");
            s1.DodajOcene(5);
            s1.DodajOcene(4);
            s1.DodajOcene(3);
            Console.WriteLine($"Średnia ocen: {s1.SredniaOcen}");

            Console.WriteLine("\nZadanie 4 - Licz");
            Licz l1 = new Licz(10);
            Licz l2 = new Licz(5);
            l1.Dodaj(5);
            l2.Odejmij(2);
            l1.Wypisz();
            l2.Wypisz();

            Console.WriteLine("\nZadanie 5 - Sumator");
            Sumator sumator = new Sumator(new int[] { 1, 2, 3, 4, 5, 6 });
            Console.WriteLine("Suma: " + sumator.Suma());
            Console.WriteLine("Suma podzielne przez 2: " + sumator.SumaPodziel2());
            Console.WriteLine("Ile elementów: " + sumator.IleElementow());
            sumator.Wypisz();
            sumator.WypiszZakres(1, 4);
        }
    }

    // ===================== Zadanie 1 =====================

//     Napisz klasę Osoba, która będzie przechowywać informacje o imieniu, nazwisku oraz wieku osoby.
// • Zaimplementuj konstruktor, który będzie przyjmował wszystkie trzy wartości.
// • Użyj właściwości Imie, Nazwisko, Wiek, z walidacją:
// o Imię i Nazwisko muszą mieć co najmniej 2 znaki.
// o Wiek musi być liczbą dodatnią.
// • Zaimplementuj metodę WyswietlInformacje(), która wyświetli informacje o osobie.
    class Osoba
    {
        private string imie;
        private string nazwisko;
        private int wiek;

        public string Imie
        {
            get => imie;
            set
            {
                if (value.Length < 2)
                    throw new ArgumentException("Imię musi mieć minimum 2 znaki.");
                imie = value;
            }
        }

        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                if (value.Length < 2)
                    throw new ArgumentException("Nazwisko musi mieć minimum 2 znaki.");
                nazwisko = value;
            }
        }

        public int Wiek
        {
            get => wiek;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Wiek musi być dodatni.");
                wiek = value;
            }
        }

        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}");
        }
    }

    // ===================== Zadanie 2 =====================
//     Napisz klasę BankAccount, która będzie symulowała konto bankowe.
// • Zaimplementuj właściwości Saldo (publiczne, tylko do odczytu) i Wlasciciel.
// • Dodaj metodę Wplata(decimal kwota), która pozwala na zwiększenie salda, oraz metodę
// Wyplata(decimal kwota), która sprawdzi, czy jest wystarczająca ilość środków, a następnie
// odejmie odpowiednią kwotę.
// • Użyj operatorów dostępu, aby zabezpieczyć saldo przed bezpośrednią modyfikacją.
    class BankAccount
    {
        public string Wlasciciel { get; set; }

        // Saldo tylko do odczytu
        public decimal Saldo { get; private set; }

        public BankAccount(string wlasciciel, decimal saldoStartowe)
        {
            Wlasciciel = wlasciciel;
            Saldo = saldoStartowe;
        }

        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być dodatnia.");
            Saldo += kwota;
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być dodatnia.");
            if (kwota > Saldo)
                throw new InvalidOperationException("Brak środków na koncie.");
            Saldo -= kwota;
        }
    }

    // ===================== Zadanie 3 =====================
//     Napisz klasę Student, która będzie przechowywała imię, nazwisko i tablicę ocen.
// • Zaimplementuj właściwość SredniaOcen, która obliczy i zwróci średnią ocen.
// • Dodaj metodę DodajOcene(int ocena), która doda nową ocenę do tablicy.
// • Zaimplementuj konstruktor inicjujący imię i nazwisko studenta.

    class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        private int[] oceny = new int[0];

        public double SredniaOcen
        {
            get
            {
                if (oceny.Length == 0) return 0;
                double suma = 0;
                foreach (var ocena in oceny)
                    suma += ocena;
                return suma / oceny.Length;
            }
        }

        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public void DodajOcene(int ocena)
        {
            Array.Resize(ref oceny, oceny.Length + 1);
            oceny[oceny.Length - 1] = ocena;
        }
    }

    // ===================== Zadanie 4 =====================
//     Stwórz klasę Licz z:
// • publicznym polem value przechowującym wartość liczbową.
// • metodą Dodaj przyjmującą jeden parametr i dodającą przekazaną wartość do wartości
// trzymanej w polu value.
// • analogiczną operację odejmij
// W Main utwórz kilka obiektów klasy Licz i wykonaj różne operacje.
// Do klasy Licz dodaj konstruktor z jednym parametrem - który inicjuje pole wartość na liczbę przekazaną
// w parametrze.
// Zmień widoczność pola na private i dodaj funkcję wypisującą stan obiektu (pole value).

    class Licz
    {
        private int value;

        public Licz(int v)
        {
            value = v;
        }

        public void Dodaj(int x)
        {
            value += x;
        }

        public void Odejmij(int x)
        {
            value -= x;
        }

        public void Wypisz()
        {
            Console.WriteLine($"Wartość: {value}");
        }
    }

    // ===================== Zadanie 5 =====================
//     Stwórz klasę Sumator z:
// • publicznym polem Liczby będącym tablicą liczb
// • metodą Suma zwracającą sumę liczb z pola Liczby
// • metodę SumaPodziel2 zwracającą sumę liczb z tablicy, które są podzielne przez 2
// Zmień widoczność pola Liczby na private oraz dodaj konstruktor.
// Dodaj metodę: int IleElementów () zwracającej liczbę elementów na w tablicy
// Dodaj metodę wypisującą wszystkie elementy tablicy
// Dodaj metodę przyjmującą dwa parametry: lowIndex oraz highIndex, która wypisze elementy o
// indeksach >= lowIndex oraz <= highIndex. Metoda powinna zadziałać poprawnie, gdy lowIndex lub
// highIndex wykraczają poza zakres tablicy (pominąć te elementy).
    class Sumator
    {
        private int[] Liczby;

        public Sumator(int[] liczby)
        {
            Liczby = liczby;
        }

        public int Suma()
        {
            int s = 0;
            foreach (int x in Liczby) s += x;
            return s;
        }

        public int SumaPodziel2()
        {
            int s = 0;
            foreach (int x in Liczby)
                if (x % 2 == 0) s += x;
            return s;
        }

        public int IleElementow()
        {
            return Liczby.Length;
        }

        public void Wypisz()
        {
            Console.WriteLine("Elementy tablicy: " + string.Join(", ", Liczby));
        }

        public void WypiszZakres(int lowIndex, int highIndex)
        {
            Console.Write("Zakres: ");
            for (int i = lowIndex; i <= highIndex; i++)
            {
                if (i < 0 || i >= Liczby.Length) continue;
                Console.Write(Liczby[i] + " ");
            }
            Console.WriteLine();
        }
    }

}
