// See https://aka.ms/new-console-template for more information

using apbd_03;

Dictionary<string, double> produkty = new Dictionary<string, double>
{
    {"Bananas",13.3},
    {"Chocolate",18},
    {"Fish",2},
    {"Meat",-15},
    {"Ice cream",-18},
    {"Frozen pizza",-30},
    {"Cheese",7.2},
    {"Sausages",5},
    {"Butter",20.5},
    {"Eggs",19}
};

Kontener_Chlodniczy test1 = new Kontener_Chlodniczy(1000,10,300,2000,
    produkty.ElementAt(^1).Key,produkty.ElementAt(^1).Value);
Console.WriteLine(test1);

Kontener_Cieczowy test2 = new Kontener_Cieczowy(1000,10,300,100,true);
Console.WriteLine(test2);

/*
 List<Kontener> kontenery = new List<Kontener>{test1,test2};

for (int i = 0; i < 10; i++)
{
    kontenery.Add(new Kontener_Chlodniczy(1,1,1,1,4));
}

Console.WriteLine(kontenery[^1]);*/

Console.WriteLine(test1.fill(100,produkty.ElementAt(^1).Key));

Console.WriteLine(test2.fill(90));
Console.WriteLine(test2);
Console.WriteLine(test2.empty());
Console.WriteLine(test2);

Console.WriteLine();

Kontener_Gazowy test3 = new Kontener_Gazowy(120,300,1050,1000,1200);
Console.WriteLine(test3);
Console.WriteLine(test3.fill(1000));
Console.WriteLine(test3);
Console.WriteLine(test3.empty());
Console.WriteLine(test3);

//test3.fill(1000);

Kontenerowiec statek = new Kontenerowiec("Czarna perła",10,100,1000);
statek.zaladuj(test1);
statek.zaladuj(test2);
//statek.zaladuj(test3);

//statek.rozladuj("KON-C-01");
//Console.WriteLine(statek);

Kontenerowiec statek_krzak = new Kontenerowiec("Krzak",1,5,10);
//statek.przenies("KON-L-02", statek_krzak);
List<Kontener> nowy_sklad = new List<Kontener>{test1,test2,test3};
//statek_krzak.setSklad(nowy_sklad);

statek.zamien(test3,test1.getSerial());

Console.WriteLine(statek);
//Console.WriteLine(statek_krzak);


/*testy:
❤️Stworzenie kontenera danego typu
❤️Załadowanie ładunku do danego kontenera
❤️Załadowanie kontenera na statek
❤️Załadowanie listy kontenerów na statek
❤️Usunięcie kontenera ze statku
❤️Rozładowanie kontenera
❤️Zastąpienie kontenera na statku o danym numerze innym kontenerem
❤️Możliwość przeniesienie kontenera między dwoma statkami
❤️Wypisanie informacji o danym kontenerze
❤️Wypisanie informacji o danym statku i jego ładunku
*/