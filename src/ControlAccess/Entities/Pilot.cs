using System.Collections.Generic;

namespace ControlAcess.Entities
{
    public class Pilot
    {
        public int IdPilot { get; set; }
        public string Name { get; set; }
        public string YearofBirth { get; set; }
        public int IdPlanet { get; set; }

        //Relacionamentos
        public Planet Planet { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
