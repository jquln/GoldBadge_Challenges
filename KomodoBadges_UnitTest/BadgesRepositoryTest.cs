using KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_UnitTest
{
    [TestClass]
    public class BadgesRepositoryTest
    {
        private readonly object _badgeDB;
        private BadgeRepository _repo;
        private Badge _badge;
        private Badge _badge2;
        private List<string> doorNames;

        [TestMethod]
        public void Arrange()
        {
            _repo = new BadgeRepository();
            _badge = new Badge(doorNames);
        }
        [TestMethod]
        public void ShouldAddBadge()
        {
            Badge badge = 
            bool success = _repo.AddBadge(_badge);
            Assert.IsNotNull(_badgeDB);
        }


        [TestMethod]
        public void ShouldAddDoor()
        {
            Assert.IsTrue(_badge == null);
        }
        [TestMethod]
        public void ShouldRemoveDoor()
        {
            
        }
    }
}
