using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2021.Models
{
    public class Location
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
