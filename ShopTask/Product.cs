using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    internal abstract class Product
    {
        private static int id=1;
        public int Id { get;private set; }
        protected Product(string name, int count, double price)
        {
            Name = name;
            Count = count;
            Price = price;
            Id=id++;
        }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
