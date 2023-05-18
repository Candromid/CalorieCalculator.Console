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
                string[] values = line.Split(' ');

                string nameOfProduct = values[0];
                double amountOfProteins = Convert.ToDouble(values[1]);
                double amountOfFats = Convert.ToDouble(values[2]);
                double amountOfCarbohydrates = Convert.ToDouble(values[3]);

                Dictionary<string, double> dataOfVitamins = new();

                for (int i = 4; i < values.Length; i++)
                {

                    double amountOfVitamin = Convert.ToDouble(values[i]);
                    string nameOfVitamin = $"Витамин {i-3}" ;
                    dataOfVitamins[nameOfVitamin] = amountOfVitamin;
                }

                Product products = new(nameOfProduct, amountOfProteins, amountOfFats, amountOfCarbohydrates, dataOfVitamins);


                productList.Add(products);
            }













            //Menu menu = new Menu();

            //Реализовать через Enum 
            //Product maslo = menu.Products.Single(x =>x.Name=="Масло");
            //Product cucumber = menu.Products.Single(x => x.Name == "Огурец");
            //Product tomatos = menu.Products.Single(x => x.Name == "Помидор");


            //Product oil = menu.Products[(int)Menu.Spisok.Масло];
            //Product cucumber = menu.Products[(int)Menu.Spisok.Огурец];
            //Product tomatos = menu.Products[(int)Menu.Spisok.Помидор];

            //Console.WriteLine(menu.Products[(int)Menu.Spisok.Масло].Name);

            //Dish salat = new Dish("Салат", new Dictionary<Product, double> { { oil, 30 }, { tomatos, 300 }, { cucumber, 200 } });

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