using System.Windows;
using System.Windows.Controls;

namespace Barkfors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotSupportedException();
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
