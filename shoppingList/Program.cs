using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace shoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, decimal> grocrieList = new Dictionary<string, decimal>();
                grocrieList.Add("milk", (decimal)3.33); //adding a key/value using the Add() method
                grocrieList.Add("eggs", (decimal)6.23);
                grocrieList.Add("bread", (decimal)5.01);
                grocrieList.Add("bananas", (decimal)2.68);
                grocrieList.Add("potatoes", (decimal)10.68);
                grocrieList.Add("oats", (decimal)4.68);
                grocrieList.Add("walnuts", (decimal)6.99);
                grocrieList.Add("yogurt", (decimal)7.25);

                Console.WriteLine("Available Items\n");
                foreach (var item in grocrieList.Keys)
                {
                    Console.WriteLine($"{item, -12} ${grocrieList[item]}");
                }
                

                var shoppingList = getShoppingList(grocrieList);
                Console.Clear();
                decimal listTotal = (decimal)0.00;
                foreach (var item in shoppingList)
                {
                    listTotal += grocrieList[item];
                    Console.WriteLine($"{item} , ${grocrieList[item]}");
                }
                Console.WriteLine($"Order total: ${listTotal}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static List <string> getShoppingList (Dictionary<string,decimal> shoppingList)
        {
            bool keepGoing = true;
            List<string> usersShoppingList = new List<string>();
            do
            {                
                Console.WriteLine("What grocery item would you like to add to your list?");
                string usersItems = Console.ReadLine().ToLower();
                if (shoppingList.ContainsKey(usersItems))
                {
                    if (!usersShoppingList.Contains(usersItems))
                    {
                        usersShoppingList.Add(usersItems);
                        Console.WriteLine($"Adding {usersItems} to list");
                    }
                    Console.WriteLine($"{usersItems}, ${shoppingList[usersItems]}\n");
                }
                else
                    Console.WriteLine("Unavailable item or Invalid response. Please try again.");
                    
                
                Console.Write($"If that is your final item press, F. Otherwise press any key to continue.");
                string userContinue = Console.ReadLine();
                if (userContinue.ToLower() == "f")
                {
                    keepGoing = false;
                }
               
                else
                    Console.WriteLine("Okay, lets continue.");

            }
            while (keepGoing == true);

            Console.WriteLine("Thanks for using Grocery List Builder!");

            return usersShoppingList;

        }
    }
}