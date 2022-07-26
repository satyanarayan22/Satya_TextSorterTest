using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleTest
{
    /// <summary>
    /// Class to be used to sort the text
    /// </summary>
    public class TextSorter
    {
        /// <summary>
        /// Constant to hold the special characters that needs to be replaced with blank
        /// </summary>
        private const string SpecialCharactersConstant = @"[^0-9a-zA-Z\s]+";

        /// <summary>
        /// Method to sort the string using the requirement
        /// words should be reordered Alphabetically - (Zerbra Abba) becomes (Abba Zebra)
        ///words should THEN be ordered from upper case to lower case. Note point 1 takes preference. (aBba Abba) becomes(Abba aBba)
        ///remove all(.,;') chars. (aBba, Abba) becomes (Abba aBba)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DataMisalignedException"></exception>
        public static string SortString(string someInput)
        {
            var log = new ConsoleLogger();
            if (someInput == null)
            {
                throw new DataMisalignedException("data not correct");
            }

            log.Log("start CalculateTotal");

            var inputString = Regex.Replace(someInput, SpecialCharactersConstant, "");

            var words = inputString.Split(' ').ToList();
            
            words.Sort(new CustomStringComparer(StringComparer.OrdinalIgnoreCase));

            log.Log("end CalculateTotal");
            var result = String.Join(" ", words);

            return result;
        }        
    }
}