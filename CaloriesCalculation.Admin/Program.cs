using ColoriesCalculation.Entities.Core;

namespace CaloriesCalculation.Admin
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Product> listForProductData = new();

            while (true)
            {
                Console.WriteLine("Enter product data");
                Console.Write("Укажите название продукта: ");
                string nameOfProduct = Console.ReadLine();
                Console.Write("Укажите количество белков в продукте: ");
                double amountOfProteins;
                while (!double.TryParse(Console.ReadLine(), out amountOfProteins))
                    Console.WriteLine("Неверный формат значения! Введите заного");

                Console.Write("Укажите количество жиров в продукте: ");
                double amountOfFats;
                while (!double.TryParse(Console.ReadLine(), out amountOfFats))
                    Console.WriteLine("Неверный формат значения! Введите заного");

                Console.Write("Укажите количество углеводов в продукте: ");
                double amountOfCarbohydrates;
                while (!double.TryParse(Console.ReadLine(), out amountOfCarbohydrates))
                    Console.WriteLine("Неверный формат значения! Введите заного");

                Dictionary<string, double> dataOfVitamins = new();

                while (true)
                {
                    Console.Write("Введите название витамина: ");
                    string nameOfVitamin = Console.ReadLine();

                    Console.Write("Введите количество витамина: ");
                    double amountOfVitamin = double.Parse(Console.ReadLine());

                    dataOfVitamins[nameOfVitamin] = amountOfVitamin;

                    Console.Write("Хотите добавить данные о новом витамине? (Да/Нет): ");

                    string choiseForVitamin = Console.ReadLine();
                    if (choiseForVitamin.ToLower() != "да")
                        break;
                }

                Product product = new(nameOfProduct, amountOfProteins, amountOfFats, amountOfCarbohydrates, dataOfVitamins);


                listForProductData.Add(product);


                Console.Write("Хотите добавить данные о новом продукте? (Да/Нет): ");
                string choiseForProductData = Console.ReadLine();
                if (choiseForProductData.ToLower() != "да")
                    break;
            }
           

            List <string> listForLines = new();

            foreach (var product in listForProductData)
            {
                string line = product.Name + " " + product.Proteins + " " + product.Fats + " " + product.Carbohydrates + " ";

                foreach (var vitamin in product.Vitamins)
                {
                    line += vitamin.Key + " " + vitamin.Value + " ";
                }

                listForLines.Add(line);
            }

            File.WriteAllLines("products.txt", listForLines);









           
            




        }
    }
}