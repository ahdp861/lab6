using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
namespace aaa{
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
}}
