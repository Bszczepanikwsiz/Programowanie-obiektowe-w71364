using System;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz zadanie (1-5):");
            Console.WriteLine("1 - Delta i pierwiastki trójmianu");
            Console.WriteLine("2 - 10 liczb: suma, iloczyn, średnia, min, max");
            Console.WriteLine("3 - Liczby 20-0 z wyłączeniem {2,6,9,15,19}");
            Console.WriteLine("4 - Pętla nieskończona z break");
            Console.WriteLine("5 - Sortowanie (bąbelkowe lub wstawianie)");

            int wybor = int.Parse(Console.ReadLine()!);

            switch (wybor)
            {
                case 1: Zadanie1(); break;
                case 2: Zadanie2(); break;
                case 3: Zadanie3(); break;
                case 4: Zadanie4(); break;
                case 5: Zadanie5(); break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }

        // ===================== Zadanie 1 =====================
        // Napisz program obliczający wyróżnik delta i pierwiastki trójmianu kwadratowego
        static double ObliczDelta(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        static void Zadanie1()
        {
            Console.WriteLine("Zadanie 1 - Delta i pierwiastki trójmianu");
            Console.Write("Podaj a: ");
            double a = double.Parse(Console.ReadLine()!);
            Console.Write("Podaj b: ");
            double b = double.Parse(Console.ReadLine()!);
            Console.Write("Podaj c: ");
            double c = double.Parse(Console.ReadLine()!);

            double delta = ObliczDelta(a, b, c);

            if (delta < 0)
            {
                Console.WriteLine("Brak pierwiastków rzeczywistych.");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Pierwiastek podwójny: x = {x}");
            }
            else
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"Pierwiastki: x1 = {x1}, x2 = {x2}");
            }
        }

        // ===================== Zadanie 2 =====================
        // Napisz program umożliwiający wprowadzanie 10-ciu liczb. Dla wprowadzonych liczb wykonaj
        //odpowiednie algorytmy:
        //• oblicz sumę elementów tablicy,
        //• oblicz iloczyn elementów tablicy,
        //• wyznacz wartość średnią,
        //• wyznacz wartość minimalną,
        //• wyznacz wartość maksymalną.
        static int[] WczytajLiczby(int n)
        {
            int[] tab = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Podaj liczbę [{i + 1}]: ");
                tab[i] = int.Parse(Console.ReadLine()!);
            }
            return tab;
        }

        static int[] LosujLiczby(int n)
        {
            Random rnd = new Random();
            int[] tab = new int[n];
            for (int i = 0; i < n; i++)
                tab[i] = rnd.Next(1, 101);
            return tab;
        }

        static int Suma(int[] tab)
        {
            int s = 0;
            foreach (int x in tab) s += x;
            return s;
        }

        static long Iloczyn(int[] tab)
        {
            long p = 1;
            foreach (int x in tab) p *= x;
            return p;
        }

        static double Srednia(int[] tab)
        {
            return (double)Suma(tab) / tab.Length;
        }

        static int Minimum(int[] tab)
        {
            int min = tab[0];
            foreach (int x in tab) if (x < min) min = x;
            return min;
        }

        static int Maksimum(int[] tab)
        {
            int max = tab[0];
            foreach (int x in tab) if (x > max) max = x;
            return max;
        }

        static void Zadanie2()
        {
            Console.WriteLine("Zadanie 2 - 10 liczb: suma, iloczyn, średnia, min, max");

            Console.WriteLine("Wybierz: 1 - wczytywanie, 2 - losowanie");
            int wybor = int.Parse(Console.ReadLine()!);

            int[] tab = (wybor == 1) ? WczytajLiczby(10) : LosujLiczby(10);

            Console.WriteLine("Tablica: " + string.Join(", ", tab));
            Console.WriteLine("Suma: " + Suma(tab));
            Console.WriteLine("Iloczyn: " + Iloczyn(tab));
            Console.WriteLine("Średnia: " + Srednia(tab));
            Console.WriteLine("Minimum: " + Minimum(tab));
            Console.WriteLine("Maksimum: " + Maksimum(tab));
        }

        // ===================== Zadanie 3 =====================
        //Napisz program wyświetlający liczby od 20-0, z wyłączeniem liczb {2,6,9,15,19}.
        //Do realizacji zadania wyłączenia użyj instrukcji continue;
        static void Zadanie3()
        {
            Console.WriteLine("Zadanie 3 - Liczby 20-0 z wyłączeniem {2,6,9,15,19}");

            for (int i = 20; i >= 0; i--)
            {
                if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
                    continue;
                Console.Write(i + " ");
            }
        }

        // ===================== Zadanie 4 =====================
        //Napisz program, który w nieskończoność pyta użytkownika o liczby całkowite.
        //    Pętla nieskończona powinna się zakończyć gdy użytkownik wprowadzi liczbę mniejszą od zera.
        //    Do opuszczenia pętli nieskończonej użyj instrukcji break. 
        static void Zadanie4()
        {
            Console.WriteLine("Zadanie 4 - Pętla nieskończona z break");

            while (true)
            {
                Console.Write("Podaj liczbę całkowitą (ujemna kończy program): ");
                int x = int.Parse(Console.ReadLine()!);

                if (x < 0)
                {
                    Console.WriteLine("Koniec programu.");
                    break;
                }
            }
        }

        // ===================== Zadanie 5 =====================
        //Napisz program umożliwiający wprowadzanie n liczb oraz sortujący te liczby metodą
        //bąbelkową lub wstawiania.Wyniki wyświetlaj na konsoli.
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SortowanieBabelkowe(int[] tab)
        {
            int n = tab.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (tab[j] > tab[j + 1])
                        Swap(ref tab[j], ref tab[j + 1]);
        }

        static void SortowanieWstawianie(int[] tab)
        {
            int n = tab.Length;
            for (int i = 1; i < n; i++)
            {
                int klucz = tab[i];
                int j = i - 1;

                while (j >= 0 && tab[j] > klucz)
                {
                    tab[j + 1] = tab[j];
                    j--;
                }
                tab[j + 1] = klucz;
            }
        }

        static void Zadanie5()
        {
            Console.WriteLine("Zadanie 5 - Sortowanie (bąbelkowe lub wstawianie)");

            Console.Write("Ile liczb chcesz wczytać? ");
            int n = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Wybierz: 1 - wczytywanie, 2 - losowanie");
            int wybor = int.Parse(Console.ReadLine()!);

            int[] tab = (wybor == 1) ? WczytajLiczby(n) : LosujLiczby(n);

            Console.WriteLine("Wybierz metodę sortowania: 1 - bąbelkowe, 2 - wstawianie");
            int metoda = int.Parse(Console.ReadLine()!);

            if (metoda == 1) SortowanieBabelkowe(tab);
            else SortowanieWstawianie(tab);

            Console.WriteLine("Posortowane liczby: " + string.Join(", ", tab));
        }
    }
}
