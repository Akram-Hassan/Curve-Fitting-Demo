using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices
{

    public enum FittingMethod {
        Linear, 
        Exponential,
        PowerFunction
    }

    //Would love to call DataPoint but wanna avoid conflict with oxyplot DataPoint for now

    

    public class DataModel
    {
        public IList<Tuple<double, double>> Points { get; set; }
        public Tuple<double, double> Parameters { get; set; }
    }
}
