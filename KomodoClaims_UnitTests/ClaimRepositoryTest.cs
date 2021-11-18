using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaims_UnitTests
{
    [TestClass]
    public class ClaimRepositoryTest
    {
        //private MenuRepository _repo;
        //private Menu _meal;


        //[TestInitialize]
        //public void Arrange()
        //{
        //    _repo = new MenuRepository();
        //    _meal = new Menu("Combo #1", "name", "description", "ingredients", 0.00d);

        //    _repo.AddMealsToList(_meal);

        //}


        private ClaimRepository _repo;
        private Claim _claim;
        private Claim _claim2;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(ClaimType.Car, "Car claim", 100.00d, new DateTime(2021,09,30), new DateTime(2021,10,31));
            _claim2 = new Claim(ClaimType.Home, "Home claim", 1000.00d, new DateTime(2021,05,30), new DateTime(2021,10,31));

            _repo.AddClaimToQueue(_claim);
            _repo.AddClaimToQueue(_claim2);
        }

        [TestMethod]
        public void ShouldAddClaimToQueue()
        {
            bool success = _repo.AddClaimToQueue(_claim);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void QueueOfClaims_ShouldReturnAllClaims()
        {
            //Claim is a collection
            foreach (Claim claim in _repo.QueueOfClaim())
            {
                Console.WriteLine(claim.TypeOfClaim);
            }
            int expected = 2;
            int actual = _repo.QueueOfClaim().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetClaim_ShouldReturnAClaim()
        {
            Claim claim = _repo.GetClaim();
            Assert.IsNotNull(claim);
        }
        [TestMethod]
        public void RemoveClaimFromQueue_ShouldRemoveAClaim()
        {
            Assert.IsTrue(_repo.RemoveClaimFromQueue());
        }
    }
}
