namespace apbd_03;

public class Kontener_Chlodniczy : Kontener
{
    
    private string type = "C";
    
    
    //pola specjalne
    private string rodzaj_produktu;
    private double temp;
    

    public Kontener_Chlodniczy(double height, double ownMasa, double depth, double max, string rodzajProduktu, double temperatura) : base(height, ownMasa, depth,max)
    {
        this.rodzaj_produktu = rodzajProduktu;
        this.temp = temperatura;
        
        int nextSerial = getNextSerial();
        serial = "KON-" + type + "-" + (nextSerial.ToString().Length == 1 ? "0" + nextSerial.ToString() : nextSerial.ToString());
        
    }
    
    public override string ToString()
    {
        return serial + "(" + masa + "kg, " + this.own_masa + "kg, " + this.height + "cm, "+  this.depth + "cm) -- " + "[" + this.rodzaj_produktu + "] (" + this.temp + ") Celcius";
    }

    public override string empty()
    {
        this.masa = 0;
        return "Operacja opróżniania udana!";
    }

    public string fill(double how_much,string rodzajProduktu)
    {
        
        if (this.masa + how_much > this.max || !this.rodzaj_produktu.Equals(rodzajProduktu))
        {
            this.masa += how_much;
            Console.Error.WriteLine("Kontener chłodniczy zostal przepełniony lub zły typ produktu!!!");
            throw new OverfillException();
        }
        else
        {
            this.masa += how_much; 
        }

        return "Kontener: " + this.serial + " został załadowany:"
               + how_much + "kg (całkowita masa: " + this.masa +
               "kg) -- " + "[" + this.rodzaj_produktu + "] (" + this.temp + ") Celcius";
    }

    public override string fill(double how_much)
    {
        this.fill(how_much, this.rodzaj_produktu);
        return "Domyślny typ produktu!!!";
    }
}