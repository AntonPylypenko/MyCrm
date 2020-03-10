using System;
using System.Collections.Generic;
using System.Text;

namespace CrmBl.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
