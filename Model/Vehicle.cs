using System.ComponentModel;

namespace Barkfors_Kodtest.VehicleFolder
{
    public class Vehicle : INotifyPropertyChanged
    {
        public int VIN { get; set; }
        public string LicensePlateNumber { get; set; }
        public string ModelName { get; set; }
        public Brands Brand { get; set; }
        public FuelTypes TypeOfFuel { get; set; }
        public string Color { get; set; }
        public Equipment[] Equipment { get; set; }

        public Vehicle(string modelName, Brands brand, FuelTypes typeOfFuel, string color, Equipment[] equipment)
        {
            VIN = -1;
            LicensePlateNumber = "Not set";
            ModelName = modelName;
            Brand = brand;
            TypeOfFuel = typeOfFuel;
            Color = color;
            Equipment = equipment;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
