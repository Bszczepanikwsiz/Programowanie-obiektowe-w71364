
using System;
using System.Collections.Generic;
using System.IO;


public class PlikCzytelnicy
{
    string sciezka = "czytelnicy.txt";

    public List<Czytelnik> Wczytaj()
    {
        var lista = new List<Czytelnik>();
        if (!File.Exists(sciezka)) return lista;
        foreach (var linia in File.ReadAllLines(sciezka))
        {
            var d = linia.Split(';');
            lista.Add(new Czytelnik { Id = int.Parse(d[0]), Imie = d[1], Nazwisko = d[2] });
        }
        return lista;
    }

    public void Zapisz(List<Czytelnik> lista)
    {
        var linie = new List<string>();
        foreach (var c in lista) linie.Add(c.Id + ";" + c.Imie + ";" + c.Nazwisko);
        File.WriteAllLines(sciezka, linie);
    }
}


public class PlikPozycje
{
    string sciezka = "pozycje.txt";

    public List<Pozycja> Wczytaj()
    {
        var lista = new List<Pozycja>();
        if (!File.Exists(sciezka)) return lista;

        foreach (var linia in File.ReadAllLines(sciezka))
        {
            var d = linia.Split(';');
            string typ = d[0];
            int id = int.Parse(d[1]);
            string tytul = d[2];
            bool dostepnosc = bool.Parse(d[3]);

            Pozycja p = null;

            if (typ == "Ksiazka")
            {
                p = new Ksiazka();
                ((Ksiazka)p).Autor = d[4];
            }
            else if (typ == "Audiobook")
            {
                p = new Audiobook();
                ((Audiobook)p).Narrator = d[4];
            }
            else if (typ == "FilmDVD")
            {
                p = new FilmDVD();
                ((FilmDVD)p).Rezyser = d[4];
            }
            else if (typ == "Czasopismo")
            {
                p = new Czasopismo();
                ((Czasopismo)p).Numer = int.Parse(d[4]);
            }

            if (p != null)
            {
                p.Id = id;
                p.Tytul = tytul;
                p.CzyDostepna = dostepnosc;
                lista.Add(p);
            }
        }

        return lista;
    }

    public void Zapisz(List<Pozycja> lista)
    {
        var linie = new List<string>();
        foreach (var p in lista)
        {
            string typ = p.GetType().Name;
            string extra = "";

            if (p is Ksiazka) extra = ((Ksiazka)p).Autor;
            else if (p is Audiobook) extra = ((Audiobook)p).Narrator;
            else if (p is FilmDVD) extra = ((FilmDVD)p).Rezyser;
            else if (p is Czasopismo) extra = ((Czasopismo)p).Numer.ToString();

            linie.Add(typ + ";" + p.Id + ";" + p.Tytul + ";" + p.CzyDostepna + ";" + extra);
        }

        File.WriteAllLines(sciezka, linie);
    }
}


public class PlikWypozyczenia
{
    string sciezka = "wypozyczenia.txt";

    public List<Wypozyczenie> Wczytaj()
    {
        var lista = new List<Wypozyczenie>();
        if (!File.Exists(sciezka)) return lista;

        foreach (var linia in File.ReadAllLines(sciezka))
        {
            var d = linia.Split(';');
            var w = new Wypozyczenie();
            w.IdCzytelnika = int.Parse(d[0]);
            w.IdPozycji = int.Parse(d[1]);
            w.DataWypozyczenia = DateTime.Parse(d[2]);
            if (d[3] != "") w.DataZwrotu = DateTime.Parse(d[3]);
            lista.Add(w);
        }
        return lista;
    }

    public void Zapisz(List<Wypozyczenie> lista)
    {
        var linie = new List<string>();
        foreach (var w in lista)
        {
            string dataZwrotu = w.DataZwrotu.HasValue ? w.DataZwrotu.Value.ToString() : "";
            linie.Add(w.IdCzytelnika + ";" + w.IdPozycji + ";" + w.DataWypozyczenia + ";" + dataZwrotu);
        }
        File.WriteAllLines(sciezka, linie);
    }
}
