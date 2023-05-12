using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colories_calculation
{
    // Определяем класс "Продукт"
    public class Product
    {
        // Свойство для хранения имени продукта
        public string Name { get; set; }
        // Свойство для хранения количества белков в продукте
        public double Proteins { get; set; }
        // Свойство для хранения количества жиров в продукте
        public double Fats { get; set; }
        // Свойство для хранения количества углеводов в продукте
        public double Carbohydrates { get; set; }
        // Свойство для хранения количества калорий в продукте
        public double Calories { get; set; }
        // Свойство для хранения словаря витаминов в продукте
        public Dictionary<string, double> Vitamins { get;  }


        // Конструктор класса, принимающий все свойства продукта
        public Product(string name, double proteins, double fats, double carbohydrates, Dictionary<string, double> vitamins)
        {
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Vitamins = vitamins;
        }
        // Метод отображающий характеристики продукта
        public void DisplayTheAttribute()
        {
            Console.WriteLine($"Название продукта: {Name}, Количество белков: {Proteins}, Количество жиров: {Fats}, Количество углеводов: {Carbohydrates}");
            Console.WriteLine("Список витаминов и их количество в данном продукте:");
            foreach (var vitamin in Vitamins)
            {
                Console.WriteLine($"{vitamin.Key}: {vitamin.Value} мг");
            }
        }

        // Метод для расчета количества калорий в продукте, принимающий вес продукта в граммах
        public double CalculateCalories(double weight)
        {
            // Рассчитываем количество белков, жиров и углеводов в продукте на основе его веса
            double totalProteins = Proteins * weight / 100.0;
            double totalFats = Fats * weight / 100.0;
            double totalCarbohydrates = Carbohydrates * weight / 100.0;

            // Рассчитываем количество калорий в продукте на основе его количества белков, жиров и углеводов
            double totalCalories = totalProteins * 4.0 + totalFats * 9.0 + totalCarbohydrates * 4.0;

            // Возвращаем количество калорий в продукте
            return totalCalories;
        }


    }

}
