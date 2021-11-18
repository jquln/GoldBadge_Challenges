using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _queueOfClaim = new Queue<Claim>();
        int _counter = 0;
        //Create
        public bool AddClaimToQueue(Claim claim)
        {
            if (claim == null)
                return false;
            else
            {
                _counter++;
                claim.ClaimID = _counter;

                _queueOfClaim.Enqueue(claim);
                return true;
            }
        }
        
        //Read
        public Queue<Claim> QueueOfClaim()
        {
            return _queueOfClaim; 
        }
        public Claim GetClaim()
        {
            return _queueOfClaim.Peek();
        }

       

        //Update

        //Delete

        public bool RemoveClaimFromQueue()
        {
            int count = _queueOfClaim.Count;
            _queueOfClaim.Dequeue();
            if (count > _queueOfClaim.Count)
            {
                return true;
            }
            else return false;
        }

    }
}
