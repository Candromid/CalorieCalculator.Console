using ColoriesCalculation.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoriesСalculation.Client.Entites
{
    public class Dish
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public Dish(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
           
            {
                Products.Remove(product);
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0.0;
            foreach (var product in Products)
            {
                totalCalories += product.CalculateCalories();
            }
            return Math.Round(totalCalories, 2);
        }

        public void CalculateTotalVitamins()
        {
            Dictionary<string, double> totalVitamins = new Dictionary<string, double>();

            foreach (var product in Products)
            {
                Dictionary<string, double> vitamins = product.Vitamins;

                foreach (var vitamin in vitamins)
                {
                    if (totalVitamins.ContainsKey(vitamin.Key))
                    {
                        totalVitamins[vitamin.Key] += vitamin.Value * product.Weight / 100.0;
                    }
                    else
                    {
                        totalVitamins[vitamin.Key] = vitamin.Value * product.Weight / 100.0;
                    }
                }
            }

            Console.WriteLine("Общее количество витаминов:");
            foreach (var vitamin in totalVitamins)
            {
                Console.WriteLine($"Количество витамина {vitamin.Key}: {vitamin.Value} мг");
            }
        }
    }

}
