using ColoriesCalculation.Entities.Core;

namespace CaloriesCalculation.Admin
{
    public class Program
    {
        static void Main(string[] args)
        {

            string filePath = GetFilePath();

            var listWithProductData = GetListWithProductData();

            List<string> listForLines = new();

            foreach (var product in listWithProductData)
            {
                string line = product.Name + " " + product.Proteins + " " + product.Fats + " " + product.Carbohydrates + " ";        //доделать

                foreach (var vitamin in product.Vitamins)
                {
                    line += vitamin.Key + " " + vitamin.Value + " ";
                }

                listForLines.Add(line);
            }

            File.AppendAllLines(filePath, listForLines);

        }
        static string GetFilePath()
        {
            string solutionFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string fileName = "products.txt";
            string filePath = Path.Combine(solutionFolder, fileName);
            return filePath;
        }

        static List<Product> GetListWithProductData()
        {
            List<Product> listWithProductData = new();

            while (GetProductChoice())
            {

                Console.WriteLine("Enter product data");

                string nameOfProduct = GetNameOfProduct();

                double amountOfProteins = GetAmountOfProteins();

                double amountOfFats = GetAmountOfFats();

                double amountOfCarbohydrates = GetAmountOfCarbohydrates();

                var dataOfVitamins = GetDataOfVitamins();

                Product product = new(nameOfProduct, amountOfProteins, amountOfFats, amountOfCarbohydrates, dataOfVitamins);

                listWithProductData.Add(product);

            }

            return listWithProductData;
        }

        //добавить грамовку
        static string GetNameOfProduct()
        {
            Console.Write("Укажите название продукта: ");
            string nameOfProduct = Console.ReadLine();

            return nameOfProduct;
        }

        static double GetAmountOfProteins()
        {
            Console.Write("Укажите количество белков в продукте : ");
            double amountOfProteins;
            while (!double.TryParse(Console.ReadLine(), out amountOfProteins))
                Console.WriteLine("Неверный формат значения! Введите заного");

            return amountOfProteins;
        }

        static double GetAmountOfFats()
        {
            Console.Write("Укажите количество жиров в продукте: ");
            double amountOfFats;
            while (!double.TryParse(Console.ReadLine(), out amountOfFats))
                Console.WriteLine("Неверный формат значения! Введите заного");

            return amountOfFats;
        }

        static double GetAmountOfCarbohydrates()
        {
            Console.Write("Укажите количество углеводов в продукте: ");
            double amountOfCarbohydrates;
            while (!double.TryParse(Console.ReadLine(), out amountOfCarbohydrates))
                Console.WriteLine("Неверный формат значения! Введите заного");

            return amountOfCarbohydrates;
        }

        static Dictionary<string, double> GetDataOfVitamins()
        {
            Dictionary<string, double> dataOfVitamins = new();

            while (GetVitaminChoice())
            {

                Console.Write("Введите название витамина: ");
                string nameOfVitamin = Console.ReadLine();

                Console.Write("Введите количество витамина: ");
                double amountOfVitamin = double.Parse(Console.ReadLine());

                dataOfVitamins[nameOfVitamin] = amountOfVitamin;

            }
            return dataOfVitamins;
        }

        static bool GetProductChoice()
        {
            Console.Write("Хотите добавить данные о новом продукте? (Да/Нет): ");
            string choice = Console.ReadLine();
            return choice.ToLower() == "да";
        }

        static bool GetVitaminChoice()
        {
            Console.Write("Хотите добавить данные о новом витамине? (Да/Нет): ");
            string choice = Console.ReadLine();
            return choice.ToLower() == "да";
        }
    }
}