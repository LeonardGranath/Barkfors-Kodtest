using System.Drawing;

namespace Barkfors.Vehicle
{
    internal class Vehicle
    {
        public int VIN { get; set; }
        public int LicensePlateNumber { get; set; }
        public string ModelName { get; set; }
        public string Brand { get; set; }
        public FuelTypes TypeOfFuel { get; set; }
        public Color Color { get; set; }
        public Equipment Equipment { get; set; }
    }
}
