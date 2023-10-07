using System;
using System.Collections.Generic;

namespace SplitBillLibrary
{
    public class BillSplitter
    {
        // Method to split the bill amount among a number of people
        public decimal SplitBill(decimal amount, int people)
        {
            if (people <= 0) throw new ArgumentException("Number of people must be greater than 0.", nameof(people));
            return Decimal.Round(amount / people, 2);
        }

        // Method to calculate the tip amount per person based on a given tip percentage
        public decimal CalculateTipPerPerson(decimal totalAmount, int people, float tipPercentage)
        {
            if (people <= 0) throw new ArgumentException("Number of people must be greater than 0.", nameof(people));
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage must be non-negative.", nameof(tipPercentage));
            decimal tipAmount = Decimal.Round((totalAmount * (decimal)tipPercentage) / 100, 2);
            return Decimal.Round(tipAmount / people, 2);
        }

        // Method to calculate the tip amount per person based on the cost of their individual meal and a given tip percentage
        public Dictionary<string, decimal> CalculateIndividualTips(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (tipPercentage < 0) throw new ArgumentException("Tip percentage must be non-negative.", nameof(tipPercentage));
            var tips = new Dictionary<string, decimal>();
            foreach (var mealCost in mealCosts)
            {
                decimal tipAmount = Decimal.Round((mealCost.Value * (decimal)tipPercentage) / 100, 2);
                tips.Add(mealCost.Key, tipAmount);
            }
            return tips;
        }
    }
}
