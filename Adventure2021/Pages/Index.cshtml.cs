using Adventure2021.Models;
using Adventure2021.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2021.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private const string KEY = "AMAZINGADVENTURE2021";
        private readonly ISessionStorage<GameState> _ss;
        private readonly ILocationProvider _lp;
        public GameState State { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ISessionStorage<GameState> ss)
        {
            _logger = logger;
            _ss = ss;
        }

        public void OnGet()
        {
            State = new GameState { HP = 3 };
            _ss.Save(KEY, State);
        }
    }
}
