namespace TextRpg;

class Program
{
    // readonly = 배열의 const 같은 느낌
    private static readonly string[] Yes = ["y", "yes"];
    private static readonly string[] No = ["n", "no"];
    private static readonly Random random = new Random();

    private static string StartMenu = """
                                     ============================
                                     TEXT RPG
                                       - 레벨 5를 달성하여 클리어
                                       ! 주의 !
                                           - 운에 맡기세요.
                                           - 실력은 중요하지 않은 게임입니다.
                                           - 초반에는 슬라임을 잡는 것을 추천합니다.
                                     ============================

                                     > 시작하시겠습니까?
                                       Y          N
                                     """;
    private static string GameOverMenu = """
                                        패배했습니다...
                                        
                                        > 다시 시작하시겠습니까?
                                          Y          N
                                        """;
    private static string WinMenu = """
                                   승리!
                                   
                                   다음 몬스터가 나타납니다...
                                   """;
    
    static void Main()
    {
        Start();
    }
    
    // 시작 여부 확인 함수 -> StartGame
    static public void Start()
    {
        Console.WriteLine(StartMenu);

        while (true)
        {
            // 소문자로 바꾸면 Yes 배열에 y, yes만 넣으면 됨
            // 시작 여부 확인
            string choose = Console.ReadLine().ToLower();
            
            
            // Contains 함수 배움!
            if (Yes.Contains(choose))
            {
                Console.WriteLine("""
                                  
                                  게임을 시작합니다.
                                  
                                  """);
                StartGame();
                break;
            }
            
            // 비교 연산자.. || && 헷갈
            if (No.Contains(choose))
            {
                Console.WriteLine("""

                                  게임을 종료합니다.

                                  """);
                break;
            }

            Console.WriteLine("""
                              
                              다시 입력하세요!
                              
                              """);
            Console.WriteLine(StartMenu);
        }
    }

    // 게임 진행 함수
    private static void StartGame()
    {
        Player player = new Player();
        Console.WriteLine("""
                          
                          
                          
                          >> 필드에 입장하셨습니다! <<
                          
                          """);

        while (true)
        {
            Enemy enemy = SpawnMonster(player);
            bool dontNextFight = NextFight();

            if (!dontNextFight)
            {
                bool isDeath = Fight(enemy, player);
            
                if (isDeath)
                {
                    Console.WriteLine(GameOverMenu);
                    
                    bool willRetry = Retry();
                    if (willRetry) Main();
                    else
                    {
                        Console.WriteLine("""
                                          
                                          게임을 종료합니다.
                                          """);
                        break;
                    }
                }
                else
                {
                    if (enemy.Name == "드래곤")
                    {
                        Console.WriteLine("""
                                          
                                          >>> 축하합니다! <<<
                                          - 게임을 클리어 하셨습니다.
                                          - 당신은 운이 좋으신 편이군요!
                                          =======================
                                          
                                          >>> 다시 플레이 하시겠습니까?
                                          """);
                        Retry();
                    }
                    else
                    {
                        Console.WriteLine(WinMenu);
                        player.GainExp(enemy.Exp);
                    }
                }
            }
        }
        
        // 여기서 개큰 실수를 함... SpawnMonster를 계속 호출해서 새로운 몬스터를 계속 만듦..
        // while (true)
        // {
            // if (player.Hp <= 0)
            // {
            //     Console.WriteLine(GameOverMenu);
            //     break;
            // } else if (SpawnMonster(player).Hp <= 0)
            // {
            //     Console.WriteLine(WinMenu);
            //     Fight(SpawnMonster(player), player);
            //     player.GainExp(SpawnMonster(player).Exp);
            // }
            // else
            // {
            //     Fight(SpawnMonster(player), player);
            // }
        // }
    }

    private static bool Retry()
    {
        while (true)
        {
            string choose = Console.ReadLine().ToLower();
            
            if (Yes.Contains(choose)) return true;
            else if (No.Contains(choose)) return false;
            else
            {
                Console.WriteLine("""
                                  
                                  다시 입력하세요!
                                  
                                  """);
            }
        }
    }

    private static bool NextFight()
    {
        while (true)
        {
            Console.WriteLine("""
                              
                              >>> 싸우시겠습니까?
                                Y          N
                              """);
            
            string choose = Console.ReadLine().ToLower();
            
            if (No.Contains(choose)) return true;
            else if (Yes.Contains(choose)) return false;
            else
            {
                Console.WriteLine("""
                                  
                                  다시 입력하세요!
                                  
                                  """);
            }
        }
    }
    
    private static Enemy SpawnMonster(Player player)
    {
        List<Enemy> enemies = new List<Enemy>();
        enemies.Add(new Slime());
        enemies.Add(new Goblin());
        enemies.Add(new Skeleton());
        
        int index = random.Next(0, enemies.Count);

        if (player.Level >= 5)
        {
            Enemy dragon = new Dragon();
            Console.WriteLine($"""
                               
                               >>>> 보스 등장 <<<<
                               {dragon.Name}
                               Hp : {dragon.Hp}
                               =================
                               
                               """);
            return dragon;
        }
        else
        {
            Console.WriteLine($"""

                               {enemies[index].Name}이 나타났다!

                               ===== 상태 =====
                               {enemies[index].Name}
                                 hp : {enemies[index].Hp}
                               플레이어
                                 hp : {player.Hp}
                               ===============
                               
                               """);
            return enemies[index];
        }
    }
    
    // 제일 우여곡절 많았던 함수... 너무 세분화 하려다 망함. -> 죽은 걸 함수로 빼서 하려고 했음
    private static bool Fight(Enemy enemy, Player player)
    {
        while (true)
        {
            // 플레이어 공격
            player.Attack(enemy);
            if (enemy.Hp <= 0) return false;
            
            Console.WriteLine($"""
                              
                              플레이어 공격!
                              
                              ===== 상태 =====
                              {enemy.Name}
                                hp : {enemy.Hp}
                              플레이어
                                hp : {player.Hp}
                              ===============
                              
                              """);
            
            // 적 공격
            enemy.Attack(player);
            if (player.Hp <= 0) return true;
            
            Console.WriteLine($"""
                               
                               {enemy.Name} 공격!

                               ===== 상태 =====
                               {enemy.Name}
                                 hp : {enemy.Hp}
                               플레이어
                                 hp : {player.Hp}
                               ===============
                               
                               """);
        }
    }
}