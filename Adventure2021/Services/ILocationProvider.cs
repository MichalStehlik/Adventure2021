using Adventure2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2021.Services
{
    public interface ILocationProvider
    {
        bool ExistLocation(Room id);
        Location GetLocation(Room id);
        bool IsNavigationLegitimate(Room from, Room to, GameState state);
        List<Connection> GetConnectionsFrom(Room id);
        List<Connection> GetConnectionsTo(Room id);
    }
}
