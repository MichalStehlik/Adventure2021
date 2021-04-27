using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure2021.Models;
using Adventure2021.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adventure2021.Pages
{
    public class TrapModel : PageModel
    {
        private Random _random = new Random();
        private const string KEY = "AMAZINGADVENTURE2021";
        private readonly ISessionStorage<GameState> _ss;
        private readonly ILocationProvider _lp;
        public Room ReturnRoom { get; set; }

        public Location Location { get; set; }
        public List<Connection> Connections { get; set; }
        public GameState State { get; set; }
        public int TrapType { get; set; }

        public TrapModel(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
        }

        public void OnGet(Room id, int parameter = 0)
        {
            State = _ss.LoadOrCreate(KEY);
            State.HP -= 1;
            TrapType = parameter;
            ReturnRoom = id;
            //State.Location = id;
            _ss.Save(KEY, State);
            //Location = _lp.GetLocation(id);
            //Connections = _lp.GetConnectionsFrom(id);
        }
    }
}
