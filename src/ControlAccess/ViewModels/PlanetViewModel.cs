using System.Linq;

namespace ControlAccess.ViewModels
{
    public class PlanetViewModel
    {
        public string Name { get; set; }
        public string Rotation_Period { get; set; }
        public string Orbital_Period { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Population { get; set; }
        public string Url { get; set; }

        public double Rotation
        {
            get
            {
                double.TryParse(Rotation_Period, out var return);
                return return;
            }
        }

        public double Orbit
        {
            get
            {
                double.TryParse(Orbital_Period, out var return);
                return return;
            }
        }

        public double Diameter
        {
            get
            {
                double.TryParse(Diameter, out var return);
                return return;
            }
        }

        public int Population
        {
            get
            {
                int.TryParse(Population, out var return);
                return return;
            }
        }

        public int IdPlanet
        {
            get
            {
                return int.Parse(Url?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault());
            }
        }
    }
}
