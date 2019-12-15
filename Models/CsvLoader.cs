using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppServices
{
    public class CsvLoader
    {
        public static IEnumerable<Tuple<double, double>> LoadDataFileContent(string filePath)
        {
            return File.ReadAllLines(filePath).Select(
                line => {
                    var parsed = line.Split(",");
                    double x  = double.Parse(parsed[0]);
                    double y = double.Parse(parsed[1]);

                    return new Tuple<double, double>(x,y);
                }
            );
        }
    }
}
