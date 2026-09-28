namespace TEXT_VILLIAGE;

class Program
{
    private static readonly string[] Yes = ["y", "yes"];
    private static readonly string[] No = ["n", "no"];

    private static readonly string VillageFound = """
                                                  ====== 마을 발견! ======
                                                  >>> 들어가시겠습니까?
                                                        Y     N
                                                  """;
    private static readonly string VillageEnter = """

                                                  >>> 비교적 조용한 마을이다...

                                                  ...

                                                  ====== 상점 발견! ======
                                                  >>> 들어가시겠습니까?
                                                        Y     N
                                                  """;
    private static readonly string Rechoose = """
                                              
                                              다시 입력해 주세요!
                                              
                                              """;
    private static readonly string ShopMenu = """
                                              =================
                                              1. 아이템 구매하기
                                              2. 아이템 판매하기
                                              """;
    private static Shop shop = new Shop();
    private static Player player = new Player();
    
    static void Main()
    {
        FoundVillage();
    }
    
    public static void FoundVillage()
    {
        Console.WriteLine(VillageFound);
        
        while (true)
        {
            string choose = Console.ReadLine().ToLower();

            if (Yes.Contains(choose))
            {
                Console.WriteLine("""
                                  
                                  >>> ! 마을 입장 ! <<<
                                  
                                  """);
                EnterVillage();
                break;
            }
            
            if (No.Contains(choose))
            {
                Console.WriteLine("""
                                  
                                  다시 모험을 떠나자!
                                  """);
                return;
            }
            
            Console.WriteLine(Rechoose);
            Console.WriteLine(VillageFound);
        }
    }

    public static void EnterVillage()
    {
        Console.WriteLine(VillageEnter);

        while (true)
        {
            string choose = Console.ReadLine().ToLower();
            if (Yes.Contains(choose))
            {
                Console.WriteLine("""
                                  
                                  상점 입장!
                                  
                                  """);
                EnterShop();
            }
            else if (No.Contains(choose))
            {
                Console.WriteLine("""
                                  
                                  마을을 좀 더 둘러보자...
                                  
                                  """);
                return;
            }
            else
            {
                Console.WriteLine(Rechoose);
                Console.WriteLine(VillageEnter);
            }
        }
    }

    public static void EnterShop()
    {
        ShopNpc shopNpc = new ShopNpc("케빈", 60, "은퇴한 모험가", 
            "어서오게! 우리 마을에 손님이 오셨군!", 
            "구매해줘서 고맙네! 다음에 커피 한 잔 하러 오게!", 
            "오호, 좋은 물건이군!", 
            "천천히 구경해보게!");

        Console.WriteLine("""
                          나이 든 남성이 보인다.
                          
                          """);
        Console.WriteLine($">>> {shopNpc.Name}({shopNpc.Job}) : {shopNpc.Hello}");
        InShopDoing(shopNpc);
    }
    
    public static void InShopDoing(ShopNpc npc)
    {
        while (true)
        {
            Console.WriteLine(ShopMenu);
            string choose = Console.ReadLine().ToLower();

            switch (choose)
            { 
                case "1":
                    BuySomething(npc);
                    break;
                case "2":
                    SellSomething(npc);
                    break;
                default:
                    Console.WriteLine(Rechoose);
                    break;
            }
        }
    }

    
    public static void BuySomething(ShopNpc npc)
    {
        // 둘러봐!
        Console.WriteLine($"""
                           
                           >>> {npc.Name}({npc.Job}) : {npc.ShowInfo}
                           """); 
        
        shop.ShowItems(); // 아이템 보여주기

        Console.WriteLine($"""
                          
                          현재 잔액 : {player.Gold}골드
                          >>> 몇 번 아이템을 구매하시겠습니까?
                               (상위 메뉴로 돌아가려면 0을 입력하세요)
                          """);
        
        while (true)
        {
            string choose = Console.ReadLine();

            if (int.TryParse(choose, out int num))
            {
                if (num == 0)
                {
                    return;
                }
                if (num <= shop.Items.Count)
                {
                    if (shop.Buy(num, player))
                    {
                        Console.WriteLine($"""
                                           
                                           >>> {npc.Name}({npc.Job}) : {npc.Selling}
                                           """);
                    }
                    return;
                }
                Console.WriteLine(Rechoose);
            }
        }
    }

    public static void SellSomething(ShopNpc npc)
    {
        player.ShowInventory(); // 아이템 보여주기

        Console.WriteLine("""

                          >>> 몇 번 아이템을 판매하시겠습니까?
                               (상위 메뉴로 돌아가려면 0을 입력하세요.)
                          """);
        
        while (true)
        {
            string choose = Console.ReadLine();

            if (int.TryParse(choose, out int num))
            {
                if (num == 0)
                {
                    return;
                }
                if (num <= player.Items.Count)
                {
                    shop.Sell(num, player);
                    Console.WriteLine($"""
                                       
                                       >>> {npc.Name}({npc.Job}) : {npc.Buying}
                                       """);
                    return;
                }
                
                Console.WriteLine(Rechoose);
            }
        }
    }
}