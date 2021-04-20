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
            new Location { Title = "Start", Description = "<p>This is where our story starts.</p>"}, // 1
            new Location { Title = "Hall", Description = "<p>You stand in seemingly empty hall ...</p>"}, // 2
            new Location {Title = "Library", Description = "<p>Library is in utterly <b>desolate</b> state ...</p>"}
        };

        private readonly List<Connection> _map = new()
        {
            new Connection { From = Room.Start, Target = Room.Hall, Description = "<p>Go to hall</p>"},
            new Connection { From = Room.Hall, Target = Room.Library, Description = "<p>Visit Library</p>" },
            new Connection { From = Room.Library, Target = Room.Hall, Description = "<p>Back to hall</p>"},
            new Connection { From = Room.Hall, Target = Room.Start, Description = "<p>Search fireplace</p>", TargetSpecialPage="GameOver"}
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
