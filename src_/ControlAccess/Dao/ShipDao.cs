using ControlAcess.Entidades;
using ControlAcess.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlAcess.Dao
{
    public class ShipDao : DaoBase
    {
        public async Task InsertShips(List<Ship> ships)
        {
            if (!ships.Any())
                return;

            var check = "if (not exists(select 1 from Ships where IdShip = {0}))\n";
            var insert = "insert Ships (IdShip, Name, Model, Passagers, Charge, Class) values({0}, '{1}', '{2}', {3}, {4}, '{5}');\n";
            var commands = ships.Select(ship => string.Format(check, ship.IdShip) + string.Format(insert, ship.IdShip, ship.Name, ship.Model, ship.Passagers, ship.Charge, ship.Class));

            await Insert(string.Join('\n', commands));
        }

        public async Task<List<Ship>> GetByNameLike(string name)
        {
            var ships = new List<Ship>();
            var command = $"select * from Ships where name like '%{name.Replace(' ', '%')}%'";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    ships.Add(new Ship
                    {
                        IdShip = resultSQL.GetValueOrDefault<int>("IdShip"),
                        Name = resultSQL.GetValueOrDefault<string>("Name")
                    });
                }
            });

            return ships;
        }

        public async Task<Ship> getById(int idShip)
        {
            Ship ship = null;
            var command = @$"
                                select	t1.*
                                from	Ships t1
                                where	t1.IdShip = {idShip}";

            await Select(command, resultSQL =>
            {
                while (resultSQL.Read())
                {
                    ship = new Ship
                    {
                        IdShip = resultSQL.GetValueOrDefault<int>("IdShip"),
                        Name = resultSQL.GetValueOrDefault<string>("Name"),
                        Model = resultSQL.GetValueOrDefault<string>("Model"),
                        Passagers = resultSQL.GetValueOrDefault<int>("Passagers"),
                        Charge = resultSQL.GetValueOrDefault<double>("Charge"),
                        Class = resultSQL.GetValueOrDefault<string>("Class")
                    };
                }
            });

            return ship;
        }

        public async Task<int?> GetCommander(int idShip)
        {
            int? idPilot = null;
            var command = $"select IdPilot from HistoricalTravel t1 where t1.IdShip = {idShip} and t1.DtArrival is null";

            await Select(command, resultSQL =>
            {
                while(resultSQL.Read())
                {
                    idPilot = resultSQL.GetValueOrDefault<int?>("IdPilot");
                }
            });

            return idPilot;
        }
    }
}
