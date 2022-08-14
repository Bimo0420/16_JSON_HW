using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace N1    //1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».


{
    class Program
    {
        static void Main(string[] args)
        {
        const int n = 5;
        Product[] products = new Product[n]; //массив
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { Name = name, Code = code, Price = price };    //Product product = new Product() - конструктор по-умолчанию
            }
            JsonSerializerOptions options = new JsonSerializerOptions()  //позволяет прочитать кириллицу
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true    //форматирование строки - дополнительные пробелы
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../products.json"))    //сохранение файла в debug (по-умолчанию), ../- поднимаемся на уровень вверх 
            {
                sw.WriteLine(jsonString);
            }
        

        }
    }
}
