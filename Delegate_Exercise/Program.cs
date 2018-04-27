using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {
        public static void Main(string[] args)
        {
            DataParser _dp = new DataParser();
            CsvHandler _csv = new CsvHandler();

            Func<List<List<string>>, List<List<string>>> process = new Func<List<List<string>>, List<List<string>>>(_dp.StripQuotes);
            process += _dp.StripWhiteSpace;
            process += StripHash;
            _csv.ProcessCsv("/Users/New/Desktop/Wk7/data.csv", "/Users/New/Desktop/Wk7/processed_data.csv", process);

            Parser parser = new Parser(process);
            parser += Capitalise;
            _csv.ProcessCsv("/Users/New/Desktop/Wk7/data.csv", "/Users/New/Desktop/Wk7/processed_data_optional.csv", parser);
        }

        public static List<List<string>> Capitalise(List<List<string>> data)
        {
            for (int row = 0; row < data.Count; row++)
            {
                for (int cell = 0; cell < data[row].Count; cell++)
                {
                    data[row][cell] = data[row][cell].ToUpper();
                }
            }
            return data;
        }

        public static List<List<string>> StripHash(List<List<string>> data)
        {
            for (int row = 0; row < data.Count; row++)
            {
                for (int cell = 0; cell < data[row].Count; cell++)
                {
                    data[row][cell] = data[row][cell].Trim('#');
                }
            }
            return data;
        }
    }
}