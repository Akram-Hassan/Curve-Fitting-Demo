using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppServices
{
    public static class NumericalMethods
    {
        public static Tuple<double, double> FitLinear(IEnumerable<Tuple<double, double>> points)
            => Fit.Line(GetXValues(points), GetYValues(points));

        public static Tuple<double, double> FitExponential(IEnumerable<Tuple<double, double>> points) 
            => Fit.Exponential(GetXValues(points), GetYValues(points));

        public static Tuple<double, double> FitPowerFunction(IEnumerable<Tuple<double, double>> points)
            => Fit.Power(GetXValues(points), GetYValues(points));

        private static double[] GetXValues(IEnumerable<Tuple<double, double>> points) 
            => points.Select(x => x.Item1).ToArray();

        private static double[] GetYValues(IEnumerable<Tuple<double, double>> points)
            => points.Select(x => x.Item2).ToArray();
    }
}
