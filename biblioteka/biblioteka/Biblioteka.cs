
using System;
using System.Collections.Generic;
using System.Linq;

public class Biblioteka
{
    public List<Pozycja> Pozycje;
    public List<Czytelnik> Czytelnicy;
    public List<Wypozyczenie> Wypozyczenia;

    PlikPozycje pp = new PlikPozycje();
    PlikCzytelnicy pc = new PlikCzytelnicy();
    PlikWypozyczenia pw = new PlikWypozyczenia();

    public Biblioteka()
    {
        Pozycje = pp.Wczytaj();
        Czytelnicy = pc.Wczytaj();
        Wypozyczenia = pw.Wczytaj();
    }

    public void DodajCzytelnika(string imie, string nazwisko)
    {
        int id = Czytelnicy.Count == 0 ? 1 : Czytelnicy.Max(x => x.Id) + 1;
        Czytelnicy.Add(new Czytelnik { Id = id, Imie = imie, Nazwisko = nazwisko });
        pc.Zapisz(Czytelnicy);
        Console.WriteLine("\n| Dodano czytelnika |");
    }

    public void DodajPozycje(Pozycja p)
    {
        int id = Pozycje.Count == 0 ? 1 : Pozycje.Max(x => x.Id) + 1;
        p.Id = id;
        Pozycje.Add(p);
        pp.Zapisz(Pozycje);
        Console.WriteLine("\n| Dodano " + p.GetType().Name + " |");
    }

    public void WypozyczPozycje(int idCzytelnika, int idPozycji)
{
   
    Czytelnik czytelnik = Czytelnicy.FirstOrDefault(x => x.Id == idCzytelnika);
    if (czytelnik == null)
    {
        Console.WriteLine("\n| Nie znaleziono czytelnika o podanym ID |");
        return;
    }

   
    Pozycja p = Pozycje.FirstOrDefault(x => x.Id == idPozycji);
    if (p == null)
    {
        Console.WriteLine("\n| Nie ma takiej pozycji |");
        return;
    }

    
    if (!p.CzyDostepna)
    {
        Console.WriteLine("\n| Pozycja jest aktualnie niedostępna |");
        return;
    }

  
    p.CzyDostepna = false;
    Wypozyczenia.Add(new Wypozyczenie
    {
        IdCzytelnika = idCzytelnika,
        IdPozycji = idPozycji,
        DataWypozyczenia = DateTime.Now
    });

    pp.Zapisz(Pozycje);
    pw.Zapisz(Wypozyczenia);

    Console.WriteLine("\n| Pozycja wypożyczona |");
}

    public void ZwrocPozycje(int idPozycji)
    {
        Wypozyczenie w = Wypozyczenia.FirstOrDefault(x => x.IdPozycji == idPozycji && x.DataZwrotu == null);
        if (w == null)
        {
            Console.WriteLine("\n| Ta pozycja nie jest wypożyczona |");
            return;
        }

        w.DataZwrotu = DateTime.Now;
        Pozycja p = Pozycje.First(x => x.Id == idPozycji);
        p.CzyDostepna = true;

        pw.Zapisz(Wypozyczenia);
        pp.Zapisz(Pozycje);

        Console.WriteLine("\n| Pozycja zwrócona | Kara: " + w.ObliczKare() + " zł |");
    }

    public void PokazPozycje()
    {
        foreach (Pozycja p in Pozycje) p.Wyswietl();
    }

    public void PokazWypozyczeniaCzytelnika(int idCzytelnika)
    {
        Console.WriteLine("\n| Wypożyczenia czytelnika |");
        foreach (Wypozyczenie w in Wypozyczenia)
        {
            if (w.IdCzytelnika == idCzytelnika && w.DataZwrotu == null)
            {
                Pozycja p = Pozycje.First(x => x.Id == w.IdPozycji);
                Console.WriteLine("Id: " + p.Id + " | Tytuł: " + p.Tytul + " | Data wypożyczenia: " + w.DataWypozyczenia.ToString("dd:MM:yyyy"));
            }
        }
    }
    public void PokazCzytelnikow()
    {
        foreach (var c in Czytelnicy)
        {
            Console.WriteLine("Id: " + c.Id + " | Imię: " + c.Imie + " | Nazwisko: " + c.Nazwisko);
        }
    }

    public void UsunPozycje(int idPozycji)
    {
       
        Pozycja p = Pozycje.FirstOrDefault(x => x.Id == idPozycji);
        if (p != null)
        {
            Pozycje.Remove(p);
            pp.Zapisz(Pozycje);
            Console.WriteLine("\n| Pozycja została usunięta |");
        }
        else
        {
            Console.WriteLine("\n| Nie znaleziono pozycji o takim ID |");
        }
    }

    public void UsunCzytelnika(int idCzytelnika)
    {
        Czytelnik c = Czytelnicy.FirstOrDefault(x => x.Id == idCzytelnika);
        if (c != null)
        {
            Czytelnicy.Remove(c);
            pc.Zapisz(Czytelnicy);
            Console.WriteLine("\n| Czytelnik został usunięty |");
        }
        else
        {
            Console.WriteLine("\n| Nie znaleziono czytelnika o takim ID |");
        }
    }

    public void SprawdzDostepnosc(int idPozycji)
    {
        Pozycja p = Pozycje.FirstOrDefault(x => x.Id == idPozycji);
        if (p != null)
        {
            Console.WriteLine("\n| Pozycja jest: " + (p.CzyDostepna ? "Dostępna" : "Niedostępna") + " |");
        }
    }
}