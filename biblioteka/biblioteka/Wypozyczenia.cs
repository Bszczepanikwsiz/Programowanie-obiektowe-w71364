using System;

public class Wypozyczenie
{
    public int IdCzytelnika;
    public int IdPozycji;
    public DateTime DataWypozyczenia;
    public DateTime? DataZwrotu;

    public double ObliczKare()
    {
        if (DataZwrotu == null) return 0;
        int opoznienie = (DataZwrotu.Value - DataWypozyczenia).Days - 14;
        if (opoznienie > 0) return opoznienie * 1.5;
        return 0;
    }
}
