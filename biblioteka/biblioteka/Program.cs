using System;

class Program
{
    static void Main()
    {
        var b = new Biblioteka();

        while (true)
        {
            Console.WriteLine("\n===MENU WYBORU===");
            Console.WriteLine("1 Dodaj czytelnika");
            Console.WriteLine("2 Dodaj pozycję");
            Console.WriteLine("3 Wypożycz pozycję");
            Console.WriteLine("4 Zwroc pozycję");
            Console.WriteLine("5 Sprawdz dostępność pozycji");
            Console.WriteLine("6 Pokaz wypożyczenia czytelnika");
            Console.WriteLine("7 Pokaz wszystkie pozycje");
            Console.WriteLine("8 Pokaz wszystkich czytelników");
            Console.WriteLine("9 Usun czytelnika");
            Console.WriteLine("10 Usun pozycję");
            Console.WriteLine("0 Wyjście");
            Console.Write("Wybierz: ");
            string w = Console.ReadLine();
            Console.WriteLine();

            if (w == "1")
            {
                Console.WriteLine("===Dodawanie czytelnika===");
                Console.Write("Imię: ");
                string i = Console.ReadLine();
                Console.Write("Nazwisko: ");
                string n = Console.ReadLine();
                b.DodajCzytelnika(i, n);
            }
            else if (w == "2")
            {
                Console.WriteLine("===Dodawanie pozycji===");
                Console.WriteLine("Typ pozycji: 1.Książka 2.Audiobook 3.FilmDVD 4.Czasopismo");
                Console.Write("Wybierz: ");
                string typ = Console.ReadLine();
                Console.Write("Tytuł: ");
                string t = Console.ReadLine();

                Pozycja p = null;

                if (typ == "1")
                {
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    p = new Ksiazka();
                    p.Tytul = t;
                    ((Ksiazka)p).Autor = autor;
                }
                else if (typ == "2")
                {
                    Console.Write("Narrator: ");
                    string narrator = Console.ReadLine();
                    p = new Audiobook();
                    p.Tytul = t;
                    ((Audiobook)p).Narrator = narrator;
                }
                else if (typ == "3")
                {
                    Console.Write("Reżyser: ");
                    string rezyser = Console.ReadLine();
                    p = new FilmDVD();
                    p.Tytul = t;
                    ((FilmDVD)p).Rezyser = rezyser;
                }
                else if (typ == "4")
                {
                    Console.Write("Numer: ");
                    int numer = int.Parse(Console.ReadLine());
                    p = new Czasopismo();
                    p.Tytul = t;
                    ((Czasopismo)p).Numer = numer;
                }

                if (p != null) b.DodajPozycje(p);
            }
            else if (w == "3")
            {
                Console.WriteLine("===Wypożyczanie pozycji===");
                Console.WriteLine("=Lista wszystkich czytelników=");
                b.PokazCzytelnikow();
                Console.Write("Id czytelnika: ");
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine("=Lista wszystkich pozycji=");
                b.PokazPozycje();
                Console.Write("Id pozycji: ");
                int k = int.Parse(Console.ReadLine());
                b.WypozyczPozycje(c, k);
            }
            else if (w == "4")
            {
                Console.WriteLine("===Zwracanie pozycji===");
                Console.Write("Id pozycji: ");
                int k = int.Parse(Console.ReadLine());
                b.ZwrocPozycje(k);
            }
            else if (w == "5")
            {
                Console.WriteLine("===Sprawdzanie dostępności pozycji===");
                Console.Write("Id pozycji: ");
                int k = int.Parse(Console.ReadLine());
                b.SprawdzDostepnosc(k);
            }
            else if (w == "6")
            {
                Console.WriteLine("===Sprawdzanie wypożyczeń czytelnika===");
                Console.WriteLine("=Lista wszystkich czytelników=");
                b.PokazCzytelnikow();
                Console.Write("Id czytelnika: ");
                int c = int.Parse(Console.ReadLine());
                b.PokazWypozyczeniaCzytelnika(c);
            }
            else if (w == "7")
            {
                Console.WriteLine("===Lista wszystkich pozycji===");
                b.PokazPozycje();
            }
            else if (w == "8")
            {
                Console.WriteLine("===Lista wszystkich czytelników===");
                b.PokazCzytelnikow();
            }
            else if (w == "9")
            {

                Console.WriteLine("===Usuwanie czytelnika===");
                Console.WriteLine("=Lista wszystkich czytelników=");
                b.PokazCzytelnikow();
                Console.Write("Id czytelnika do usunięcia: ");
                int c = int.Parse(Console.ReadLine());
                b.UsunCzytelnika(c);
            }
            else if (w == "10")
            {
                Console.WriteLine("===Usuwanie pozycji===");
                Console.WriteLine("=Lista wszystkich pozycji=");
                b.PokazPozycje();
                Console.Write("Id pozycji do usunięcia: ");
                int k = int.Parse(Console.ReadLine());
                b.UsunPozycje(k);
            }
            else if (w == "0")
            {
                break;
            }
        }
    }
}