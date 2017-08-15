using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Kata.StringCalculator
{
    public class StringCalculator
    {
        private const Int32 defaultNumber = 0;

        private const String customSeparator = "//";

        private List<String> separators = new List<String>() { ",", "\n" };

        private const Int32 maxNumber = 1000;

        public Int32 Add(String numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
                return defaultNumber;

            if (numbers.StartsWith(customSeparator))
                numbers = this.AddCustomSeperators(numbers);

            var cleanedNumbers = this.CleanNumbers(numbers);

            return cleanedNumbers.Sum();
        }

        private String AddCustomSeperators(String numbers)
        {
            String[] customSeperators = { customSeparator, "[", "]" };

            var customSeperator = numbers.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(customSeperator.Length, numbers.Length - customSeperator.Length);

            var allCustomSeperators = customSeperator.Split(customSeperators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sep in allCustomSeperators)
                separators.Add(sep);

            return numbers;
        }

        private IList<Int32> CleanNumbers(String numbers)
        {
            var nums = numbers.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var cleaned = new List<Int32>();

            foreach (var num in nums)
            {
                var cleanedNumber = Int32.Parse(num);

                if (cleanedNumber < 0)
                {
                    throw new ApplicationException("Number cannot be negative");
                }

                if (cleanedNumber <= maxNumber)
                {
                    cleaned.Add(cleanedNumber);
                }
            }

            return cleaned;
        }
    }
}
