using System;
using System.Collections.Generic;

namespace POO_Zadania
{
    // ===== ZADANIE 1a =====
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName => firstName;
        public string LastName => lastName;
        public int Age => age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public virtual void View()
        {
            Console.WriteLine($"{FirstName} {LastName}, wiek: {Age}");
        }
    }

    class Book
    {
        protected string title;
        protected Person author;
        protected DateTime publishDate;

        public string Title => title;

        public Book(string title, Person author, DateTime publishDate)
        {
            this.title = title;
            this.author = author;
            this.publishDate = publishDate;
        }

        public virtual void View()
        {
            Console.WriteLine($"Tytuł: {title}, Autor: {author.FirstName} {author.LastName}, Rok: {publishDate.Year}");
        }
    }

    // ===== ZADANIE 1b–1e =====
    class Reader : Person
    {
        protected List<Book> readBooks = new List<Book>();

        public Reader(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        { }

        public void AddBook(Book book)
        {
            readBooks.Add(book);
        }

        public void ViewBook()
        {
            Console.WriteLine("Przeczytane książki:");
            foreach (var book in readBooks)
            {
                book.View();
            }
        }

        public override void View()
        {
            base.View();
            ViewBook();
        }
    }

    // ===== ZADANIE 1f =====
    class Reviewer : Reader
    {
        private Random random = new Random();

        public Reviewer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        { }

        public override void View()
        {
            base.View();
            Console.WriteLine("Oceny:");
            foreach (var book in readBooks)
            {
                Console.WriteLine($"{book.Title} - ocena: {random.Next(1, 6)}");
            }
        }
    }

    // ===== ZADANIE 1i–1j =====
    class AdventureBook : Book
    {
        private string location;

        public AdventureBook(string title, Person author, DateTime publishDate, string location)
            : base(title, author, publishDate)
        {
            this.location = location;
        }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Miejsce akcji: {location}");
        }
    }

    class DocumentaryBook : Book
    {
        private string topic;

        public DocumentaryBook(string title, Person author, DateTime publishDate, string topic)
            : base(title, author, publishDate)
        {
            this.topic = topic;
        }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Temat: {topic}");
        }
    }

    // =======================
    class Program
    {
        static void Main()
        {
            Person author1 = new Person("Adam", "Mickiewicz", 55);
            Person author2 = new Person("Ryszard", "Kapuściński", 65);

            Book b1 = new AdventureBook("Pan Tadeusz", author1, new DateTime(1834, 1, 1), "Litwa");
            Book b2 = new DocumentaryBook("Cesarz", author2, new DateTime(1978, 1, 1), "Historia Etiopii");

            Reader r1 = new Reader("Jan", "Kowalski", 22);
            Reviewer rev1 = new Reviewer("Anna", "Nowak", 30);

            r1.AddBook(b1);
            rev1.AddBook(b1);
            rev1.AddBook(b2);

            // ===== ZADANIE 1g =====
            List<Person> people = new List<Person>();
            people.Add(r1);
            people.Add(rev1);

            foreach (var p in people)
            {
                Console.WriteLine("-----");
                p.View();
            }

            Console.ReadKey();
        }
    }




    //Zad2
    //class Samochod
    //{
    //    public string Marka { get; set; }
    //    public string Model { get; set; }
    //    public string Nadwozie { get; set; }
    //    public string Kolor { get; set; }
    //    public int RokProdukcji { get; set; }

    //    private int przebieg;
    //    public int Przebieg
    //    {
    //        get => przebieg;
    //        set
    //        {
    //            if (value >= 0)
    //                przebieg = value;
    //        }
    //    }

    //    public Samochod() // konstruktor z danymi od użytkownika
    //    {
    //        Console.Write("Marka: ");
    //        Marka = Console.ReadLine();
    //        Console.Write("Model: ");
    //        Model = Console.ReadLine();
    //        Console.Write("Nadwozie: ");
    //        Nadwozie = Console.ReadLine();
    //        Console.Write("Kolor: ");
    //        Kolor = Console.ReadLine();
    //        Console.Write("Rok produkcji: ");
    //        RokProdukcji = int.Parse(Console.ReadLine());
    //        Console.Write("Przebieg: ");
    //        Przebieg = int.Parse(Console.ReadLine());
    //    }

    //    public Samochod(string marka, string model, string nadwozie, string kolor, int rok, int przebieg)
    //    {
    //        Marka = marka;
    //        Model = model;
    //        Nadwozie = nadwozie;
    //        Kolor = kolor;
    //        RokProdukcji = rok;
    //        Przebieg = przebieg;
    //    }

    //    public virtual void View()
    //    {
    //        Console.WriteLine($"{Marka} {Model}, {Kolor}, {RokProdukcji}, przebieg: {Przebieg}");
    //    }
    //}

    //class SamochodOsobowy : Samochod
    //{
    //    private double waga;
    //    private double pojemnosc;

    //    public int IloscOsob { get; set; }

    //    public SamochodOsobowy() : base()
    //    {
    //        Console.Write("Waga (2–4.5t): ");
    //        waga = double.Parse(Console.ReadLine());

    //        Console.Write("Pojemność silnika (0.8–3.0): ");

    //        pojemnosc = double.Parse(Console.ReadLine());

    //        Console.Write("Ilość osób: ");
    //        IloscOsob = int.Parse(Console.ReadLine());
    //    }

    //    public override void View()
    //    {
    //        base.View();
    //        Console.WriteLine($"Waga: {waga}t, Silnik: {pojemnosc}, Osoby: {IloscOsob}");
    //    }

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("=== Samochód osobowy ===");
    //        SamochodOsobowy so = new SamochodOsobowy();

    //        Console.WriteLine("\n=== Samochód 1 (konstruktor z parametrami) ===");
    //        Samochod s1 = new Samochod(
    //            "Toyota",
    //            "Corolla",
    //            "Sedan",
    //            "Czarny",
    //            2018,
    //            85000
    //        );

    //        Console.WriteLine("\n=== Samochód 2 (konstruktor od użytkownika) ===");
    //        Samochod s2 = new Samochod();

    //        Console.WriteLine("\n=== Informacje o samochodach ===");
    //        so.View();
    //        Console.WriteLine("----------------");
    //        s1.View();
    //        Console.WriteLine("----------------");
    //        s2.View();

    //        Console.ReadKey();
    //    }

    //}
}