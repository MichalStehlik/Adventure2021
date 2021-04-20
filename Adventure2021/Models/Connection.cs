using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2021.Models
{
    public class Connection
    {
        public string Description { get; set; }
        public Room Target { get; set; } // index cílové místnosti
        public string TargetSpecialPage { get; set; } = null;
        public Room From { get; set; } // odkud vycházíme
    }
}
