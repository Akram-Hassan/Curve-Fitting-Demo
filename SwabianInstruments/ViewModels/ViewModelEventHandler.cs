using AppServices;
using OxyPlot;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SwabianInstruments.ViewModels
{
    public class ViewModelEventHandler
    {
        private MainViewModel viewModel;

        public ViewModelEventHandler(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        //Can be refactored to commands
        public void OnLoadFile(string filePath, int index)
        {
            viewModel.FileName = filePath;
        }

        //Can be refactored to commands
        public void OnSelectFittingMethod(int index)
        {
            //Bad:
            //the combobox should be bound to the enum in Xaml using IValueConverter or some other technique
            //To be investigated later
            viewModel.Method = (FittingMethod)index;
        }

        //Can be refactored to commands
        public void OnShowData()
        {
            try
            {
                viewModel.DataModel = viewModel.AppModel.CalculateData(viewModel.FileName, viewModel.Method);
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading the file");
                viewModel = new MainViewModel(); 
                return;
            }
            UpdatePlotter();
        }

        //This is so ugly!
        //I have to do it this way because the library plot component works only with DataPoint instances
        //whose type is in the library
        //So I cannot bind the plotter to some other POCO "yet".
        //To be removed later
        private void UpdatePlotter()
        {
            var points = viewModel.DataModel.Points.Select(x => new DataPoint(x.Item1, x.Item2));
            viewModel.Points = new ObservableCollection<DataPoint>(points);
        }
    }
}
