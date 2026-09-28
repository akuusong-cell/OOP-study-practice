namespace TextRpg;

public abstract class Enemy
{
    // 실수 1. 모든 변수를 private로 설정함.. 그러면 다른 클래스에서 값을 못 바꿈.. 
    protected int hp;
    protected int exp;
    protected int attack;
    protected string name;

    // 프로퍼티
    public string Name => name;
    public int Hp => hp;
    public int Exp => exp;

    // 공격
    // 실수? 3. 공격 함수를 abstract로 했다가 virtual로 바꿈. 생각해보니 데미지 주는 건 다 똑같았음
    public virtual void Attack(Player player)
    {
        player.TakeDamage(attack);
    }

    // 실수 2. 이걸 굳이 abstract로 강제함. 데미지를 입는 건 똑같다는 걸 상기..
    // 데미지 입기
    public virtual bool TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            return true;
        }

        return false;
    }
}