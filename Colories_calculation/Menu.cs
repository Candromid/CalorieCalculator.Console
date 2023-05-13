using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colories_calculation
{
    public class Menu
    {
        public enum Spisok
        {
            Масло = 1,
            Огурец ,
            Помидор ,
            Сыр ,
            Курица,
            Картофель,
            Лук,
            Морковь,
            Говядина,
            Рыба
        };

        public List<Product> Products = new List<Product>();

        public Spisok spisok;

        public Menu ()
        {
            
            Products.Add(new Product("Масло", 0.5, 82.5, 0.8, new Dictionary<string, double> { { "A", 684 }, { "E", 2.8 } }));          //0
            Products.Add(new Product("Огурец", 0.8, 0.1, 2.8, new Dictionary<string, double> { { "C", 14 } }));                         //1
            Products.Add(new Product("Помидор", 1.10, 0.2, 3.7, new Dictionary<string, double> { { "C", 13 } }));                       //2
            Products.Add(new Product("Сыр", 24, 31, 0, new Dictionary<string, double> { { "D", 1.5 }, { "E", 0.3 } }));                 //3
            Products.Add(new Product("Курица", 165, 20.8, 0, new Dictionary<string, double> { { "B6", 0.75 }, { "B12", 0.35 } }));      //4
            Products.Add(new Product("Картофель", 0.78, 2.0, 17.0, new Dictionary<string, double> { { "C", 13 }, { "B6", 0.3 } }));     //5
            Products.Add(new Product("Лук", 0.1, 1.4, 4.3, new Dictionary<string, double> { { "C", 8 } }));                             //6
            Products.Add(new Product("Морковь", 0.8, 0.8, 6.9, new Dictionary<string, double> { { "A", 852 }, { "C", 9 } }));           //7
            Products.Add(new Product("Говядина", 250, 18.0, 20.0, new Dictionary<string, double> { { "B12", 2.0 }, { "B6", 0.6 } }));   //8
            Products.Add(new Product("Рыба", 150, 16.1, 1.6, new Dictionary<string, double> { { "D", 0.4 }, { "B12", 1.1 } }));         //9


        }
    }
}
