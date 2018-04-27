using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard {
    
    
    public class PersonHandler {

        public List<Person> People;

        /// Converts List of list of strings into Person objects for People attribute.
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();

            foreach (List<string> row in people.Skip(1))
            {
                People.Add(new Person(int.Parse(row[0]), row[1], row[2], new DateTime(long.Parse(row[3]))));
            }
        }

        /// Gets oldest people
        public List<Person> GetOldest()
        {
            DateTime oldest = People.Select(p => p.Dob).Min();

            return People.Where(p => p.Dob == oldest).ToList();
        }

        /// Gets string (from ToString) of Person from given Id.
        public string GetString(int id)
        {
            return People.Find(p => p.Id == id).ToString();
        }

        public List<Person> GetOrderBySurname()
        {
            return People.OrderBy(p => p.Surname).ToList();
        }

        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            return People.Select(p => p.Surname).Where(s => s.StartsWith(searchTerm, !caseSensitive, null)).Count();
        }
        
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            People
                .OrderBy(o => o.Dob)
                .GroupBy(p => p.Dob).ToList()
                .ForEach(g => result.Add($"{g.Key}\t{g.Count()}"));

            return result;
        }
    }
}