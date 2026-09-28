namespace TextRpg;

public class Player
{
    private int hp;
    private int Maxhp = 100;
    
    private int attack;
    private int level = 1;

    private int gainExp = 100;
    private int exp;
    
    // 프로퍼티 셋팅 (읽을 순 있게!)
    public int Hp
    {
        get
        {
            return hp;
        }
    }
    public int Level
    {
        get => level;
    }
    public int Exp => exp;

    // 생성자
    public Player()
    {
        hp = 100;
        attack = 5;
        level = 1;
        exp = 0;
    }

    // 공격
    // 실수 1. 여기서 캡슐화를 생각 못하고 enemy.hp -= attack 이라고 씀
    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(attack);
    }

    // 데미지 받기
    // 실수 2. 데미지를 받기 전에 검사를 해서 hp가 음수여도 false가 반환됐었음
    public bool TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            return true;
        }

        return false;
    }

    public void GainExp(int amount)
    {
        exp += amount;

        if (exp >= gainExp)
        {
            LevelUp();
            Console.WriteLine($"""
                              ===========
                              레벨업!
                              
                              현재 레벨 : {level}
                              ===========
                              """);
        }
    }
    
    // 레벨업
    // 실수 3. 처음엔 경험치 받는 거랑 레벨 올리는 걸 짬뽕해서 코드를 썼었음
    private void LevelUp()
    {
        exp -= gainExp;

        gainExp += 50;
        level++;

        Maxhp += 10;
        hp = Maxhp;
        attack += 6;
    }
}