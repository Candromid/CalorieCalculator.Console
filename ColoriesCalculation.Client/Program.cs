using ColoriesCalculation.Entities.Core;

namespace ColoriesCalculation.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> productList = new();

            string[] linesFromFile = File.ReadAllLines("products.txt");

            foreach (string line in linesFromFile)
            {
                string[] values = line.Split(' ');                              //разделение целой строки на подстроки

                string nameOfProduct = values[0];
                double amountOfProteins = Convert.ToDouble(values[1]);
                double amountOfFats = Convert.ToDouble(values[2]);
                double amountOfCarbohydrates = Convert.ToDouble(values[3]);

                Dictionary<string, double> dataOfVitamins = new();

                for (int i = 4; i < values.Length; i += 2)
                {
                    if (i + 1 < values.Length)
                    {
                        string nameOfVitamin = values[i];
                        double amountOfVitamin = double.Parse(values[i + 1]);

                        dataOfVitamins[nameOfVitamin] = amountOfVitamin;
                    }
                }

                Product products = new(nameOfProduct, amountOfProteins, amountOfFats, amountOfCarbohydrates, dataOfVitamins);


                productList.Add(products);
            }

            Console.WriteLine("Доступные продукты");
            for (int i = 0; i < productList.Count; i++)
            {
                Product product = productList[i];
                Console.WriteLine($"{i + 1}. {product.Name}");
            }

            // запрос у пользователя выбора продуктов для блюда

            List<Product> selectedProducts = new List<Product>();
            while (true)
            {
                Console.Write("Введите номер продукта, чтобы добавить его в блюдо (или '0' для завершения): ");
                string inputIndex = Console.ReadLine();
                if (inputIndex == "0")
                {
                    break;
                }
               
                if (int.TryParse(inputIndex, out int selectedProductIndex) && selectedProductIndex >= 1 && selectedProductIndex <= productList.Count)
                {
                    Product selectedProduct = productList[selectedProductIndex - 1];
                    selectedProducts.Add(selectedProduct);
                    Console.WriteLine($"Продукт '{selectedProduct.Name}' добавлен в блюдо");
                }

                else
                {
                    Console.WriteLine("Неверный номер продукта. Попробуйте снова.");
                }
            }

            Console.WriteLine("Выбранные продукты для блюда:");
            foreach (var product in selectedProducts)
            {
                Console.WriteLine(product.Name);
            }









            Product oil = productList[0];
            Product cucumber = productList[1];
            Product tomatos = productList[2];


            oil.DisplayTheAttribute();
            cucumber.DisplayTheAttribute();
            tomatos.DisplayTheAttribute();







            //Menu menu = new Menu();

            //Реализовать через Enum 
            //Product maslo = menu.Products.Single(x =>x.Name=="Масло");
            //Product cucumber = menu.Products.Single(x => x.Name == "Огурец");
            //Product tomatos = menu.Products.Single(x => x.Name == "Помидор");


            //Product oil = menu.Products[(int)Menu.Spisok.Масло];
            //Product cucumber = menu.Products[(int)Menu.Spisok.Огурец];
            //Product tomatos = menu.Products[(int)Menu.Spisok.Помидор];

            //Console.WriteLine(menu.Products[(int)Menu.Spisok.Масло].Name);

            //Dish salat = new Dish("Салат", new Dictionary<Product, double> { { oil, 100 }, { tomatos, 100 }, { cucumber, 100 } });

            //Product cheese = menu.Products[(int)Menu.Spisok.Сыр];

            //salat.AddProduct(cheese, 200);

            //salat.GetTotalVitamins();

            //foreach (var product in salat.Products)
            //{
            //    Console.WriteLine($"Калории в {product.Key.Name} {product.Key.CalculateCalories(product.Value)}");

            //}

            //Console.WriteLine($"Общая калорийность блюда {salat.Name}: {salat.GetTotalCalories()} ккал");

        }
    }
}