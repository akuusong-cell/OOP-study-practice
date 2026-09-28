namespace TEXT_VILLIAGE;

public class ShopNpc : NPC
{
    private string selling;
    private string buying;
    private string showInfo;
    
    public string Selling => selling;
    public string Buying => buying;
    public string ShowInfo => showInfo;
    

    public ShopNpc(string name, int age, string job, string hello, string selling, string buying, string showInfo)
    : base(name, age, job, hello)
    {
        this.selling = selling;
        this.buying = buying;
        this.showInfo = showInfo;
    }
}