using System;
using System.Collections.Generic;

//zad1
//class Shape
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public int Height { get; set; }
//    public int Width { get; set; }

//    public Shape(int x, int y, int height, int width)
//    {
//        X = x;
//        Y = y;
//        Height = height;
//        Width = width;
//    }

//    public virtual void Draw()
//    {
//        Console.WriteLine("Rysuję figurę");
//    }
//}

//class Rectangle : Shape
//{
//    public Rectangle(int x, int y, int height, int width)
//        : base(x, y, height, width)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine("Rysuję prostokąt");
//    }
//}

//class Triangle : Shape
//{
//    public Triangle(int x, int y, int height, int width)
//        : base(x, y, height, width)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine("Rysuję trójkąt");
//    }
//}

//class Circle : Shape
//{
//    public Circle(int x, int y, int height, int width)
//        : base(x, y, height, width)
//    {
//    }

//    public override void Draw()
//    {
//        Console.WriteLine("Rysuję koło");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        List<Shape> shapes = new List<Shape>();

//        shapes.Add(new Rectangle(0, 0, 10, 20));
//        shapes.Add(new Triangle(5, 5, 15, 15));
//        shapes.Add(new Circle(10, 10, 10, 10));

//        foreach (Shape shape in shapes)
//        {
//            shape.Draw();
//        }

//        Console.ReadKey();
//    }
//}
//Zad2
//abstract class Osoba
//{
//    protected string firstName;
//    protected string lastName;
//    protected string pesel;

//    public void SetFirstName(string firstName)
//    {
//        this.firstName = firstName;
//    }

//    public void SetLastName(string lastName)
//    {
//        this.lastName = lastName;
//    }

//    public void SetPesel(string pesel)
//    {
//        this.pesel = pesel;
//    }

//    public int GetAge(DateTime dateToCheck)
//    {
//        int year = int.Parse(pesel.Substring(0, 2));
//        int month = int.Parse(pesel.Substring(2, 2));
//        int day = int.Parse(pesel.Substring(4, 2));

//        if (month > 20)
//        {
//            year += 2000;
//            month -= 20;
//        }
//        else
//        {
//            year += 1900;
//        }

//        DateTime birthDate = new DateTime(year, month, day);
//        int age = dateToCheck.Year - birthDate.Year;

//        if (dateToCheck < birthDate.AddYears(age))
//            age--;

//        return age;
//    }

//    public string GetGender()
//    {
//        int digit = int.Parse(pesel[9].ToString());
//        return digit % 2 == 0 ? "Kobieta" : "Mężczyzna";
//    }

//    public abstract string GetEducationInfo();
//    public virtual string GetFullName()
//    {
//        return $"{firstName} {lastName}";
//    }

//    public abstract bool CanGoAloneToHome(DateTime dateToCheck);
//}

//// ================= UCZEN =================

//class Uczen : Osoba
//{
//    protected string school;
//    protected bool canGoHomeAlonePermission;

//    public void SetSchool(string school)
//    {
//        this.school = school;
//    }

//    public void ChangeSchool(string newSchool)
//    {
//        school = newSchool;
//    }

//    public void SetCanGoHomeAlone(bool canGoHomeAlone)
//    {
//        canGoHomeAlonePermission = canGoHomeAlone;
//    }

//    public override string GetEducationInfo()
//    {
//        return $"Uczeń szkoły: {school}";
//    }

//    public override bool CanGoAloneToHome(DateTime dateToCheck)
//    {
//        int age = GetAge(dateToCheck);

//        if (age >= 12)
//            return true;

//        return canGoHomeAlonePermission;
//    }
//}

//// ================= NAUCZYCIEL =================

//class Nauczyciel : Uczen
//{
//    public string TytulNaukowy { get; set; }
//    public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

//    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
//    {
//        Console.WriteLine($"Uczniowie, którzy mogą iść sami do domu ({dateToCheck.ToShortDateString()}):");

//        foreach (Uczen uczen in PodwladniUczniowie)
//        {
//            if (uczen.CanGoAloneToHome(dateToCheck))
//            {
//                Console.WriteLine(uczen.GetFullName());
//            }
//        }
//    }

//    public override string GetEducationInfo()
//    {
//        return $"Nauczyciel ({TytulNaukowy})";
//    }
//}

//// ================= MAIN =================

//class Program
//{
//    static void Main()
//    {
//        DateTime today = DateTime.Now;

//        Uczen u1 = new Uczen();
//        u1.SetFirstName("Jan");
//        u1.SetLastName("Kowalski");
//        u1.SetPesel("11210112345"); // 2011
//        u1.SetSchool("SP 1");
//        u1.SetCanGoHomeAlone(false);

//        Uczen u2 = new Uczen();
//        u2.SetFirstName("Anna");
//        u2.SetLastName("Nowak");
//        u2.SetPesel("08210112346"); // 2008
//        u2.SetSchool("SP 1");
//        u2.SetCanGoHomeAlone(false);

//        Uczen u3 = new Uczen();
//        u3.SetFirstName("Piotr");
//        u3.SetLastName("Zieliński");
//        u3.SetPesel("13210112347"); // 2013
//        u3.SetSchool("SP 1");
//        u3.SetCanGoHomeAlone(true);

