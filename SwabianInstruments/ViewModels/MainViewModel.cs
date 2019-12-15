using OxyPlot;
using System;
using System.Collections.Generic;

namespace SwabianInstruments.ViewModels
{
    public class MainViewModel
    {
        public GraphViewModel GraphViewModel { get; set; }
        
        public IList<Tuple<double, double>> Points;

        Tuple<double, double> Parameters;

        public MainViewModel()
        {
            this.GraphViewModel = new GraphViewModel();
            LoadGraph();
            LoadPointsTable();
            ShowParameters();
        }

        private void ShowParameters()
        {
        }

        private void LoadGraph()
        {
            this.GraphViewModel.Title = "Curve Display";
            this.GraphViewModel.Points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };

        }

        private void LoadPointsTable()
        {
        }

        public void OnLoadFile()
        {
            ;
        }

        public void OnSelectFittingMethod()
        {
            ;
        }

    }
}
