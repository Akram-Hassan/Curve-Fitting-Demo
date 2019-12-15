using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppServices
{
    public class ApplicationModel
    {
        public DataModel CalculateData(string filePath, FittingMethod method)
        {
            IEnumerable<Tuple<double, double>> points;
            try
            {
                points = CsvLoader.LoadDataFileContent(filePath);
            }
            catch (FormatException exception)
            {
                throw exception;
            }

            Tuple<double, double> parameters = new Tuple<double, double>(0,0);

            switch (method)
            {
                case FittingMethod.Linear:
                    parameters = NumericalMethods.FitLinear(points);
                    break;
                case FittingMethod.Exponential:
                    parameters = NumericalMethods.FitExponential(points);
                    break;
                case FittingMethod.PowerFunction:
                    parameters = NumericalMethods.FitPowerFunction(points);
                    break;
                default:
                    break;
            }

            DataModel result = new DataModel
            {
                Parameters = parameters ,
                Points = points.ToList()
            };

            return result;
        }
    }
}

