using ColoriesCalculation.Entities.Core;
using ColoriesСalculation.Client.Entites;
using System.Linq;

namespace ColoriesCalculation.Client
{
    public class Program
    {
        static List<Dish> dishes = new();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Создать блюдо");
                Console.WriteLine("2. Вывести cписок блюд");
                Console.WriteLine("3. Вывести статистику блюда");
                Console.WriteLine("4. Удалить блюдо");
                Console.WriteLine("0. Выход из программы");
                Console.Write("> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDish();
                        break;
                    case "2":
                        PrintDishList();
                        break;
                    case "3":
                        PrintDishStatistics();
                        break;
                    case "4":
                        RemoveDish();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, повторите.");
                        break;
                }
            }
        }

        static string GetFilePath()
        {
            string solutionFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string fileName = "products.txt";
            string filePath = Path.Combine(solutionFolder, fileName);
            return filePath;
        }

        static List<Product> GetProductList()
        {
            string filePath = GetFilePath();

            List<Product> productList = new();

            string[] linesFromFile = File.ReadAllLines(filePath);
            foreach (string line in linesFromFile)
            {
                string[] values = line.Split(' ');
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

            return productList;
        }

        static List<Product> SearchProductByName(string partialName)
        {
            var productList = GetProductList();
            var foundProducts = productList.Where(p => p.Name.Contains(partialName)).ToList();
            return foundProducts;
        }
        static List<Product> GetSelectedProduct()
        {
            List<Product> selectedProducts = new();

            while (true)
            {
                Console.Write("Введите частичное имя продукта, чтобы добавить его в блюдо (или '0' для завершения: ");
                string partialName = Console.ReadLine();
                if (partialName == "0")
                    break;

                var foundProducts = SearchProductByName(partialName);
                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("Нет продуктов, соответсвтующих введенному частичному имени.");
                    continue;
                }

                Console.WriteLine("Найденные продукты: ");
                for (int i = 0; i < foundProducts.Count; i++)
                {
                    Product product = foundProducts[i];
                    Console.WriteLine($"{i + 1}. {product.Name}");
                }

                Console.Write("Введите номер продукта, чтобы добавить его в блюдо (или '0' для завершения): ");
                string inputIndex = Console.ReadLine();
                if (inputIndex == "0")
                {
                    break;
                }

                if (int.TryParse(inputIndex, out int selectedProductIndex) && selectedProductIndex >= 1 && selectedProductIndex <= foundProducts.Count)
                {
                    Product selectedProduct = foundProducts[selectedProductIndex - 1];
                    Console.Write($"Введите вес для продукта '{selectedProduct.Name}' в граммах: ");
                    string inputWeight = Console.ReadLine();
                    if (double.TryParse(inputWeight, out double weight))
                    {
                        selectedProducts.Add(selectedProduct);
                        selectedProduct.Weight = weight;
                        Console.WriteLine($"Продукт '{selectedProduct.Name}' (вес: {weight} г) добавлен в блюдо");
                    }
                    else
                    {
                        Console.WriteLine("Неверный вес продукта. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный номер продукта. Попробуйте снова.");
                }
            }
            return selectedProducts;
        }

        static void CreateDish()
        {
            while (true)
            {
                Console.WriteLine("Введите название блюда: ");
                string dishName = Console.ReadLine();

                var selectedProducts = GetSelectedProduct();

                Dish newDish = new(dishName);
                foreach (var product in selectedProducts)
                {
                    newDish.AddProduct(product);
                }
                dishes.Add(newDish);

                Console.Write("Хотите добавить еще блюдо в список? (Да/Нет) (Yes/No) (Y/N): ");
                string ch = Console.ReadLine().ToLower();
                if (ch != "да" || ch != "yes" || ch != "y")
                    break;
            }
        }

        static void PrintDishList()
        {
            Console.WriteLine("Cписок имеющихся блюд: ");
            for (int i = 0; i < dishes.Count; i++)
            {
                Dish dish = dishes[i];
                Console.WriteLine($"{i + 1}. {dish.Name}");
            }
        }

        static void PrintDishStatistics()
        {
            PrintDishList();

            Console.Write("Введите номер блюда, чтобы вывести статистику: ");
            string inputIndex = Console.ReadLine();
            if (int.TryParse(inputIndex, out int selectedDishIndex) && selectedDishIndex >= 1 && selectedDishIndex <= dishes.Count)
            {
                Dish selectedDish = dishes[selectedDishIndex - 1];
                Console.WriteLine($"Статистика для блюда: '{selectedDish.Name}' : ");
                Console.WriteLine("Общай калорийность блюда: " + selectedDish.CalculateTotalCalories());
                selectedDish.CalculateTotalVitamins();
            }
            else
                Console.WriteLine("Неверный номер блюда. Пожалуйста, повторите.");

        }

        static void RemoveDish()
        {
            PrintDishList();

            Console.Write("Введите номер блюда, чтобы удалить его: ");
            string inputIndex = Console.ReadLine();
            if (int.TryParse(inputIndex, out int selectedDishIndex) && selectedDishIndex >= 1 && selectedDishIndex <= dishes.Count)
            {
                Dish selectedDish = dishes[selectedDishIndex - 1];
                dishes.Remove(selectedDish);
                Console.WriteLine($"Блюдо '{selectedDish.Name}' успешно удалено.");
            }
            else
                Console.WriteLine("Неверный номер блюда. Пожалуйста, повторите.");
        }
    }
}