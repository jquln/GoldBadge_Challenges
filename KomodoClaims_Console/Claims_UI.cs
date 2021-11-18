using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    public class Claims_UI
    {
        //private readonly StreamingRepository _streamingRepo = new StreamingRepository();
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            Seed();
            Claims();
        }

       

        private void Claims()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        SeeAllClaims();
                        break;
                    case "2":

                        TakeCareOfNextClaim();
                        
                        break;
                    case "3":
                        AddToQueue();
                        
                        break;
                    default:
                      Console.WriteLine("Please enter valid number.");
                        break;
                }

                Console.WriteLine("Press Enter to proceed.");
                Console.ReadLine();
                Console.Clear();
            }

            
           
        }
        private void AddToQueue()
        {
            Console.Clear();
            // In order to assign any properties to a claim  we have to make a new one
            Claim claim = new Claim();
            //  public ClaimType TypeOfClaim { get; set; }
            Console.WriteLine("Select a claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n" );
            //string genreInput = Console.ReadLine();
            string claimTypeInput = Console.ReadLine();


            //int genreId = int.Parse(genreInput);
            int claimID = int.Parse(claimTypeInput);

            //content.TypeOfGenre = (GenreType)genreId;
            claim.TypeOfClaim = (ClaimType)claimID;

            //public string Description { get; set; }
            Console.WriteLine("Add a description to the claim:");
            string claimDescriptionInput = Console.ReadLine();
            claim.Description = claimDescriptionInput;

            //public double ClaimAmount { get; set; }
            Console.WriteLine("Add an amount to the claim:");
            string claimAmountInput = Console.ReadLine();
            claim.ClaimAmount = double.Parse(claimAmountInput);

            //public DateTime DateOfIncident { get; set; }
            Console.WriteLine("Enter the date of the incident: YY/MM/DD");
            string claimDateOfIncidentInput = Console.ReadLine();
            claim.DateOfIncident = DateTime.Parse(claimDateOfIncidentInput);

            //public DateTime DateOfClaim { get; set; }
            Console.WriteLine("Enter the date of the claim: YY/MM/DD");
            string claimDateOfClaim = Console.ReadLine();
            claim.DateOfClaim = DateTime.Parse(claimDateOfClaim);

            // After all of the properties have been accounted for within our claim object, we can move on to using our AddClaimToQueue repository method.
            // Because AddClaimToQueue returns a bool we're going to store it within a variable of type bool.
            bool success = _claimRepo.AddClaimToQueue(claim);

            // We want to check and see if success is true. If true, we'll make a message that tells the user that the claim was added. If false, we'll make another message that the claim was not added.
            if (success)
            {
                Console.WriteLine("Claim was added.");
            }
            else
            {
                Console.WriteLine("Claim was not added.");
            }
            Console.ReadKey();

    }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            // I need to see who is next in line.
            Claim claim = _claimRepo.GetClaim();
            DisplayClaimInfo(claim);

            // We want to ask the user if they want to handle the claim or not.
            Console.WriteLine("Would you like to handle the claim? y/n");
            string handleNextClaimInput = Console.ReadLine();
            // If the user hits the "y" key then we'll handle the claim. If they hit any other button, back to main menu.
            if (handleNextClaimInput == "y".ToLower())
            {
                bool success = _claimRepo.RemoveClaimFromQueue();
                if (success)
                {
                    Console.WriteLine("Your claim has been handled!");
                }
                else
                {
                    Console.WriteLine("Your claim was not handled...");
                }
            }
            else
            {
                Console.Clear();
                Claims();
            }
            Console.ReadKey();
        }
        private void SeeAllClaims()
        {
            Console.Clear();

           
            Queue<Claim> collectionOfClaims = _claimRepo.QueueOfClaim();

            // You can only the data inside a collection by looping through it.
            foreach (Claim claim in collectionOfClaims)
            {
                DisplayClaimInfo(claim);
            }
            Console.ReadKey();
        }
        // Helper Method
        private void DisplayClaimInfo(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid?: {claim.IsValid}\n");
            Console.WriteLine("--------------------------\n");
        }

        private void Seed()
        {
            Claim claim = new Claim(ClaimType.Car, "car accident on highway", 700.00d, new DateTime(2021,03,22), new DateTime(2021,04,20));
            Claim claim1 = new Claim(ClaimType.Home, "Roof leak", 900.00d, new DateTime(2021, 03, 22), new DateTime(2021, 04, 20));
            Claim claim2 = new Claim(ClaimType.Theft, "Stolen cookies", 700.00d, new DateTime(2021, 01, 22), new DateTime(2021, 04, 20));

            _claimRepo.AddClaimToQueue(claim); 
            _claimRepo.AddClaimToQueue(claim1); 
            _claimRepo.AddClaimToQueue(claim2); 
        }

    }
}
