using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace aaa{
  
class Fraction : ICloneable, IFracOperations, IEquatable<Fraction>
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

    publuc bool Equals(Fraction aa){
        return (a==aa.a && b==bb.b);
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
        if (c==null){
        c = a / (decimal)b;
        }
        return c;
    }

    public void set(int a1, uint b1)
    {
        a = a1;
        b = b1;
        c = null;
    }
}}
