

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using namespace aaa;
class Program
{
    private static Dictionary<IMeow, int> meows = new Dictionary<IMeow, int>{ };
    public static void MeowAll(params IMeow[] mlist)
    {
        meows.Clear();
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
        
        Random r = new Random();
        
        Fraction a = new Fraction(r.Next(-40, 40), r.Next(0, 40));
        Fraction a1 = new Fraction(r.Next(-40, 40), r.Next(0, 40));
        Fraction a2 = new Fraction(r.Next(-40, 40), r.Next(0, 40));

        Console.WriteLine($"{a} + {a1} + {a2} = {a1 + a2 + a}");

        Console.WriteLine($"{a1} - {a} - {a2} = {a1 - a - a2}");

        Console.WriteLine($"{a} * {a1} * {a2} = {a1 * a2 * a}");

        Console.WriteLine($"{a1} / {a} / {a2} = {a1 / a / a2}\n");

        Console.WriteLine($"({a} + {a1}) / {a2} - 5 = {((a + a1) / a2) - 5}");

        Console.WriteLine($"{a} > {a1} = {a > a1}");

        Console.WriteLine($"{a2} < {a1} = {a2 < a1}");

        Console.WriteLine($"{a2} == {a1} = {a2 == a1}");

        Console.WriteLine($"Получено {a1.Clone()} клонированием из {a1}");

        a1.set(-10, 33);
        
        Console.WriteLine($"Задана {a1} клонированием c числителем -10 и знаменателелем 33");

        Console.WriteLine($"Получено и кэшировано значение {a1.value()}");
    }
    }
