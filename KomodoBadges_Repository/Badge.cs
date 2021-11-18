using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{

    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge() { }

        public Badge( List<string> doorNames)
        {
            
            DoorNames = doorNames;
        }

    }
}
