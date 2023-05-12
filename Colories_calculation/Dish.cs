using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colories_calculation
{
    // Определяем класс "Блюдо"
    public class Dish
    {
        // Свойство для хранения названия блюда
        public string Name { get; set; }

        // Свойство для хранения списка продуктов в блюде и их весов
        public Dictionary<Product, double> Products { get; set; }

        // Конструктор класса, принимающий название блюда и список продуктов в блюде
        public Dish(string name, Dictionary<Product, double> products)
        {
            Name = name;
            Products = products;
        }

        // Метод для добавления продукта в блюдо
        public void AddProduct(Product product, double weight)
        {
            // Если продукт уже есть в списке, увеличиваем его вес
            if (Products.ContainsKey(product))
            {
                Products[product] += weight;
            }
            // Иначе добавляем продукт с указанным весом
            else
            {
                Products.Add(product, weight);
            }
        }

        public void RemoveProduct(Product product)
        {
            // Удаляем продукт из списка, если он есть
            if (Products.ContainsKey(product))
            {
                Products.Remove(product);
            }
        }

        // Метод для расчета общей калорийности блюда
        public double GetTotalCalories()
        {
            double totalCalories = 0.0;

            // Проходим по всем продуктам в блюде и суммируем их калории
            foreach (var product in Products)
            {
                totalCalories += product.Key.CalculateCalories(product.Value);
            }

            // Возвращаем общую калорийность блюда
            return totalCalories;
        }

        public void GetTotalVitamins()
        {
            Dictionary<string, double> totalVitamins = new Dictionary<string, double>();

            foreach (var kvp in Products)
            {
                // Получаем словарь витаминов для текущего продукта
                Dictionary<string, double> vitamins = kvp.Key.Vitamins;

                // Суммируем витамины для текущего продукта
                foreach (var vitamin in vitamins)
                {
                    if (totalVitamins.ContainsKey(vitamin.Key))
                    {
                        totalVitamins[vitamin.Key] += vitamin.Value * kvp.Value / 100.0;
                    }
                    else
                    {
                        totalVitamins[vitamin.Key] = vitamin.Value * kvp.Value / 100.0;
                    }
                }
            }

            // Выводим общее количество витаминов на консоль
            Console.WriteLine("Общее количество витаминов:");
            foreach (var vitamin in totalVitamins)
            {
                Console.WriteLine($"Количество витамина {vitamin.Key}: {vitamin.Value} мг");
            }
        }

    }


}
