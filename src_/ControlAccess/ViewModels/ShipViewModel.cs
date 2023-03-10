using System.Linq;

namespace ControlAccess.ViewModels
{
    public class NaveViewModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Passengers { get; set; }
        public string Charge_Capacity { get; set; }
        public string Starship_Class { get; set; }
        public string Url { get; set; }

        public int Passengers
        {
            get
            {
                int.TryParse(Passengers, out var return);
                return return;
            }
        }

        public double Charge
        {
            get
            {
                double.TryParse(Charge_Capacity, out var return);
                return return;
            }
        }

        public int IdShip
        {
            get
            {
                return int.Parse(Url?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault());
            }
        }
    }
}
