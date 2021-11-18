using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> _badgeDB = new Dictionary<int, Badge>();
        int _count = 0;
        public bool AddBadge(Badge badge)
        {
            if (badge == null)
            {
                return false;
            }
            else
            {
                _count++;
                badge.BadgeID = _count;
                _badgeDB.Add(badge.BadgeID, badge);
                return true;
            }
        }
        public Dictionary<int, Badge> GetBadges()
        { 
            return _badgeDB;
        }
        public Badge GiveMeABadge(int key)
        {
            foreach (var badge in _badgeDB)
            {
                if (badge.Key == key)
                {
                    return badge.Value;
                }
            }
            return null;
        }
        public bool AddDoor(int key, string doorName)
        {
            Badge badge = GiveMeABadge(key);
            if (badge != null)
            {
                badge.DoorNames.Add(doorName);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoor(int key, string doorName)
        {
            Badge badge = GiveMeABadge(key);
            if (badge != null)
            {
                foreach (var door in badge.DoorNames)
                {
                    if (door == doorName)
                    {
                        badge.DoorNames.Remove(doorName);
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

    }
}
