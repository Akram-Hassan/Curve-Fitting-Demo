using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppServices
{
    public class CsvLoader
    {
        public static IEnumerable<Tuple<double, double>> LoadDataFileContent(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            if (lines.Any(line => !LineValid(line) ))
            {
                throw new InvalidCSVFileExeption("The csv file is not correctly formatted!");
            }

            return ProcessLines(lines);
        }

        private static bool LineValid(string line)
        {
            string pattern = @"[0-9]+(,[0-9]+)$";
            Match m = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
            return m.Success;
        }

        public static IEnumerable<Tuple<double, double>> ProcessLines(string[] lines)
        {
            return lines.Select(
                line => {
                    var parsed = line.Split(",");
                    double x = double.Parse(parsed[0]);
                    double y = double.Parse(parsed[1]);

                    return new Tuple<double, double>(x, y);
                }
            );
        }
    }
}
