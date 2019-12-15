using AppServices;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace SwabianInstruments.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ApplicationModel _appModel = new ApplicationModel();

        public event PropertyChangedEventHandler PropertyChanged;

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                if (value != _fileName)
                {
                    _fileName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.FileName)));
                }
            }
        }

        
        private ObservableCollection<DataPoint> _points = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> Points
        {
            get => _points;
            set
            {
                if (value != _points)
                {
                    _points = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Points)));
                }
            }
        }

        private DataModel _dataModel;

        public DataModel DataModel {
            get => _dataModel; 
            set
            {
                if (value != _dataModel)
                {
                    _dataModel = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.DataModel)));
                }
            }
        }


        public void OnLoadFile(string filePath, int index)
        {
            this.FileName = filePath;
            this.DataModel = _appModel.CalculateData(filePath, (FittingMethod)index);
            UpdateView();
        }

        public void OnSelectFittingMethod(int index)
        {
            this.DataModel = _appModel.CalculateData(this.FileName, (FittingMethod)index);
            UpdateView();
        }

        //This is so ugly!
        //I have to do it this way until because the library plot component works only with DataPoint instances
        //whose type is in the library
        //To be removed later
        private void UpdateView()
        {
            var points = DataModel.Points.Select(x => new DataPoint(x.Item1, x.Item2));
            this.Points = new ObservableCollection<DataPoint>(points);
            ;
        }
    }
}
