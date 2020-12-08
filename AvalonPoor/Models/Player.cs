using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvalonPoor.Models
{
    public class Player
    {
        public string DisplayName { get; set; }
        public Role Role { get; set; }
        public Guid PlayerId { get; set; }
    }
}
