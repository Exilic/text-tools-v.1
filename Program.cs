using System;
using System.Text.RegularExpressions;

namespace TextTools
{
    static class Program
    {
        static void Main(string[] args)
        {
            string textualContent = Console.ReadLine();
            string transformedText = textualContent
                .Fractions()
                .Dashes()
                .PostalNumber()
                .CitationMarks();
            Console.WriteLine(transformedText);
            Console.ReadKey();
        }

        public static string Fractions(this string text)
        {
            return text
                .Replace("1/4", "\u00bc")
                .Replace("1/2", "\u00bd")
                .Replace("3/4", "\u00be");
        }

        public static string Dashes(this string text)
        {
            return text
                .Replace("---", "\u200a\u2014\u200a")           // em dash + hair space
                .Replace("--", "\u2013");                       // en dash
        }

        public static string PostalNumber(this string text)
        {            
            return new Regex(@"/\b[0 - 9]{ 7}![0 - 9]/g")       // Selecting postal numbers
                .Replace(text, m => m.Value
                .Insert(2, " "));                     
        }

        public static string CitationMarks(this string text)
        {
            return text                                         // Citation with »
                .Replace("\"", "\u00bb");
        }
    }
}
