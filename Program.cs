using System;

namespace CSharpDelegates
{
    public static class CoffeeMachine
    {
        public static void MakeCoffee(string coffeeName)
        {
            Console.WriteLine($"Now, your {coffeeName} is prepared");
        }
    }
    static class Program
    {
        // delegate void CoffeeDelegate(string coffeeName);

        static void Main(string[] args)
        {
            // CoffeeDelegate coffeeDelegate = new CoffeeDelegate(CoffeeMachine.MakeCoffee);

            // Delegate yerine Action kullanıyoruz
            Action<string> coffeeAction = CoffeeMachine.MakeCoffee;

            Func<string, int> brewingTime = coffee =>
            {
                if (coffee == "Espresso") return 2;
                if (coffee == "Latte") return 3;
                return 4; // Cappuccino
            };

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
                int time = brewingTime(coffees[selection]);
                Console.WriteLine($"Your {coffees[selection]} will be ready in {time} minutes...");
                coffeeAction(coffees[selection]);
            }
            else
            {
                Console.WriteLine("🚫 Geçersiz seçim!");
            }
        }
    }
}