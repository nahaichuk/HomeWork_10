using System.IO;
using System.Text.RegularExpressions;

namespace HomeWork_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            string[] baza = LoadPhoneBook("Phone.csv");
            string searchBar = GetSearchBar();
    
            string searchResult = "Incorrect input";

            if (searchBar != "")
            {
                searchResult = FindASubscriber(searchBar, baza);
            }
            Console.WriteLine("search result: " + searchResult);
        }

        static string[] LoadPhoneBook(string filePhone)
        {
            string[] phoneBook = { };

            try
            {
                phoneBook = File.ReadAllLines(filePhone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return phoneBook;
        }

        static string GetSearchBar()
        {

            string searchBar = "";
            Console.WriteLine($"Enter search string:");
            try 
            {
                searchBar = Console.ReadLine(); 
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            return searchBar;

        }

        static string FindASubscriber(string param, string[] data)
        {

            string result = "The subscriber is not in the phone book.";
            string[] columnNames = { "name", "surname", "tel" };

            for (int i = 0; i < data.Length; i++)
            {
                Boolean regexResult = Regex.IsMatch(data[i], param, RegexOptions.IgnoreCase);
                if (regexResult)
                {
                    result = data[i];
                }
            }

            return result;

        }
    }
}