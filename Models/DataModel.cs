﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices
{
    public enum FittingMethod {
        Linear, 
        Exponential,
        PowerFunction
    }


    public class DataModel
    {
        public IList<Tuple<double, double>> Points { get; set; }
        public Tuple<double, double> Parameters { get; set; }
    }
}
