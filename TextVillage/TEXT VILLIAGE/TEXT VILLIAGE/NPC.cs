namespace TEXT_VILLIAGE;

public class NPC
{
    protected string name;
    protected int age;
    protected string job;
    protected string hello;

    public string Name => name;
    public int Age => age;
    public string Job => job;
    public string Hello => hello;
    
    public NPC(string name, int age, string job, string hello)
    {
        this.name = name;
        this.age = age;
        this.job = job;
        this.hello = hello;
    }
}