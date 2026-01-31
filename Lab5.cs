using System;
using System.Collections.Generic;
//Zad 1 
//enum Operacja
//{
//    Dodawanie = 1,
//    Odejmowanie,
//    Mnożenie,
//    Dzielenie
//}

//class Program
//{
//    static void Main()
//    {
//        List<double> historiaWynikow = new List<double>();

//        try
//        {
//            Console.Write("Podaj pierwszą liczbę: ");
//            double a = double.Parse(Console.ReadLine());

//            Console.Write("Podaj drugą liczbę: ");
//            double b = double.Parse(Console.ReadLine());

//            Console.WriteLine("Wybierz operację:");
//            Console.WriteLine("1 - Dodawanie");
//            Console.WriteLine("2 - Odejmowanie");
//            Console.WriteLine("3 - Mnożenie");
//            Console.WriteLine("4 - Dzielenie");

//            Operacja operacja = (Operacja)int.Parse(Console.ReadLine());

//            double wynik = 0;

//            switch (operacja)
//            {
//                case Operacja.Dodawanie:
//                    wynik = a + b;
//                    break;
//                case Operacja.Odejmowanie:
//                    wynik = a - b;
//                    break;
//                case Operacja.Mnożenie:
//                    wynik = a * b;
//                    break;
//                case Operacja.Dzielenie:
//                    if (b == 0)
//                        throw new DivideByZeroException();
//                    wynik = a / b;
//                    break;
//                default:
//                    Console.WriteLine("Nieprawidłowa operacja.");
//                    return;
//            }

//            historiaWynikow.Add(wynik);
//            Console.WriteLine($"Wynik: {wynik}");
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine("Błąd: Wprowadzono nieprawidłowe dane.");
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Błąd: Dzielenie przez zero.");
//        }

//        Console.WriteLine("\nHistoria wyników:");
//        foreach (double w in historiaWynikow)
//        {
//            Console.WriteLine(w);
//        }
//    }
//}
////Zad2
//enum StatusZamowienia
//{
//    Oczekujące,
//    Przyjęte,
//    Zrealizowane,
//    Anulowane
//}

//class Sklep
//{
//    private Dictionary<int, List<string>> zamowienia = new Dictionary<int, List<string>>();
//    private Dictionary<int, StatusZamowienia> statusy = new Dictionary<int, StatusZamowienia>();

//    public void DodajZamowienie(int numer, List<string> produkty)
//    {
//        zamowienia[numer] = produkty;
//        statusy[numer] = StatusZamowienia.Oczekujące;
//    }

//    public void ZmienStatus(int numer, StatusZamowienia nowyStatus)
//    {
//        if (!statusy.ContainsKey(numer))
//            throw new KeyNotFoundException("Zamówienie nie istnieje.");

//        if (statusy[numer] == nowyStatus)
//            throw new ArgumentException("Nowy status jest taki sam jak obecny.");

//        statusy[numer] = nowyStatus;
//    }

//    public void WyswietlZamowienia()
//    {
//        foreach (var zam in zamowienia)
//        {
//            Console.WriteLine($"Zamówienie {zam.Key}:");
//            Console.WriteLine($"Status: {statusy[zam.Key]}");
//            Console.WriteLine("Produkty:");
//            foreach (string produkt in zam.Value)
//            {
//                Console.WriteLine($"- {produkt}");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Sklep sklep = new Sklep();

//        sklep.DodajZamowienie(1, new List<string> { "Chleb", "Mleko" });
//        sklep.DodajZamowienie(2, new List<string> { "Laptop", "Mysz" });

//        try
//        {
//            sklep.ZmienStatus(1, StatusZamowienia.Przyjęte);
//            sklep.ZmienStatus(2, StatusZamowienia.Zrealizowane);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Błąd: {ex.Message}");
//        }

//        sklep.WyswietlZamowienia();
//    }
//}
//Zad 3
//enum Kolor
//{
//    Czerwony,
//    Niebieski,
//    Zielony,
//    Żółty,
//    Fioletowy
//}

//class Program
//{
//    static void Main()
//    {
//        List<Kolor> kolory = new List<Kolor>
//        {
//            Kolor.Czerwony,
//            Kolor.Niebieski,
//            Kolor.Zielony,
//            Kolor.Żółty,
//            Kolor.Fioletowy
//        };

//        Random random = new Random();
//        Kolor wylosowanyKolor = kolory[random.Next(kolory.Count)];

//        Console.WriteLine("Zgadnij kolor!");

//        while (true)
//        {
//            try
//            {
//                Console.Write("Podaj kolor: ");
//                string input = Console.ReadLine();

//                if (!Enum.TryParse(input, true, out Kolor zgadywanyKolor))
//                    throw new ArgumentException("Nieprawidłowy kolor.");

//                if (!kolory.Contains(zgadywanyKolor))
//                    throw new ArgumentException("Kolor nie znajduje się na liście.");

//                if (zgadywanyKolor == wylosowanyKolor)
//                {
//                    Console.WriteLine("Brawo! Odgadłeś kolor 🎉");
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("Nie zgadłeś, spróbuj ponownie.");
//                }
//            }
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine($"Błąd: {ex.Message}");
//            }
//        }
//    }
//}