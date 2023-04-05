using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class Tools
    {
        private readonly Storage _storage;
        private static Tools? instance;
        private readonly Basket _basket;

        private Tools()
        {
            _storage = new Storage();
            _basket = new Basket();
        }

        public static Tools GetInstance()
        {
            instance ??= new Tools();

            return instance;
        }

        public void LoadStor()
        {
            string productinfo;
            string prodcat;
            string prodprice;
            Console.WriteLine("Enter Ptoduct Name:");
            string prodname = Console.ReadLine();
            Console.WriteLine("Enter Ptoduct Category:");
            prodcat = Console.ReadLine();
            Console.WriteLine("Enter Ptoduct Price:");
            prodprice = Console.ReadLine();
            int stornumber = new GeneratorRandom().Rand(1000, 2000);
            productinfo = stornumber.ToString() + " " + prodname + " " + prodcat + " " + prodprice;
            _storage.StorLoad(productinfo);
        }

        public void SaveToFile()
        {
            File.WriteAllText("Storage.txt", string.Join(Environment.NewLine, _storage.GetStorage()));
        }

        public void LoadStorageFromFile()
        {
            string basePath = Environment.CurrentDirectory;
            var path = basePath + "\\Storage.txt";
            if (File.Exists(path) == true)
            {
                var tempStor = File.ReadAllLines(path);
                foreach (var line in tempStor)
                {
                    _storage.StorLoad(line);
                }
            }
            else
            {
                Console.WriteLine("No storages saved, to creat new storage press Enter");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    while (key == ConsoleKey.Enter)
                    {
                        Tools.GetInstance().LoadStor();
                        Console.WriteLine("To add anouther product press Enter, to skipp and save press Spacebar:");
                        key = Console.ReadKey().Key;
                    }

                    Tools.GetInstance().SaveToFile();
                }
            }
        }

        public void DisplayStorage()
        {
            var counter = 1;
            foreach (string product in _storage.GetStorage())
            {
                Console.Write(counter.ToString() + ". ");
                Console.WriteLine(product);
                counter++;
            }
        }

        public void ProductPick(string number)
        {
            var index = 0;
            if (!int.TryParse(number, out index))
            {
                Console.WriteLine("Item with this number doesn't exist");
                return;
            }

            index = index - 1;
            if (index >= 0 && index < _storage.GetStorage().Count())
            {
               _basket.BasketLoad(_storage.GetStorage()[index]);
            }
            else
            {
                Console.WriteLine("Item with this number doesn't exist");
            }
        }

        public void DisplayBasket()
        {
            foreach (var item in _basket.GetBasket())
            {
                Console.WriteLine(item);
            }
        }

        public void SaveOrder(int ordernumber)
        {
            string orderN = "order_" + ordernumber.ToString() + ".txt";
            File.WriteAllText(orderN, string.Join(Environment.NewLine, _basket.GetBasket()));
            _basket.CLear();
        }
    }
}
