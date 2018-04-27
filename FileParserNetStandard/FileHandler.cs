using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class FileHandler {

       
        public FileHandler() { }

        /// Reads a file returning each line in a list.
        public List<string> ReadFile(string filePath) => File.ReadAllLines(filePath).ToList();

        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {

            StreamWriter file = File.CreateText(filePath);
            for (int row = 0; row < rows.Count; row++)
            {
                string line = "";
                for (int data = 0; data < rows[row].Count - 1; data++)
                {
                    line += rows[row][data] + delimeter;
                }
                file.WriteLine(line + rows[row].Last());
            }
            file.Close();
        }

        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        public List<List<string>> ParseData(List<string> data, char delimeter)
        {
            return data.Select(r => r.Split(delimeter).ToList()).ToList();
        }

        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        public List<List<string>> ParseCsv(List<string> data)
        {
            return data.Select(r => r.Split(',').ToList()).ToList();
        }
    }
}