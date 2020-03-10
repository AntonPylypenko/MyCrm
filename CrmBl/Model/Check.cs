using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmBl.Model
{
    public class Check
    {
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public DateTime Created { get; set; }
        public override string ToString()
        {
            return $"№{CheckId} from {Created.ToString()}";
        }
    }
}
