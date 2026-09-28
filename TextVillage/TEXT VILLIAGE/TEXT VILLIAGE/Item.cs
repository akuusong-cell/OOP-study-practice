namespace TEXT_VILLIAGE;

public class Item
{
    protected string name;
    protected int price;
    protected string explain;
    protected int buyPrice;

    public string Name => name;
    public int Price => price;
    public string Explain => explain;
    public int BuyPrice => buyPrice;

    public Item(string name, int price, string explain, int buyPrice)
    {
        this.name = name;
        this.price = price;
        this.explain = explain;
        this.buyPrice = buyPrice;
    }
    
    // 동일한 구조를 가진 여러 아이템을 Item 객체로 생성하도록 구성
    public virtual void ShowInfo()
    {
        Console.WriteLine($"""
                          이름 : {this.name}
                          가격 : {this.price}
                          정보: {this.explain}
                          """);
    }
}