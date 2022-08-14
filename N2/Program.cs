using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N1;   //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.IO;
using System.Text.Json;

namespace N2
//2.    Необходимо разработать программу для получения информации о товаре из json-файла.
//Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
//
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;   //видимость за скобками
            using (StreamReader sr = new StreamReader("../../../products.json"))  //открытие файла из N1
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString); 

            Product maxProduct = products[0];   //по-умолчанию присваиваем 0-ую строку (самый 1-й товаримеет бОльшую стоимость)
            foreach(Product x in products)
            {
               if (x.Price>maxProduct.Price) //сравнивая стоимость
                {
                    maxProduct = x;
                }

            }
            Console.WriteLine($"{maxProduct.Code} {maxProduct.Name} {maxProduct.Price}");
            Console.ReadKey();
        }
    }
}
