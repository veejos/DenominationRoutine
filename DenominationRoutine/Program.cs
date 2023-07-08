using System;
using System.Collections.Generic;

public class ATM
{
    private readonly int[] denominations = { 10, 50, 100 };
    private readonly int[] cartridge = { 0, 0, 0 };

    public ATM(int cartridgeCount10, int cartridgeCount50, int cartridgeCount100)
    {
        cartridge[0] = cartridgeCount10;
        cartridge[1] = cartridgeCount50;
        cartridge[2] = cartridgeCount100;
    }

    public List<string> GetCombinations(int amount)
    {
        List<string> combinations = new List<string>();
        Calc_Combinations(amount, 0, "", combinations);
        return combinations;
    }

    private void Calc_Combinations(int amount, int index, string combination, List<string> combinations)
    {
        if (amount == 0)
        {
            combinations.Add(combination);
            return;
        }

        if (index >= denominations.Length)
            return;

        int denomination = denominations[index];
        int maxCount = Math.Min(amount / denomination, cartridge[index]);

        for (int count = 0; count <= maxCount; count++)
        {
            int remainingAmount = amount - count * denomination;
            string newCombination = combination + (count > 0 ? count + " x " + denomination + " EUR + " : "");

            Calc_Combinations(remainingAmount, index + 1, newCombination, combinations);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ATM atm = new ATM(10, 5, 2);

        int[] payoutAmounts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

        foreach (int amount in payoutAmounts)
        {
            List<string> combinations = atm.GetCombinations(amount);

            Console.WriteLine("Possible combinations for EUROS:");

            if (combinations.Count == 0)
                Console.WriteLine("No combinations available.");
            else
                foreach (string combination in combinations)
                    Console.WriteLine(combination);

            Console.WriteLine();
        }
    }
}