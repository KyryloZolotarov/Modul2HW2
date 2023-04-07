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
            productinfo = stornumber.ToString();
            _storage.StoragetStringLoad(productinfo, prodname, prodcat, prodprice);
        }

        public void SaveToFile()
        {
            File.WriteAllText("Storage.txt", _storage.GetStringStorage());
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
                    _storage.StoragetStringLoadFromFile(line);
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
            var tempstring = _storage.GetStringStorage().Split('\n');
            var index = tempstring.Length;
            index--;
            for (int i = 0; i < index; i++)
            {
                Console.Write(counter.ToString() + ". ");
                Console.WriteLine(tempstring[i]);
                counter++;
            }
        }

        public void ProductPick(string number)
        {
            if (!int.TryParse(number, out int index))
            {
                Console.WriteLine("Item with this number doesn't exist");
                return;
            }

            var tempstring = _storage.GetStringStorage().Split('\n');
            index--;
            string line = tempstring[index];
            string[] linetemp = line.Split();
            var i = 0;
            string stornumber = linetemp[i];
            i++;
            string prodname = linetemp[i];
            i++;
            string prodcat = linetemp[i];
            i++;
            string prodprice = linetemp[i];
            if (index >= 0 && index < tempstring.Length)
            {
                _basket.BasketStringLoad(stornumber, prodname, prodcat, prodprice);
            }
            else
            {
                Console.WriteLine("Item with this number doesn't exist");
            }
        }

        public void DisplayBasket()
        {
            var tempstring = _basket.GetBasket().Split('\n');
            foreach (var item in tempstring)
            {
                Console.WriteLine(item);
            }
        }

        public void SaveOrder(int ordernumber)
        {
            string orderN = "order_" + ordernumber.ToString() + ".txt";
            var tempstring = _basket.GetBasket().TrimEnd('\n');
            File.WriteAllText(orderN, tempstring);
            _basket.ClearBasket();
        }
    }
}
