using System;
using System.Collections.Generic;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number));
            }

            char[] numArr = number.ToString().ToCharArray();
            List<char> tempSubArr = new List<char> { };
            char maxNumber;
            char currNumber;
            for (int i = numArr.Length - 1; i >= 0; i--)
            {
                tempSubArr.Add(numArr[i]);
                maxNumber = MaxNum(tempSubArr);
                if (numArr[i] < maxNumber)
                {
                    tempSubArr.Remove(maxNumber);
                    numArr[i] = maxNumber;
                    tempSubArr.Sort();

                    for (int c = i + 1; c < numArr.Length; c++)
                    {
                        numArr[c] = tempSubArr[c - i - 1];
                    }

                    break;
                }
            }

            if (Int32.TryParse(String.Concat<char>(numArr), out int num) && number != num)
            {
                return num;
            }
            else
            {
                return null;
            }
        }

        public static char MaxNum(List<char> tempSubArr)
        {
            char result = tempSubArr[0];
            foreach (char tempNum in tempSubArr)
            {
                if (tempNum > result)
                {
                    result = tempNum;
                }
            }

            return result;
        }
    }
}
