namespace TEXT_VILLIAGE;

public class Consumable : Item
{
    public string Effect { get; private set; }
    public Consumable(string name, int price, string explain, int buyPrice, string effect)
        : base(name, price, explain, buyPrice)
    {
        Effect = effect;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"효과 : {Effect}\n");
    }
}