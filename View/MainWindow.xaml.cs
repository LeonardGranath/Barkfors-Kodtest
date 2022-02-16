using Barkfors_Kodtest.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Barkfors_Kodtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VehicleViewModel model = new();
        private AddWindow addWin = new();

        public MainWindow()
        {
            InitializeComponent();

            VehicleList.DataContext = model;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addWin == null)
                addWin = new();

            addWin.Show();
            addWin.Closing += AddWin_Closing;
        }

        private void AddWin_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            model.Add(addWin.CreatedVehicle);
            VehicleList.Items.Refresh();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotSupportedException();
        }

        private void ModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotSupportedException();
        }

        private void VehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool setEnabled = VehicleList.SelectedIndex != -1;

            ModifyBtn.IsEnabled = setEnabled;
            DeleteBtn.IsEnabled = setEnabled;
        }
    }
}
