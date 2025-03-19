namespace apbd_03;

public class Kontener_Cieczowy : Kontener, IHazardNotifier
{
    private string type = "L";
    private bool isDangerous;
    

    public Kontener_Cieczowy(double height, double ownMasa, double depth,double max, bool isDangerous) : base(height, ownMasa, depth,max)
    {
        this.isDangerous = isDangerous;
        int nextSerial = getNextSerial();
        this.serial = "KON-" + type + "-" + (nextSerial.ToString().Length == 1 ? "0" + nextSerial.ToString() : nextSerial.ToString());
    }
    
    public override string ToString()
    {
        return serial + "(" + masa + "kg, " + this.own_masa + "kg, " + this.height + "cm, "+  this.depth + "cm)";
    }
    
    public override string empty()
    {
        this.masa = 0;
        return "Operacja opróżniania udana!";
    }

    public override string fill(double how_much)
    {
        if (isDangerous)
        {
            if (this.masa + how_much > max * 0.9)
            {
                Console.WriteLine("Uwaga kontener (" + serial + ") został zalany ponad swój limit!!!");
            }
            else
            {
                this.masa += how_much;
            }
        }
        else if (this.masa + how_much > max)
        {
            Console.Error.WriteLine("Kontener cieczowy zostal przepełniony!");
        }
        else
        {
            this.masa += how_much;
        }


        return "Kontener: " + this.serial + " został załadowany:"
               + how_much + "kg (całkowita masa: " + this.masa +
               "kg) -- " + this.isDangerous;
    }


    public void HazardRaiser()
    {
        Console.WriteLine("Uwaga kontener (" + serial + ") grozi wybuchem!!!");
    }
}