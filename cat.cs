namespace aaa{
class Cat : IMeow
{
    private string name;
    
    public Cat(string name1) {name = name1;}

    public override string ToString()
    {
        return $"кот: {name}";
    }

    public void meow(int n = 1)
    {
        Console.Write($"{name}: мяу");
        for (int i = 0; i < n-1; i++) { Console.Write($"-мяу"); }
        Console.Write("!\n");
    }
}}
