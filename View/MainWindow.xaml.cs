using Barkfors_Kodtest.VehicleFolder;
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

        private bool add = true;

        public MainWindow()
        {
            InitializeComponent();

            VehicleList.DataContext = model;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!addWin.IsLoaded)
                addWin = new();

            add = true;
            addWin.Show();
            addWin.Closing += AddWin_Closing;
        }

        private void AddWin_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            Vehicle newVehicle = addWin.CreatedVehicle;

            if (newVehicle == null)
                return;

            if (add)
            {
                newVehicle.LicensePlateNumber = model.AvailableLicensePlateNbr();
                newVehicle.VIN = model.AvailableVIN();
                model.Add(newVehicle);
            }
            else
                model.Modify(VehicleList.SelectedIndex, newVehicle);

            VehicleList.Items.Refresh();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (model.Delete((Vehicle)VehicleList.SelectedItem))
                VehicleList.Items.Refresh();
        }

        private void ModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            addWin = new();

            add = false;
            addWin.Show();
            addWin.Closing += AddWin_Closing;
        }

        private void VehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool setEnabled = VehicleList.SelectedIndex != -1;

            ModifyBtn.IsEnabled = setEnabled;
            DeleteBtn.IsEnabled = setEnabled;
        }
    }
}
