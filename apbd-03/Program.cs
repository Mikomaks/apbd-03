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

Kontener_Cieczowy test2 = new Kontener_Cieczowy(1000,10,300,200,true);
Console.WriteLine(test2);

/*List<Kontener> kontenery = new List<Kontener>{test1,test2};

for (int i = 0; i < 10; i++)
{
    kontenery.Add(new Kontener_Chlodniczy(1,1,1,1,4));
}

Console.WriteLine(kontenery[^1]);*/

Console.WriteLine(test1.fill(100,produkty.ElementAt(^1).Key));