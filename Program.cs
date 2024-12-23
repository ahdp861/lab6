

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

interface IMeow
{
    void meow(int n = 1);

}

interface IFracOperations
{
    decimal value();
    void set(int a1, uint b1);

}


class Fraction : ICloneable, IFracOperations
{
    public int a { get; set; }
    public uint b { get; set; }
    public decimal? c { get; set; }
    private static int divisor(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if (b == 0)
            return a;
        return divisor(b, a % b);
    }

    public Fraction(int a1, uint b1) { if (b1 == 0) { Console.WriteLine("знаменатель не может быть равен 0"); return; } a = a1 / divisor(a1, (int)b1); b = (uint)(b1 / divisor(a1, (int)b1)); }
    public override string ToString() { return $"{a}/{b}"; }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction((int)(a.a * b.b + b.a * a.b), a.b * b.b);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.a * (int)b.b - b.a * (int)a.b, a.b * b.b);
    }
    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.a * b.a, a.b * b.b);
    }
    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.a / b.a, a.b / b.b);
    }

    public static Fraction operator /(Fraction a, int b)
    {
        return new Fraction(a.a / b, a.b);
    }

    public static Fraction operator *(Fraction a, int b)
    {
        return new Fraction(a.a * b, a.b);
    }

    public static Fraction operator /(int a, Fraction b)
    {
        int t = 1;
        if (b.a < 0) t = -1;
        return new Fraction(t * a * (int)b.b, (uint)b.a);
    }

    public static Fraction operator *(int a, Fraction b)
    {
        return new Fraction(a * b.a, b.b);
    }

    public static Fraction operator +(int a, Fraction b)
    {
        return new Fraction(a * (int)b.b + b.a, b.b);
    }

    public static Fraction operator -(int a, Fraction b)
    {
        return new Fraction(a * (int)b.b - b.a, b.b);
    }

    public static Fraction operator +(Fraction a, int b)
    {
        return new Fraction(a.a + (int)a.b * b, a.b);
    }

    public static Fraction operator -(Fraction a, int b)
    {
        return new Fraction(a.a - (int)a.b * b, a.b);
    }

    public static bool operator >(Fraction a, Fraction b) { return a.a * b.b > b.a * a.b; }
    public static bool operator <(Fraction a, Fraction b) { return a.a * b.b < b.a * a.b; }
    public static bool operator ==(Fraction a, Fraction b) { return a.a * b.b == b.a * a.b; }
    public static bool operator !=(Fraction a, Fraction b) { return a.a * b.b != b.a * a.b; }

    public object Clone()
    {
        return new Fraction(a, b);
    }

    public decimal value()
    {
        c = (decimal)a / b;
        return (decimal)a / b;
    }

    public void set(int a1, uint b1)
    {
        a = a1;
        b = b1;
        c = null;
    }
}

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
}

class Dog : IMeow
{
    private string name;

    public Dog(string name1) { name = name1; }

    public override string ToString()
    {
        return $"пес: {name}";
    }

    public void meow(int n = 1)
    {
        Console.Write($"{name}: гав");
        for (int i = 0; i < n - 1; i++) { Console.Write($"-гав"); }
        Console.Write("!\n");
    }
}


class Program
{
    private static Dictionary<IMeow, int> meows = new Dictionary<IMeow, int>{ };
    public static void MeowAll(params IMeow[] mlist)
    {
        foreach (var item in mlist)
        {
            item.meow();
            if (meows.ContainsKey(item))
            {
                meows[item]++;
            }
            else {meows.Add(item, 1);}
        }
    }
    static void Main(string[] args)
    {
        Cat b = new Cat("Барсик");
        Console.WriteLine(b.ToString());
        Cat m = new Cat("Константин");
        b.meow();
        b.meow(3);
        MeowAll(m, m, new Cat("кот2"), new Cat("кот3"), new Dog("пес1"), new Dog("пес2"), new Dog("пес3"));
        Console.WriteLine($"количество мявов для {m} = {meows[m]}");

        Fraction a = new Fraction(3, 6);
        Fraction a1 = new Fraction(1, 6);
        Fraction a2 = new Fraction(12, 36);

        Console.WriteLine($"{a} + {a1} + {a2} = {a1 + a2 + a}");

        Console.WriteLine($"{a1} - {a} - {a2} = {a1 - a - a2}");

        Console.WriteLine($"{a} * {a1} * {a2} = {a1 * a2 * a}");

        Console.WriteLine($"{a1} / {a} / {a2} = {a1 / a / a2}\n");

        Console.WriteLine($"({a} + {a1}) / {a2} - 5 = {((a + a1) / a2) - 5}");

        Console.WriteLine($"{a} > {a1} = {a > a1}");

        Console.WriteLine($"{a2} < {a1} = {a2 < a1}");

        Console.WriteLine($"{a2} == {a1} = {a2 == a1}");
    }
    }