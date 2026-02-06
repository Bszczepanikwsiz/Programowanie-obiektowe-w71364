using System;

public class Pozycja
{
    public int Id;
    public string Tytul;
    public bool CzyDostepna = true;

    public virtual void Wyswietl()
    {
        Console.WriteLine("Id: " + Id + " | Tytuł: " + Tytul + " | Dostępność: " + (CzyDostepna ? "Dostępna" : "Niedostępna"));
    }
}

public class Ksiazka : Pozycja
{
    public string Autor;

    public override void Wyswietl()
    {
        Console.WriteLine("Id: " + Id + " | Książka: " + Tytul + " | Autor: " + Autor + " | Dostępność: " + (CzyDostepna ? "Dostępna" : "Niedostępna"));
    }
}

public class Audiobook : Pozycja
{
    public string Narrator;

    public override void Wyswietl()
    {
        Console.WriteLine("Id: " + Id + " | Audiobook: " + Tytul + " | Narrator: " + Narrator + " | Dostępność: " + (CzyDostepna ? "Dostępna" : "Niedostępna"));
    }
}

public class FilmDVD : Pozycja
{
    public string Rezyser;

    public override void Wyswietl()
    {
        Console.WriteLine("Id: " + Id + " | Film DVD: " + Tytul + " | Reżyser: " + Rezyser + " | Dostępność: " + (CzyDostepna ? "Dostępna" : "Niedostępna"));
    }
}

public class Czasopismo : Pozycja
{
    public int Numer;

    public override void Wyswietl()
    {
        Console.WriteLine("Id: " + Id + " | Czasopismo: " + Tytul + " | Numer: " + Numer + " | Dostępność: " + (CzyDostepna ? "Dostępna" : "Niedostępna"));
    }
}