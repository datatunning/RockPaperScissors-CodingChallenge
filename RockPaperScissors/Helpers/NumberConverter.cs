// <copyright file="NumberConverter.cs" company="Bruno DUVAL.">
// Copyright (c) Bruno DUVAL.</copyright>

using System;

namespace Games.RockPaperScissors.Helpers
{
    public static class NumberConverter
    {
        /// <summary>Converts the number to string.</summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">negative numbers not supported</exception>
        public static string ConvertNumberToString(int n)
        {
            if (n < 0)
                throw new NotSupportedException("negative numbers not supported");
            if (n == 0)
                return "zero";
            if (n < 10)
                return ConvertDigitToString(n);
            if (n < 20)
                return ConvertTensToString(n);
            if (n < 100)
                return ConvertHighTensToString(n);
            if (n < 1000)
                return ConvertBigNumberToString(n, (int) 1e2, "Hundred");
            if (n < 1e6)
                return ConvertBigNumberToString(n, (int) 1e3, "Thousand");
            return n < 1e9
                ? ConvertBigNumberToString(n, (int) 1e6, "Million")
                //if (n < 1e12)
                : ConvertBigNumberToString(n, (int) 1e9, "Billion");
        }

        /// <summary>Converts the digit to string.</summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private static string ConvertDigitToString(int i)
        {
            return i switch
            {
                0 => "",
                1 => "One",
                2 => "Two",
                3 => "Three",
                4 => "Four",
                5 => "Five",
                6 => "Six",
                7 => "Seven",
                8 => "Eight",
                9 => "Nine",
                _ => throw new IndexOutOfRangeException($"{i} not a digit")
            };
        }

        /// <summary>Converts the tens to string.</summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        private static string ConvertTensToString(int n)
        {
            return n switch
            {
                10 => "Ten",
                11 => "Eleven",
                12 => "Twelve",
                13 => "Thirteen",
                14 => "Fourteen",
                15 => "Fifthteen",
                16 => "Sixteen",
                17 => "Seventeen",
                18 => "Eighteen",
                19 => "Nineteen",
                _ => throw new IndexOutOfRangeException($"{n} not a teen")
            };
        }

        /// <summary>Converts the high tens to string.</summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        private static string ConvertHighTensToString(int n)
        {
            var tensDigit = (int) (Math.Floor((double) n / 10.0));
            var tensStr = tensDigit switch
            {
                2 => "Twenty",
                3 => "Thirty",
                4 => "Forty",
                5 => "Fifty",
                6 => "Sixty",
                7 => "Seventy",
                8 => "Eighty",
                9 => "Ninety",
                _ => throw new IndexOutOfRangeException($"{n} not in range 20-99")
            };

            if (n % 10 == 0) return tensStr;
            var onesStr = ConvertDigitToString(n - tensDigit * 10);
            return tensStr + "-" + onesStr;
        }

        /// <summary>Converts the big number to string.</summary>
        /// <param name="n">The n.</param>
        /// <param name="baseNum">The base number.</param>
        /// <param name="baseNumStr">The base number string.</param>
        /// <returns></returns>
        private static string ConvertBigNumberToString(int n, int baseNum, string baseNumStr)
        {
            // special case: use commas to separate portions of the number, unless we are in the hundreds
            var separator = (baseNumStr != "hundred") ? ", " : " ";

            // Strategy: translate the first portion of the number, then recursively translate the remaining sections.
            // Step 1: strip off first portion, and convert it to string:
            var bigPart = (int) (Math.Floor((double) n / baseNum));
            var bigPartStr = ConvertNumberToString(bigPart) + " " + baseNumStr;

            // Step 2: check to see whether we're done:
            if (n % baseNum == 0) return bigPartStr;

            // Step 3: concatenate 1st part of string with recursively generated remainder:
            var restOfNumber = n - bigPart * baseNum;
            return bigPartStr + separator + ConvertNumberToString(restOfNumber);
        }
    }
}