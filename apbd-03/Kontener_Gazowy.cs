namespace apbd_03;

public class Kontener_Gazowy : Kontener, IHazardNotifier
{
    private string type = "G";
    
    //pola specjalne
    private double pressure;

    public Kontener_Gazowy(double height, double ownMasa, double depth,double max,double pressure) : base(height, ownMasa, depth,max)
    {
        this.pressure = pressure;
        
        int nextSerial = getNextSerial();
        this.serial = "KON-" + type + "-" + (nextSerial.ToString().Length == 1 ? "0" + nextSerial.ToString() : nextSerial.ToString());
    }
    
    public override string ToString()
    {
        return serial + "(" + masa + "kg, " + this.own_masa + "kg, " + this.height + "cm, "+  this.depth + "cm)";
    }
    
    public override string empty()
    {
        this.masa = this.masa * 0.05;;
        return "Operacja opróżniania udana! (Pozostało 5% [" + this.masa +"])";
    }

    public override string fill(double how_much)
    {
        if (this.masa + how_much > this.max)
        {
            this.masa += how_much;
            Console.Error.WriteLine("Kontener gazowy zostal przepełniony!");
            throw new OverfillException();
        }
        else
        {
            this.masa += how_much; 
        }

        return "Kontener: " + this.serial + " został załadowany:"
               + how_much + "kg (całkowita masa: " + this.masa +
               "kg) -- " + this.pressure + " hPa";
    }

    public void HazardRaiser()
    {
        Console.WriteLine("Uwaga kontener (" + serial + ") grozi wybuchem!!!");
    }
}