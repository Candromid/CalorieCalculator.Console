namespace ColoriesCalculation.Entities.Core
{

    public class Product
    {

        public string Name { get; }

        public double Proteins { get; }

        public double Fats { get; }

        public double Carbohydrates { get; }

        public double Weight { get; set; }

        public Dictionary<string, double> Vitamins { get; }

        public Product(string name, double proteins, double fats, double carbohydrates, Dictionary<string, double> vitamins)
        {
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Vitamins = vitamins;
        }

        public void DisplayTheAttribute()
        {
            Console.WriteLine($"Название продукта: {Name}, Количество белков: {Proteins}, Количество жиров: {Fats}, Количество углеводов: {Carbohydrates}");
            Console.WriteLine("Список витаминов и их количество в данном продукте:");
            foreach (var vitamin in Vitamins)
            {
                Console.WriteLine($"{vitamin.Key}: {vitamin.Value} мг");
            }
        }

        public double CalculateCalories()
        {
            double totalCalories = Proteins * 4.0 + Fats * 9.0 + Carbohydrates * 4.0;
            return Math.Round(totalCalories * Weight / 100.0, 2);
        }

    }

}
