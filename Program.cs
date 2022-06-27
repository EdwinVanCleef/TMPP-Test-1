using System;
using System.Collections.Generic;
using System.Linq;

namespace TMPPTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Palindrome Test");
            Palindrome();
            Console.WriteLine(String.Empty);

            Console.WriteLine("Calculate Interest Test");
            CalculateInterest();
            Console.WriteLine(String.Empty);

            Console.WriteLine("Reverse Paragraph");
            ParagraphReversals();
        }

        static void Palindrome()
        {
            Console.Write("Enter a word: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a word");
                return;
            }

            var reverseInput = ReverseString(input);
            var outputFlag = String.Empty;

            if (!input.Equals(reverseInput))
                outputFlag = " NOT";

            Console.WriteLine("{0} is{1} a palindrome", input, outputFlag);
        }

        static void CalculateInterest()
        {
            // amount + ((amount * interest) * years)
            Console.Write("Loan Amount: ");
            var loanAmount = Console.ReadLine();
            Console.Write("Number of Years: ");
            var noOfYears = Console.ReadLine();
            Console.Write("Rate of Interest: ");
            var interestRate = Console.ReadLine();

            if (!ValidateNumberInput(loanAmount) || 
                !ValidateNumberInput(noOfYears) || 
                !ValidateNumberInput(interestRate))
                return;

            var convertedAmount = Convert.ToInt32(loanAmount);
            var interest = convertedAmount * Decimal.Divide(Convert.ToInt32(interestRate), 100);
            var interestRateInYears = Math.Floor(interest * Convert.ToInt32(noOfYears));

            Console.WriteLine("Total Amount :{0}", convertedAmount + interestRateInYears);
        }

        static void ParagraphReversals()
        {
            Console.Write("Enter paragraph: ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a paragraph");
                return;
            }

            var inputList = input.ToString().Split(' ');
            var inverted = new List<string>();
            foreach (var word in inputList.Reverse())
            {
                inverted.Add(ReverseString(word));
            }

            var result = String.Join(' ', inverted);
            Console.WriteLine("Output: {0}", result);
        }

        #region "Helpers"
        static bool ValidateNumberInput(string num)
        {
            if (String.IsNullOrWhiteSpace(num))
            {
                Console.WriteLine("Please enter a number");
                return false;
            }

            if (!int.TryParse(num, out int result))
            {
                Console.WriteLine("Invalid input. Please enter a number");
                return false;
            }

            if (Convert.ToInt32(num) <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a number greater than 0");
                return false;
            }

            return true;
        }

        static string ReverseString(string input)
        {
            var reverseInput = String.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverseInput += input[i];
            }

            return reverseInput;
        }
        #endregion
    }
}
