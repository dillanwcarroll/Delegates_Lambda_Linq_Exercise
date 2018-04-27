using System.Collections.Generic;
using System.Linq;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// Strips any whitespace before and after a data value.
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            for (int row = 0; row < data.Count; row++)
            {
                for (int cell = 0; cell < data[row].Count; cell++)
                {
                    data[row][cell] = data[row][cell].Trim();
                }
            }

            return data;
        }

        /// Adds quotes to each data value
        public List<List<string>> AddQuotes(List<List<string>> data) {

            for (int row = 0; row < data.Count; row++)
            {
                for (int cell = 0; cell < data[row].Count; cell++)
                {
                    data[row][cell] = "\"" + data[row][cell] + "\"";
                }
            }

            return data;
        }

        /// Strips quotes from beginning and end of each data value
        public List<List<string>> StripQuotes(List<List<string>> data) {

            for (int row = 0; row < data.Count; row++)
            {
                for (int cell = 0; cell < data[row].Count; cell++)
                {
                    data[row][cell] = data[row][cell].Trim('"', '\'');
                }
            }

            return data;
        }

    }
}