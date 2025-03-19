namespace apbd_03;

public abstract class Kontener
{
    /*
     * Masę ładunku (w kilogramach)
       Wysokość (w centymetrach)
       Waga w własna (waga samego kontenera, w kilogramach)
       Głębokość (w centymetrach)
       Numer seryjny
       Format numeru to KON-C-1
       Pierwszy człon numery to zawsze "KON"
       Drugi człon reprezentuje rodzaj kontenera
       Trzeci człon to liczba. Liczby powinny być unikalne. Nie powinno być możliwości powstania dwóch kontenerów o tym
       samym numerze. Numery powinny być generowane przez system.
       Maksymalna ładowność danego kontenera w kilogramach
     */

    protected double masa;
    protected double height;
    protected double own_masa;
    protected double depth;
    protected string serial;
    protected double max;
    
    private static int serializer = 1;
    

    private string typ = "00";

    protected Kontener(double height, double ownMasa, double depth, double max)
    {
        this.masa = masa;
        this.height = height;
        this.own_masa = ownMasa;
        this.depth = depth;
        this.max = max;

        this.serial = "KON-" + typ + "-" +
                      (serializer.ToString().Length < 10 ? "0" + serializer.ToString() : serializer.ToString());
    }

    protected static int getNextSerial()
    {
        return serializer++;
    }

    public abstract string empty();
    
    public abstract string fill(double how_much);

    public double getMasaCalkowita()
    {
        return masa + own_masa;
    }

    public string getSerial()
    {
        return serial;
    }

}