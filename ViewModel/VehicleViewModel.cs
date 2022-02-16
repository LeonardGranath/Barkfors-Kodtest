using Barkfors_Kodtest.VehicleFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Barkfors_Kodtest.ViewModel
{
    internal class VehicleViewModel : INotifyPropertyChanged
    {
        public IList<Vehicle> Vehicles { get; }

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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Delete(Vehicle vehicle)
        {
            return Vehicles.Remove(vehicle);
        }
    }
}
