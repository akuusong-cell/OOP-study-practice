namespace TEXT_VILLIAGE;

public class Shop
{
    private List<Item> items;
    public List<Item> Items => items;

    public Shop()
    {
        items = new List<Item>();
        
        items.Add(new Weapon("나무검", 100, "적당히 쓸만한 무난한 검", 70, 5));
        items.Add(new Weapon("돌검", 150, "간단히 돌을 깎아 만든 검이다.", 110, 10));
        items.Add(new Weapon("철검", 250, "중급자에게 추천하는 최고의 검", 200, 25));
        items.Add(new Weapon("다이아 대검", 500, "고블린 따위 쓱싹!", 380, 45));
        items.Add(new Weapon("전설의 대검", 1500, "드래곤 토벌을 위한 '용사'의 검", 1000, 80));
        
        items.Add(new Consumable("바다 요정의 눈물", 1000, "짠맛이 나는 활력 치료제", 600, "먹으면 2턴 동안 무적이 된다."));
        items.Add(new Consumable("껌", 100, "슬라임의 침으로 만든 껌이다. (상점 주인이 좋아함)", 300, "씹으면 기분이 좋아진다."));
        items.Add(new Consumable("저주인형", 5000, "지하 마녀의 영혼을 흡수한 인형", 3900, "최대 체력이 절반으로 줄어들지만 공격력을 두 배 증가시켜준다."));
        items.Add(new Consumable("솔방울방울", 200, "솔방울로 만든 방울", 100, "길 찾기에 유용하다."));
        items.Add(new Consumable("원두폭탄", 500, "카페인을 이용한 폭탄", 200, "터뜨리는 순간 적을 카페인에 중독시킨다."));
    }
    
    public bool Buy(int num, Player player)
    {
        Item item = items[num - 1];

        if (player.Buy(item))
        {
            items.Remove(item);
            Console.WriteLine($"""
                               
                               >>> {item.Name} 구매 성공! <<<
                               {item.Price}골드가 차감됩니다.
                               
                               현재 잔액 : {player.Gold}
                               
                               """);
            return true;
        }
        else
        {
            Console.WriteLine(">>> 잔액이 부족합니다. 다시 확인해 주세요!");
            return false;
        }
    }

    public void Sell(int num, Player player)
    {
        if (num > 0 && player.Items.Count >= num)
        {
            
            Console.WriteLine($"""
                               
                               >>> {player.Items[num-1].Name} 판매 성공! <<<
                               {player.Items[num-1].BuyPrice}골드를 얻었습니다.
                               
                               """);
            player.Sell(num);
            Console.WriteLine($"""
                              현재 잔액 : {player.Gold}
                              """);
        }
        else
        {
            Console.WriteLine(">>> 다시 확인해 주세요!");
        }
    }

    public void ShowItems()
    {
        int number = 1;
        
        Console.WriteLine("""
                           
                           ====== 아이템 목록 ======
                           """);
        
        // 처음에는 Weapon의 Attack을 출력하기 위해 타입을 직접 확인하려 했다.
        // 이후 Item.ShowInfo()를 virtual로 만들고 자식 클래스에서 override하여
        // 타입 검사 없이 각 객체에 맞는 정보를 출력하도록 변경했다.
        foreach (Item item in items)
        {
            Console.WriteLine($"#{number}");
            item.ShowInfo();
            number++;
        }

        Console.WriteLine("===================");
    }
}