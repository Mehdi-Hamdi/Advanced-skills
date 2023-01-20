using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace LambdasAndLinq;

public class Program
{
    static void Main(string[] args)
    {
        //language integrated queries (LINQ)
        var nums = new List<int> { 3, 7, 8, 1, 4, 0, 5 };

        var numsCount = nums.Count();
         
        int countEven = nums.Count(IsEven);

        List<Person> people = new List<Person> {
          new Person { Name = "Cathy", Age = 40, City = "Ottawa"},
          new Person { Name = "Nish", Age = 55,City = "Birmingham"},
          new Person { Name = "Martin", Age = 20, City = "London"}
        };

        var countYoungPeople = people.Count(IsYoung);

        //anonymous method using delegates
        int coundDEven = nums.Count(delegate (int num)
        {
            return num % 2 == 0;
        });

        //lambda expresssions

        // given something => return something
        int sumOfSquares = nums.Sum(x => x * x);

        int countLEven = nums.Count(num => num % 2 == 0);

        var peopleInLondonQuery = people.Where(p => p.City == "London");
        var peopleInLondon = peopleInLondonQuery.ToList();


        var peopleByAge = people.OrderBy(p => p.Age);

        foreach(var person in peopleByAge)
        {
            Console.WriteLine(person);
        }

        var namesOfThoseOver20 = people.Where(p => p.Age > 20).Select(p => p.Name).First();

        string newString = ModifyString("Hello World", s => s.Replace(" ", "_").ToUpper());


    }

    private static void ModifyString(string str, Func<string, string> strModify)
    {
        return strModify(str);
    }

    private static int Square(int x)
    {
        return x * x;
    }

    private static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    private static bool IsYoung(Person p)
    {
        return p.Age < 30;
    }
}

public class Person
{
    public string Name { get; set; }
    private int _age;
    public int Age
    {
        get => _age;
        set => _age = value < 0 ? throw new ArgumentException() : value;
    }
       
    public string City { get; set; }
    public override string ToString() => $"{Name} - {City} - {Age}";
    
}