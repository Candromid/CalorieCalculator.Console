namespace Colories_calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Menu menu = new Menu();

              //Реализовать через Enum 
            Product maslo = menu.Products.Single(x =>x.Name=="Масло");
            Product cucumber = menu.Products.Single(x => x.Name == "Огурец");
            Product tomatos = menu.Products.Single(x => x.Name == "Помидор");

            
            //Добавить в результатах округление до 2 чисел после запятой 

            Dish salat = new Dish("Салат", new Dictionary<Product, double> { { maslo, 30 }, { tomatos, 300 }, { cucumber, 200 } });

            Product cheese = menu.Products.Single(x => x.Name == "Сыр");

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