//        Nauczyciel n = new Nauczyciel();
//        n.SetFirstName("Maria");
//        n.SetLastName("Wiśniewska");
//        n.SetPesel("75010112348");
//        n.TytulNaukowy = "mgr";

//        n.PodwladniUczniowie.Add(u1);
//        n.PodwladniUczniowie.Add(u2);
//        n.PodwladniUczniowie.Add(u3);

//        n.WhichStudentCanGoHomeAlone(today);

//        Console.ReadKey();
//    }
////}
//Zad3
//using System;
//using System.Collections.Generic;

//// ===================== 3a =====================
//interface IOsoba
//{
//    string Imie { get; set; }
//    string Nazwisko { get; set; }
//    string ZwrocPelnaNazwe();
//}

//class Osoba : IOsoba
//{
//    public string Imie { get; set; }
//    public string Nazwisko { get; set; }

//    public Osoba(string imie, string nazwisko)
//    {
//        Imie = imie;
//        Nazwisko = nazwisko;
//    }

//    public string ZwrocPelnaNazwe()
//    {
//        return $"{Imie} {Nazwisko}";
//    }
//}

//// ===================== 3d =====================
//interface IStudent : IOsoba
//{
//    string Uczelnia { get; set; }
//    string Kierunek { get; set; }
//    int Rok { get; set; }
//    int Semestr { get; set; }

//    string WypiszPelnaNazweIUczelnie(); // <-- teraz metoda jest w interfejsie
//}

//class Student : IStudent
//{
//    public string Imie { get; set; }
//    public string Nazwisko { get; set; }
//    public string Uczelnia { get; set; }
//    public string Kierunek { get; set; }
//    public int Rok { get; set; }
//    public int Semestr { get; set; }

//    public Student(string imie, string nazwisko, string uczelnia, string kierunek, int rok, int semestr)
//    {
//        Imie = imie;
//        Nazwisko = nazwisko;
//        Uczelnia = uczelnia;
//        Kierunek = kierunek;
//        Rok = rok;
//        Semestr = semestr;
//    }

//    public string ZwrocPelnaNazwe()
//    {
//        return $"{Imie} {Nazwisko}";
//    }

//    public virtual string WypiszPelnaNazweIUczelnie()
//    {
//        return $"{Imie} {Nazwisko} – {Kierunek} {Rok} {Uczelnia}";
//    }
//}

//// ===================== 3e =====================
//class StudentWSIiZ : Student
//{
//    public StudentWSIiZ(string imie, string nazwisko, string kierunek, int rok, int semestr)
//        : base(imie, nazwisko, "WSIiZ", kierunek, rok, semestr)
//    {
//    }

//    public override string WypiszPelnaNazweIUczelnie()
//    {
//        return base.WypiszPelnaNazweIUczelnie();
//    }
//}

//// ===================== 3b i 3c =====================
//static class Rozszerzenia
//{
//    public static void WypiszOsoby(this List<IOsoba> lista)
//    {
//        foreach (var osoba in lista)
//        {
//            Console.WriteLine(osoba.ZwrocPelnaNazwe());
//        }
//    }

//    public static void PosortujOsobyPoNazwisku(this List<IOsoba> lista)
//    {
//        lista.Sort((a, b) => string.Compare(a.Nazwisko, b.Nazwisko));
//    }

//    public static void WypiszOsobyIUczelnie(this List<IStudent> lista)
//    {
//        foreach (var student in lista)
//        {
//            Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
//        }
//    }
//}

//// ===================== MAIN =====================
//class Program
//{
//    static void Main()
//    {
//        // ===== 3a =====
//        var listaOsob = new List<IOsoba>
//        {
//            new Osoba("Jan", "Kowalski"),
//            new Osoba("Anna", "Nowak"),
//            new Osoba("Piotr", "Zieliński")
//        };

//        Console.WriteLine("Lista osób:");
//        listaOsob.WypiszOsoby();

//        Console.WriteLine("\nPosortowana lista osób po nazwisku:");
//        listaOsob.PosortujOsobyPoNazwisku();
//        listaOsob.WypiszOsoby();

//        // ===== 3d =====
//        var listaStudentow = new List<IStudent>
//        {
//            new Student("Adam", "Nowicki", "WSIiZ", "4IID-P", 2018, 7),
//            new Student("Beata", "Kowalska", "WSIiZ", "3IIA-P", 2019, 5)
//        };

//        Console.WriteLine("\nLista studentów z pełnymi informacjami:");
//        listaStudentow.WypiszOsobyIUczelnie();

//        // ===== 3e =====
//        var listaWSIiZ = new List<IStudent>
//        {
//            new StudentWSIiZ("Marek", "Wiśniewski", "4IID-P", 2018, 7),
//            new StudentWSIiZ("Ewa", "Nowak", "3IIA-P", 2019, 5)
//        };

//        Console.WriteLine("\nLista studentów WSIiZ:");
//        listaWSIiZ.WypiszOsobyIUczelnie();

//        Console.ReadKey();
//    }
//}
