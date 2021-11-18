using KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class Badge_UI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            Seed();
            MainMenu();
        }

        private void Seed()
        {
            Badge badge = new Badge(new List<string> { "A1", "A2"});
            Badge badge2 = new Badge(new List<string> { "A1", "A5", "B1"});
            Badge badge3 = new Badge(new List<string> { "A1"});
            _badgeRepo.AddBadge(badge);
            _badgeRepo.AddBadge(badge2);
            _badgeRepo.AddBadge(badge3);
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Choose a menu item:\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        AddABadge();
                        break;
                    case "2":

                        EditABadge();

                        break;
                    case "3":
                        ListAllBadges();

                        break;
                    case "4":
                        continueToRun = Exit();
                       
                        break;
                    default:
                        Console.WriteLine("Please enter valid number.");
                        break;
                }

                
                Console.Clear();
            }
        }
        private bool Exit()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return false;
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> badgesInRepository = _badgeRepo.GetBadges();
            foreach (var item in badgesInRepository)
            {
                DisplayBadgeInfo(item.Value);
            }
            Console.ReadKey();
            
        }

        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            int badgeID = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepo.GiveMeABadge(badgeID);
            DisplayBadgeInfo(badge);
            Console.WriteLine();
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove Door\n" +
                "2. Add Door\n" +
                "3. Return to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":

                    RemoveDoor(badge);
                    break;
                case "2":

                    AddDoor(badge);

                    break;
                case "3":
                    Console.Clear();
                    MainMenu();

                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
            Console.ReadKey();
        }

        private void AddDoor(Badge badge)
        {
            Console.Clear();
            Console.WriteLine("Please Enter a Door Name:");
            string userInput = Console.ReadLine();
            bool success = _badgeRepo.AddDoor(badge.BadgeID, userInput);
            if (success)
            {
                Console.WriteLine("Door has been successfully added.");
            }
            else
            {
                Console.WriteLine("Door was not added.");
            }
            Console.ReadKey();
        }

        private void RemoveDoor(Badge badge)
        {
            Console.Clear();
            Console.WriteLine("Please Enter a Door Name for removal:");
            string userInput = Console.ReadLine();
            bool success = _badgeRepo.RemoveDoor(badge.BadgeID, userInput);
            if (success)
            {
                Console.WriteLine("Door has been successfully removed.");
            }
            else
            {
                Console.WriteLine("Door was not added.");
            }
            Console.ReadKey();
        }

        private void DisplayBadgeInfo(Badge badge)
        {
            Console.WriteLine($"Claim ID: {badge.BadgeID}");
               foreach (var door in badge.DoorNames)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine("--------------------------\n");
        }
        private void AddABadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            bool HasSelectedAllDoors = false;
            while (HasSelectedAllDoors == false)
            {
                Console.WriteLine("Please input a door name:");
                string badgeDoorNameInput = Console.ReadLine();
                badge.DoorNames.Add(badgeDoorNameInput);

                Console.WriteLine("Any other doors(y/n)?");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "y".ToLower())
                {
                    continue;
                }
                else
                {
                    HasSelectedAllDoors = true;
                }
            }

            // Add the badge to the database
           bool success = _badgeRepo.AddBadge(badge);
            if (success)
            {
                Console.WriteLine("Badge successful");
            }
            else
            {
                Console.WriteLine("Was not successful");
            }
            Console.ReadKey();
        }
    }
}
