
namespace ShopTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop<Product> ourShop=new Shop<Product>();
            while (true)
            {
               MainDesc: Console.WriteLine("__MENU__  \n\n 1 - Mehsul elave et \n" +
                   " 2 - Mehsul Sat \n 3 - Qazanci gor \n 4 - Movcud mehsullari gor  \n 0 - Exit");
                string input = Console.ReadLine();
                int operationNum;
                var isSuccessed = int.TryParse(input, out operationNum);
                if (isSuccessed)
                {
                    switch ((Operations)operationNum)
                    {
                        case Operations.Exit:
                            return;
                            case Operations.AddProduct:
                             ProductTypeDesc:
                            Console.WriteLine("hansi tipde mehsul elave olunacaq ? t - Tea / c - Coffee");
                             string inputProductType = Console.ReadLine();
                             
                            if (inputProductType.ToLower()!="t" && inputProductType.ToLower()!="c")
                            {
                                Console.WriteLine(ErrorMessages.WrongChoose);
                                goto ProductTypeDesc;
                            }
                             ProductNameDesc: Console.WriteLine("Mehsul adini daxil edin ");
                               string productNameOfAdd=Console.ReadLine().Replace(" ","");
                            if (productNameOfAdd.Length<3)
                            {
                                Console.WriteLine(ErrorMessages.MinimalChararcter);
                                goto ProductNameDesc;
                            }
                            var existProductOfAdd = ourShop.Products.FirstOrDefault(x => x.Name.ToLower() == productNameOfAdd.ToLower());
                            if (existProductOfAdd != null)
                            {
                               alreadyDesc: Console.WriteLine("mehsul artiq movcuddur davam etmek isteyirsiz mi ? " +
                                    "bu halda mehsul sayini artira bilersiz. he/yox ");
                                input= Console.ReadLine().ToLower().Replace(" ","");

                                switch (input)
                                {
                                    case "he":
                                        goto productCountDesc;
                                    case "yox":
                                        goto MainDesc;
                                    default:
                                        Console.WriteLine(ErrorMessages.WrongChoose);
                                        goto alreadyDesc;
                                }
                            }
                               
                            productCountDesc: Console.WriteLine("mehsul sayini daxil edin");
                              input=Console.ReadLine();
                              int productCountOfAdd;
                              isSuccessed=int.TryParse(input, out productCountOfAdd);
                            if (!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto productCountDesc;
                            }
                            if (productCountOfAdd<1)
                            {
                                Console.WriteLine(ErrorMessages.CanMInimal.Replace("{prop}","say").Replace("{input}", "1"));
                                goto productCountDesc;
                            }
                            if (existProductOfAdd!=null)
                            {
                                existProductOfAdd.Count += productCountOfAdd;
                                Console.WriteLine("mehsulun sayi artirildi");
                                goto MainDesc;
                            }
                              ProductPriceDesc: Console.WriteLine("Mehsulun qiymetini daxil edin");
                              input = Console.ReadLine();
                              double productPriceOfAdd;
                             isSuccessed=double.TryParse(input, out productPriceOfAdd);
                            if (!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto ProductPriceDesc;
                            }
                            if (productPriceOfAdd < 1.5)
                            {
                                Console.WriteLine(ErrorMessages.CanMInimal.Replace("{prop}", "qiymet").Replace("{input}", "1.5"));
                                goto ProductPriceDesc;
                            }
                            if (inputProductType.ToLower()=="t")
                            {
                                ourShop.AddProduct(new Tea(productNameOfAdd,productCountOfAdd,productPriceOfAdd));
                            }
                            if (inputProductType.ToLower()=="c")
                            {
                                ourShop.AddProduct(new Coffee(productNameOfAdd,productCountOfAdd,productPriceOfAdd));
                            }
                            break;

                        case Operations.SaleProduct:
                            if (ourShop.Products.Count==0)
                            {
                                Console.WriteLine(ErrorMessages.HaveBeenProduct);
                                goto MainDesc;
                            }
                        NameOfSaleProductDesc: Console.WriteLine("satmaq istediyiniz mehsulun adini daxil edin");
                            string productNameOfSale= Console.ReadLine().Replace(" ", "");
                            if (productNameOfSale.Length<2)
                            {
                                Console.WriteLine(ErrorMessages.MinimalChararcter);
                                goto NameOfSaleProductDesc;
                            }
                          CountOfSaleProductDesc:  Console.WriteLine("sayini qeyd edin");
                            input = Console.ReadLine();
                            int producQuantityOfSale;
                            isSuccessed=int.TryParse(input,out producQuantityOfSale);
                            if (!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto CountOfSaleProductDesc;
                            }
                            ourShop.SaleProduct(productNameOfSale, producQuantityOfSale);
                            break;
                                
                            case Operations.ShowIncome:
                            ourShop.ShowIncome();
                            break;

                        case Operations.CurrentProduct:
                            if (ourShop.Products.Count==0)
                            {
                                Console.WriteLine(ErrorMessages.HaveBeenProduct);
                            }
                            foreach (var product in ourShop.Products)
                            {
                                Console.WriteLine($"Id: {product.Id}  Mehsul Adi : {product.Name}" +
                                    $"movcud say : {product.Count} " +
                                    $" Mehsulun qiymeti {product.Price}");
                            }
                            break;
                        default:
                            Console.WriteLine(ErrorMessages.WrongChoose);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(ErrorMessages.InvalidFormat);
                }
            }
           
        }
    }
}
