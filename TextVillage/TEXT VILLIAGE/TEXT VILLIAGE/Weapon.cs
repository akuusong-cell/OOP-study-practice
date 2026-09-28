namespace TEXT_VILLIAGE;

public class Weapon : Item
{
    private int attack;
    public int Attack => attack;
    
    public Weapon(string name, int price, string explain, int buyPrice, int attack)
        : base(name, price, explain, buyPrice)
    {
        this.attack = attack;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"""
                           공격력 : {attack}
                           
                           """);    
    }
}