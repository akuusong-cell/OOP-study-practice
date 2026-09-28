namespace TEXT_VILLIAGE;

public class Player
{
    private int gold;
    private List<Item> items;

    public int Gold => gold;
    public List<Item> Items => items;

    public Player()
    {
        gold = 500;
        
        items = new List<Item>();
        items.Add(new Weapon("나무검", 100, "적당히 쓸만한 무난한 검", 70, 5));
        items.Add(new Consumable("껌", 100, "슬라임의 침으로 만든 껌이다. (상점 주인이 좋아함)", 300, "씹으면 기분이 좋아진다."));
    }

    public void ShowInventory()
    {
        int num = 1;
        Console.WriteLine("""
                          
                          ====== 인벤토리 ======
                          """);

        foreach (Item item in items)
        {
            Console.WriteLine($"# {num}");
            item.ShowInfo();
            num++;
        }

        Console.WriteLine("====================");
    }

    public bool Buy(Item item)
    {
        if (gold >= item.Price)
        {
            items.Add(item);
            gold -= item.Price;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Sell(int num)
    {
        gold += items[num - 1].BuyPrice;
        items.RemoveAt(num - 1);
    }
}