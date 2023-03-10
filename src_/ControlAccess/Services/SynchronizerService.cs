using ControlAccess.Dao;
using ControlAccess.Entidades;
using ControlAccess.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ControlAccess.Services
{
    public class SynchronizerService
    {
        private const string URL_PLANETS = "http://swapi.dev/api/planets/";
        private const string URL_SHIPS = "http://swapi.dev/api/starships/";
        private const string URL_PILOTS = "http://swapi.dev/api/people/";

        public Task Synchronize()
        {
            var tasks = new List<Task>();

            tasks.Add(SynchronizePlanets());
            tasks.Add(SynchronizeShips());

            Task.WhenAll(tasks);

            return SynchronizePilots();
        }

        private async Task SynchronizePlanets()
        {
            var httpClient = new HttpClient();
            var list = new List<PlanetViewModel>();
            ResultApi<PlanetViewModel> resultApi = null;

            do
            {
                resultApi = await httpClient.GetFromJsonAsync<ResultApi<PlanetViewModel>>(resultApi?.Next ?? URL_PLANETS);
                list.AddRange(resultApi.Results);
            } while (resultApi.Next != null);

            var planets = list.Select(item => new Planet
            {
                IdPlanet = item.IdPlanet,
                Name = item.Name,
                Climate = item.Climate,
                Diameter = item.Diameter,
                Orbit = item.Orbit,
                Rotation = item.Rotation,
                Population = item.Population
            }).ToList();

            using (var dao = new PlanetDao())
                await dao.InsertPlanets(planets);
        }

        private async Task SynchronizeShips()
        {
            var httpClient = new HttpClient();
            var list = new List<ShipViewModel>();
            ResultApi<ShipViewModel> resultApi = null;

            do
            {
                resultApi = await httpClient.GetFromJsonAsync<ResultApi<ShipViewModel>>(resultApi?.Next ?? URL_SHIPS);
                list.AddRange(resultApi.Results);
            } while (resultApi.Next != null);

            var ships = list.Select(item => new Ship
            {
                IdShip = item.IdShip,
                Name = item.Name,
                Charge = item.Charge,
                Class = item.Starship_Class,
                Model = item.Model,
                Passengers = item.Passengers
            }).ToList();

            using (var dao = new ShipDao())
                await dao.Insertships(ships);
        }

        private async Task SyncPilots()
        {
            var httpClient = new HttpClient();
            var list = new List<PilotViewModel>();
            ResultApi<PilotViewModel> resultApi = null;

            do
            {
                resultadApi = await httpClient.GetFromJsonAsync<ResultApi<PilotViewModel>>(resultApi?.Next ?? URL_PILOTS);
                list.AddRange(resultApi.Results.Where(p => p.Starships.Any()).ToList());
            } while (resultApi.Next != null);

            var pilots = list.Select(item => new Pilot
            {
                IdPilot = item.IdPilot,
                Name = item.Name,
                YearofBirth = item.Birth_Year,
                IdPlanet = item.IdPlanet,
                Ships = item.IdShips.Select(idShip => new Ship
                {
                    IdShip = int.Parse(IdShip)
                }).ToList()
            }).ToList();

            using (var pilotDao = new PilotDao())
            {
                await pilotDao.InsertPilots(pilots);
                await pilotDao.InsertPilotsSHips(pilots);
            }
        }

    }
}
