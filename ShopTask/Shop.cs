using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    internal class Shop<T> : IDrinkShop<T> where T : Product
    {
        public double TotalIncome { get; private set; }
        public List<Product> Products {  get; private set; }
        private int id = 0;
        public int Id { get; private set; }
        public Shop()
        {
            Products = new List<Product>();
            Id = ++id;
        }
        public void AddProduct(T product)
        {
            Products.Add(product);
            Console.WriteLine($"{product.Name} elave olundu");
        }
        public void  SaleProduct(string productName ,int productQuantity)
        {
           var existProduct=Products.FirstOrDefault(x=>x.Name.ToLower()==productName.ToLower());
            if (existProduct != null)
            {
                if (existProduct.Count>=productQuantity)
                {
                    existProduct.Count -= productQuantity;
                    TotalIncome +=(double) (productQuantity * existProduct.Price);
                }
                else
                {
                    Console.WriteLine("telebe uygun sayda mehsul qalmayib");
                }
                if (existProduct.Count == 0)
                {
                    Products.Remove(existProduct);
                }
            } 
            else
            {
                Console.WriteLine("mehsul tapilmadi");
            }
        }

        public void ShowIncome()
        {
            Console.WriteLine($"Total Income :{TotalIncome}");
        }
    }
}
