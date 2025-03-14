using System;

namespace CSharpDelegates
{
    public static class CoffeeMachine
    {
        public static void MakeCoffee(string coffeeName)
        {
            Console.WriteLine($"Making {coffeeName} coffee");
        }
    }
    static class Program
    {
        // delegate void CoffeeDelegate(string coffeeName);

        // Delegate yerine Action kullanıyoruz
        static Action<string> coffeeAction = CoffeeMachine.MakeCoffee;

        static void Main(string[] args)
        {
            // CoffeeDelegate coffeeDelegate = new CoffeeDelegate(CoffeeMachine.MakeCoffee);

            Dictionary<int, string> coffees = new()
            {
                { 1, "Espresso" },
                { 2, "Latte" },
                { 3, "Cappuccino" }
            };

            Console.WriteLine("Select your coffee:");
            Console.WriteLine("-------------------");

            foreach (var option in coffees)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }

            Console.WriteLine("-------------------");


            if (int.TryParse(Console.ReadLine(), out int selection) && coffees.ContainsKey(selection))
            {
                coffeeAction(coffees[selection]);
            }
            else
            {
                Console.WriteLine("🚫 Geçersiz seçim!");
            }
        }
    }
}