using Models;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace SwabianInstruments.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
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
        public ObservableCollection<DataPoint> Points {
            get => _points;
            set
            {
                if (value != _points   )
                {
                    _points = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Points)));
                }
            }
        }
        
        Tuple<double, double> Parameters;


        public void OnLoadFile(string fileName)
        {
            this.FileName = fileName;
            var points = FileModel.LoadDataFileContent(fileName);

            //Todo: Bad
            Points.Clear();
            foreach (var item in points)
            {
                Debug.WriteLine(item);
                Points.Add(new DataPoint(item.Item1 , item.Item1));
            }
        }

        public void OnSelectFittingMethod()
        {
            ;
        }

    }
}
