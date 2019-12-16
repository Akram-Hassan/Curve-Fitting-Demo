using Microsoft.Win32;
using SwabianInstruments.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SwabianInstruments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainViewModel)DataContext;
        }

        //Can be refactored to commands
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
                viewModel.EventHandler.OnLoadFile(openFileDialog.FileName, cboFittingMethod.SelectedIndex);
        }

        //Can be refactored to commands
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(viewModel != null)
                viewModel.EventHandler.OnSelectFittingMethod(((ComboBox)sender).SelectedIndex);
        }

        //Can be refactored to commands
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.EventHandler.OnShowData();
        }
    }
}
