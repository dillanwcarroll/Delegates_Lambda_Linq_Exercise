using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;
using ObjectLibrary;

namespace Delegate_Exercise {

    public delegate List<List<string>> Parser(List<List<string>> data);

    public class CsvHandler {

        FileHandler _fh = new FileHandler();
    
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {
            List<List<string>> result = _fh.ParseCsv(_fh.ReadFile(readFile));
            _fh.WriteFile(writeFile, ',', dataHandler(result));
        }

        //Optional Task
        public void ProcessCsv(string readFile, string writeFile, Parser parser)
        {
            List<List<string>> result = _fh.ParseCsv(_fh.ReadFile(readFile));
            _fh.WriteFile(writeFile, ',', parser(result));
        }
    }
}