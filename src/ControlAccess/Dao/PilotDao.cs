using ControlAcess.Entities;
using ControlAcess.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAcess.Dao
{
    public class PilotDao : DaoBase
    {
        public async Task InsertPilots(List<Pilot> pilots)
        {
            if (!pilots.Any())
                return;

            var check = "if (not exists(select 1 from Pilots where IdPilot = {0}))\n";
            var insert = "insert Pilots (IdPilot, Name, YearofBirth, IdPlanet) values({0}, '{1}', '{2}', {3});\n";
            var commands = pilots.Select(pilot => string.Format(check, pilot.IdPilot) + string.Format(insert, pilot.IdPilot, pilot.Name, pilot.YearofBirth, pilot.IdPlanet));

            await Insert(string.Join('\n', commands));
        }

        public async Task RegisterStartTravel(int idPilot, int idShip)
        {
            StringBuilder command = new StringBuilder();
            command.AppendLine($"if (not exists(select 1 from HistoricalTravel where IdPilot = {IdPilot} and DtArrival is null))");
            command.AppendLine($"begin");
            command.AppendLine($"   insert HistoricalTravel (idShip, IdPilot, DtSaida) values({idShip}, {IdPilot}, GetDate());");
            command.AppendLine($"end");

            await Insert(string.Join('\n', command.ToString()));
        }

        public async Task RegisterEndTrip(int IdPilot, int idShip)
        {
            StringBuilder command = new StringBuilder();
            command.AppendLine($"update HistoricalTravel set DtArrival = GetDate() where IdPilot = {IdPilot} and idShip = {idShip} and DtArrival is null;");

            await Insert(string.Join('\n', command.ToString()));
        }

        public async Task InserirPilotsShips(List<Pilot> pilots)
        {
            if (!pilots.Any())
                return;

            var check = "if (not exists(select 1 from PilotsShips where IdPilot = {0} and idShip = {1}))\n";
            var insert = "insert PilotsShips (IdPilot, idShip) values({0}, {1});\n";
            var commands = pilots.SelectMany(pilot => pilot.Ships.Select(ship => string.Format(check, pilot.IdPilot, ship.idShip) + string.Format(insert, pilot.IdPilot, ship.idShip)));

            await Insert(string.Join('\n', commands));
        }

        public async Task<bool> PilotIsTraveling(int IdPilot)
        {
            bool traveling = false;

            var command = $"select convert(bit, case when count(DtExit) <> count(DtArrival) then 1 else 0 end) traveling from HistoricalTravel where IdPilot = {IdPilot}";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    traveling = resultSQL.GetValueOrDefault<bool>("Traveling");
                }
            });

            return traveling;
        }

        public async Task<Pilot> GetById(int IdPilot)
        {
            Pilot pilot = null;
            var command = @$"
                                select  t1.IdPilot,
                                        t1.Name,
                                        t1.YearofBirth,
                                        t2.IdPlanet,
                                        t2.Name NamePlanet,
                                        t2.Rotation,
                                        t2.Orbit,
                                        t2.Diameter,
                                        t2.Climate,
                                        t2.Population
                                from    Pilots t1
                                inner   join Planets t2
                                on      t1.IdPlanet = t2.IdPlanet
                                where   IdPilot = {IdPilot}";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    pilot = new Pilot
                    {
                        IdPilot = resultSQL.GetValueOrDefault<int>("IdPilot"),
                        Name = resultSQL.GetValueOrDefault<string>("Name"),
                        YearofBirth = resultSQL.GetValueOrDefault<string>("YearofBirth"),
                        IdPlanet = resultSQL.GetValueOrDefault<int>("IdPlanet"),
                        Planet = new Planet
                        {
                            IdPlanet = resultSQL.GetValueOrDefault<int>("IdPlanet"),
                            Name = resultSQL.GetValueOrDefault<string>("NamePlanet"),
                            Rotation = resultSQL.GetValueOrDefault<double>("Rotation"),
                            Orbit = resultSQL.GetValueOrDefault<double>("Orbit"),
                            Diameter = resultSQL.GetValueOrDefault<double>("Diameter"),
                            Climate = resultSQL.GetValueOrDefault<string>("Climate"),
                            Population = resultSQL.GetValueOrDefault<int>("Population")
                        }
                    };
                }
            });

            pilot.Ships = new List<Ship>();
            command = @$"
                                select  t2.*
                                from    PilotsShips t1
                                inner   join Ships t2
                                on      t1.idShip = t2.idShip
                                where   t1.FlagAuthorized = 1
                                and     t1.IdPilot = {IdPilot}";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    pilot.Ships.Add(new Ship
                    {
                        idShip = resultSQL.GetValueOrDefault<int>("idShip"),
                        Name = resultSQL.GetValueOrDefault<string>("Name"),
                        Model = resultSQL.GetValueOrDefault<string>("Model"),
                        Passagers = resultSQL.GetValueOrDefault<int>("Passagers"),
                        Charge = resultSQL.GetValueOrDefault<double>("Charge"),
                        Class = resultSQL.GetValueOrDefault<string>("Class")
                    });
                }
            });

            return pilot;
        }

        public async Task<List<Pilot>> GetByNameLike(string name)
        {
            var pilots = new List<Pilot>();
            var command = $"select * from Pilots where name like '%{name.Replace(' ', '%')}%'";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    pilots.Add(new Pilot
                    {
                        IdPilot = resultSQL.GetValueOrDefault<int>("IdPilot"),
                        Name = resultSQL.GetValueOrDefault<string>("Name")
                    });
                }
            });

            return pilots;
        }
    }
}
