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