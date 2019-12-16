using AppServices;
using OxyPlot;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace SwabianInstruments.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public readonly ApplicationModel AppModel; 
        public readonly ViewModelEventHandler EventHandler;

        public MainViewModel()
        {
            AppModel = new ApplicationModel();
            EventHandler = new ViewModelEventHandler(this);
        }

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

        public FittingMethod Method { get; set; }

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
    }
}
