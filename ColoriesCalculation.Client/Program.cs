namespace ColoriesCalculation.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();

            //Реализовать через Enum 
            //Product maslo = menu.Products.Single(x =>x.Name=="Масло");
            //Product cucumber = menu.Products.Single(x => x.Name == "Огурец");
            //Product tomatos = menu.Products.Single(x => x.Name == "Помидор");


            Product oil = menu.Products[(int)Menu.Spisok.Масло];
            Product cucumber = menu.Products[(int)Menu.Spisok.Огурец];
            Product tomatos = menu.Products[(int)Menu.Spisok.Помидор];

            Console.WriteLine(menu.Products[(int)Menu.Spisok.Масло].Name);
            
            Dish salat = new Dish("Салат", new Dictionary<Product, double> { { oil, 30 }, { tomatos, 300 }, { cucumber, 200 } });

            Product cheese = menu.Products[(int)Menu.Spisok.Сыр];

            salat.AddProduct(cheese, 200);

            salat.GetTotalVitamins();

            foreach (var product in salat.Products)
            {
                Console.WriteLine($"Калории в {product.Key.Name} {product.Key.CalculateCalories(product.Value)}");

            }

            Console.WriteLine($"Общая калорийность блюда {salat.Name}: {salat.GetTotalCalories()} ккал");

        }
    }
}