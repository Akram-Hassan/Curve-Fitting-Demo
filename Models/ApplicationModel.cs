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
            var points = LoadPointsFrom(filePath);
            var parameters = CalculateParameters(method, points);

            return new DataModel
            {
                Parameters = parameters,
                Points = points.ToList()
            };
        }

        private static Tuple<double, double> CalculateParameters(FittingMethod method, IEnumerable<Tuple<double, double>> points)
        {
            switch (method)
            {
                case FittingMethod.Linear:
                    return NumericalMethods.FitLinear(points);
                case FittingMethod.Exponential:
                    return NumericalMethods.FitExponential(points);
                case FittingMethod.PowerFunction:
                    return NumericalMethods.FitPowerFunction(points);
                default:
                    return null;
            }
        }

        private static IEnumerable<Tuple<double, double>> LoadPointsFrom(string filePath)
        {
            try
            {
                var points = CsvLoader.LoadDataFileContent(filePath);
                return points;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }
    }
}

