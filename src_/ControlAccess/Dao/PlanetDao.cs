using ControlAcess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAcess.Dao
{
    public class PlanetDao : DaoBase
    {
        public async Task InsertPlanets(List<Planet> planets)
        {
            if (!planets.Any())
                return;

            var check = "if (not exists(select 1 from Planets where IdPlanet = {0}))\n";
            var insert = "insert Planets (IdPlanet, Name, Rotation, Orbit, Diameter, Climate, Population) values({0}, '{1}', {2}, {3}, {4}, '{5}', {6});\n";
            var commands = planets.Select(planet => string.Format(check, planet.IdPlanet) + string.Format(insert, planet.IdPlanet, planet.Name, planet.Rotation, planet.Orbit, planet.Diameter, planet.Climate, planet.Population));

            await Insert(string.Join('\n', commands));
        }
    }
}
