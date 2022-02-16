using Barkfors_Kodtest.VehicleFolder;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Barkfors_Kodtest.ViewModel
{
    internal class VehicleViewModel : INotifyPropertyChanged
    {
        public IList<Vehicle> Vehicles { get; }
        public int Count => Vehicles.Count;

        public event PropertyChangedEventHandler? PropertyChanged;

        public VehicleViewModel()
        {
            Vehicles = new List<Vehicle>();
        }

        public bool Add(Vehicle newVehicle)
        {
            if (newVehicle == null)
                return false;

            Vehicles.Add(newVehicle);
            return true;
        }

        public bool Delete(Vehicle vehicle)
        {
            return Vehicles.Remove(vehicle);
        }

        public void Modify(int selectedIndex, Vehicle createdVehicle)
        {
            createdVehicle.LicensePlateNumber = Vehicles[selectedIndex].LicensePlateNumber;
            createdVehicle.VIN = Vehicles[selectedIndex].VIN;

            Vehicles[selectedIndex] = createdVehicle;
        }

        public string AvailableLicensePlateNbr()
        {
            return Count == 0 ? 0.ToString("D3") : (Vehicles.Max(v => int.Parse(v.LicensePlateNumber)) + 1).ToString("D3");
        }

        public int AvailableVIN()
        {
            return Count == 0 ? 0 : Vehicles.Max(v => v.VIN + 1);
        }

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
