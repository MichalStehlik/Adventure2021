using Adventure2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2021.Services
{
    public class LocationProvider : ILocationProvider
    {
        private readonly List<Location> _locations = new()
        { 
            new Location { Title = "Start", Description = "<p>This is where our story starts.</p>" }, // 1
            new Location { Title = "Hall", Description = "<p>You stand in seemingly empty hall. There is a long time ago abandoned fireplace covered in spider webbings. You can see two other rooms - library and dining hall. Dirt and dust is ubiquitous here. This whole place is abandoned for a very long time.</p>" }, // 2
            new Location { Title = "Library", Description = "<p>Library is in utterly <b>desolate</b> state. There are two bookcases still standing, full of half eaten grimoires. Whole place mouse ridden. Only path from here leads to main hall.</p>"},
            new Location { Title = "Dining Hall", Description = "<p>Once this room looked magnifent and opulent. Once it hosted famous and rich people. Now just a few spiders lingers here hunting for an easy prey. Suddenly you feel a presence of someone watching you. But you are alone in this house, aren`t you? You can return to main hall.</p>" }
        };

        private readonly List<Connection> _map = new()
        {
            new Connection { From = Room.Start, Target = Room.Hall, Description = "<p>Go to hall</p>"},
            new Connection { From = Room.Hall, Target = Room.Library, Description = "<p>Visit library</p>" },
            new Connection { From = Room.Library, Target = Room.Library, Description = "<p>Search left bookcase</p>", TargetSpecialPage="Trap", Parameter = 1 },
            new Connection { From = Room.Library, Target = Room.Hall, Description = "<p>Back to hall</p>"},
            new Connection { From = Room.Hall, Target = Room.Start, Description = "<p>Search fireplace</p>", TargetSpecialPage="GameOver"},
            new Connection { From = Room.Hall, Target = Room.DiningHall, Description = "<p>Go to dining hall</p>" },
            new Connection { From = Room.DiningHall, Target = Room.Hall, Description = "<p>Go to main hall</p>" },
        };
        public bool ExistLocation(Room id)
        {
            return (_locations.Count > (int)id);
        }

        public List<Connection> GetConnectionsFrom(Room id)
        {
            if (ExistLocation(id))
            {
                return _map.Where(c => c.From == id).ToList();
            }
            throw new InvalidLocationException();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            if (ExistLocation(id))
            {
                return _map.Where(c => c.Target == id).ToList();
            }
            throw new InvalidLocationException();
        }

        public Location GetLocation(Room id)
        {
            if (ExistLocation(id))
            {
                return _locations[(int)id];
            }
            throw new InvalidLocationException();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
