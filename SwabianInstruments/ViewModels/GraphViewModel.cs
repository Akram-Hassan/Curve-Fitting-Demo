using System.Collections.Generic;
using OxyPlot;

namespace SwabianInstruments.ViewModels
{
    public class GraphViewModel
    {
        public string Title { get;  set; }

        public IList<DataPoint> Points { get;  set; }
    }
}
