namespace apbd_03;

public class Kontenerowiec
{
    /*
     * Wszystkie kontenery jakie dany statek transportuje
       Maksymalna prędkość jaką kontenerowiec może rozwijać (w węzłach)
       Maksymalna liczba kontenerów, które mogą być przewożone
       Maksymalna waga wszystkich kontenerów jakie mogą być transportowane poprzez statek (w tonach)
     */

    private List<Kontener> sklad = [];
    private List<String> manifest = [];
    private double max_speed;
    private int max_carry;
    private double max_weight_tonnes;
    
    //extra
    private string nazwa_statku;

    public Kontenerowiec(string nazwaStatku, double maxSpeed, int maxCarry_liczba_kontenerow, double maxWeightTonnes)
    {
        max_speed = maxSpeed;
        max_carry = maxCarry_liczba_kontenerow;
        max_weight_tonnes = maxWeightTonnes;
        nazwa_statku = nazwaStatku;
    }

    public bool zaladuj(Kontener kontener)
    {
        
        //sprawdzamy czy jest miejsce
        if (sklad.Count >= max_carry)
        {
            Console.WriteLine("["+ this.nazwa_statku  + "]Brak miejsca na statku!!!");
            return false;
        }
        
        
        //sprawdzamy czy waga nie przekracza 
        double waga_combined = sklad.Sum((kon) => {return kon.getMasaCalkowita();});
        waga_combined += kontener.getMasaCalkowita(); //bierzemy pod uwage jak dodamy ten kontener nowy!!!

        if (waga_combined > max_weight_tonnes * 1000)
        {
            Console.WriteLine("["+ this.nazwa_statku  + "]Statek nie ma wyporności na kolejny kontener!!!");
            return false;
        }
        
        
        sklad.Add(kontener);
        manifest.Add("Dodano:" + kontener);
        return true;
    }


    public void rozladuj(String serial)
    {
        //jak taki istnieje to
        if (sklad.Exists((kon) => { return kon.getSerial().Equals(serial); }))
        {   
            //kopiuje sobie o nim info do manifestu bo tak o
            string info = sklad.Find((kon) => { return kon.getSerial().Equals(serial); }).ToString();
            //kontener istnieje
            //usuwam wszystkie takie ale jest i tak jeden bo serial unikatowy
            sklad.RemoveAll((kon) => {return kon.getSerial().Equals(serial);});
            manifest.Add("Usuwam:" + info);
        }
        else
        {   
            //jak nie ma takiego to mowie ze szuaklem i nic nie robie es
            Console.WriteLine("["+ this.nazwa_statku  + "]Takiego kontenera nie ma na statku!!!");
            manifest.Add("Szukam:" + serial);
        }


    }
    
    //nadpisanie skladu
    public void setSklad(List<Kontener> nowy_sklad)
    {
        this.sklad = nowy_sklad;
    }

    public void przenies(string serial, Kontenerowiec statek_docelowy)
    {   
        //jezeli taki kontener istnieje 
        if (this.sklad.Exists((kon) => { return kon.getSerial().Equals(serial); }))
        {   
            //szukam go i kopiuje
            Kontener kon_do_ruszenia = this.sklad.Find((kon) => { return kon.getSerial().Equals(serial); });
            if (statek_docelowy.zaladuj(kon_do_ruszenia)) //jezeli moge zaladowac na nowy statek
            {
                //usuwam bo juz sie zaladowal
                sklad.Remove(kon_do_ruszenia);
                manifest.Add("Przenosze:" + kon_do_ruszenia + "-> " + statek_docelowy.nazwa_statku);
                //statek_docelowy.zaladuj(kon_do_ruszenia);
            }
            
            
        }
        
        
        
    }

    public override string ToString()
    {
        string seriale_kontenerow = "";

        foreach (Kontener kon in sklad)
        {
            seriale_kontenerow += kon.getSerial();
            seriale_kontenerow += "\n";
        }

        return "====== " + nazwa_statku + " ======\n" +
               "Max speed: " + max_speed +
               "\nMax carry: " + max_carry +
               "\nMax weight: " + max_weight_tonnes * 1000 + "kg\n" +
               "Skład statku:\n" +
               seriale_kontenerow +
               "Manifest statku:\n" + string.Join('\n', manifest) + "\n===============";
    }
}