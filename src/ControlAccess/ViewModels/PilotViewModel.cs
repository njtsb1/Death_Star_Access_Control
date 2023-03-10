using System.Collections.Generic;
using System.Linq;

namespace ControlAccess.ViewModels
{
    public class PilotViewModel
    {
        private List<string> _idsNaves;

        public string Name { get; set; }
        public string Birth_Year { get; set; }
        public string Homeworld { get; set; }
        public IReadOnlyList<string> Starships { get; set; }
        public string Url { get; set; }

        public int IdPlanet
        {
            get
            {
                return int.Parse(Homeworld?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault());
            }
        }

        public IReadOnlyList<string> IdShips
        {
            get
            {
                if (_idsShips == null)
                    idsShips = Starships.Select(nave => nave?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault()).ToList();

                return idsShips;
            }
        }

        public int IdPilot
        {
            get
            {
                return int.Parse(Url?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault());
            }
        }
    }
}