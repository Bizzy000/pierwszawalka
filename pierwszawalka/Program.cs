using System;
using System.ComponentModel;
Console.BackgroundColor = ConsoleColor.Cyan;
Console.WriteLine("Podaj swoje imie:");
string imie = Console.ReadLine()!;
Console.WriteLine("ile masz hp?:");
int hp = int.Parse(Console.ReadLine()!);
Console.WriteLine("liczba mikstur:");
int mikstury = int.Parse(Console.ReadLine()!);
Console.WriteLine("ile masz zlota?");
int zloto = int.Parse(Console.ReadLine()!);
int hpPrzeciwnika = 45;
int numerTury = 1;
int maxhp = 100;






Console.WriteLine("===Witaj Podrozniku===");
Console.WriteLine($"TURA: {numerTury}");
Console.WriteLine($"Bohater: {imie}");
Console.WriteLine($"HP: {hp}/{maxhp} | ZLOTO: {zloto} | MIKSTURY: {mikstury} ");
Console.WriteLine("                      ");
Console.WriteLine("                      ");
Console.WriteLine("1.Eksploruj Loch");
Console.WriteLine("2.Uzyj Mikstury");
Console.WriteLine("3.Odpocznij");
Console.WriteLine("4.Pokaz Staty");
Console.WriteLine("5.Zakoncz gre");
Console.WriteLine("OPCJA: ");
int menu = int.Parse(Console.ReadLine()!);

switch (menu)
{
    case 1:
        zloto += 10;
        hp -= 8;
        Console.WriteLine("zdobyles 10szt. zlota ale zaplaciles za to 8 pkt zycia");
        break;
    case 2:
        if (mikstury > 0)
        {
            hp += 20;
            mikstury--;
            Console.WriteLine($"Uzyto Potki, masz obecnie {hp} hp");
        }
        else if (hp > maxhp)
        {
            hp = maxhp;
        }
        break;
    case 3:
        if (zloto >= 3)
        {
            zloto -= 3;
            hp += 5;
        }
        break;


}

bool dobrakacja = false;
bool ucieczka = false;
while (hp > 0 && hpPrzeciwnika > 0)
{
    Console.WriteLine("==WYBIERZ AKCJE==");
    Console.WriteLine("1.ATAK");
    Console.WriteLine("2.POTKA");
    Console.WriteLine("3.UCIECZKA");
    Console.WriteLine("OPCJA: ");
    int walka = int.Parse(Console.ReadLine()!);

    switch (walka)
    {
        case 1:
            hpPrzeciwnika -= 12;
            dobrakacja = true;
            Console.WriteLine("Udalo sie zaatakowac przeciwnika");
            Console.WriteLine($"stats: hp{hp} hp oponenta:{hpPrzeciwnika} potki:{mikstury} TURA:{numerTury}");
            break;

        case 2:
            if (mikstury > 0)
            {
                hp += 15;
                mikstury--;
                dobrakacja = true;
                Console.WriteLine($"Uzyto Potki, masz obecnie {hp} hp");
                Console.WriteLine($"stats: hp{hp} hp oponenta:{hpPrzeciwnika} potki:{mikstury} TURA:{numerTury}");
            }
            else
            {
                Console.WriteLine("nie masz juz potek nobie");
                Console.WriteLine($"stats: hp{hp} hp oponenta:{hpPrzeciwnika} potki:{mikstury} TURA:{numerTury}");
            }
            break;

        case 3:
            ucieczka = true;
            dobrakacja = true;
            Console.WriteLine("Udalo sie ci sie uciec");
            break;

        default:
            Console.WriteLine("Nieznana opcja, ponow wybor");
            break;
    }

    if (dobrakacja)
    {
        if (hpPrzeciwnika > 0)
        {
            Console.WriteLine("dobra akcja, otrzymales 7 pkt obrazen");
            hp -= 7;
        }
        numerTury++;
    }
    if (ucieczka)
    {
        Console.WriteLine("Uciekles z pola walki");
        break;
    }
    else if (hp > 0 && hpPrzeciwnika <= 0)
    {
        Console.WriteLine("pokonales przeciwnika");
    }
    else if (hp <= 0 && hpPrzeciwnika > 0)
    {
        Console.WriteLine("zostales pokonany");
    }
}
