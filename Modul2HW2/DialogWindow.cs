using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class DialogWindow
    {
        public static void StartLoadStorage()
        {
            Console.WriteLine("If you want to create new storage press Enter, or press Tab to load existing storage:");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                do
                {
                    Tools.GetInstance().LoadStor();
                    Console.WriteLine();
                    Console.Write("To add anouther product press Enter, to skipp and save press Spacebar:");
                    key = Console.ReadKey().Key;
                    Console.WriteLine();
                }
                while (key != ConsoleKey.Spacebar);
                Tools.GetInstance().SaveToFile();
            }

            if (key == ConsoleKey.Tab)
            {
                Console.WriteLine();
                Tools.GetInstance().LoadStorageFromFile();
            }
        }

        public static void Shopping()
        {
            Console.WriteLine();
            Console.WriteLine("If you want to start shopping press Enter");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                Tools.GetInstance().DisplayStorage();
            }

            Console.WriteLine();
            Console.WriteLine("if you want to add product to your basket type number in List and press Enter");

            do
            {
                var itemN = Console.ReadLine();
                Tools.GetInstance().ProductPick(itemN);
                Console.Write("If you want to add anouther item press Enter, to create order press Tab");
                key = Console.ReadKey().Key;
                Console.WriteLine();
            }
            while (key != ConsoleKey.Tab);
            CheckItemsInOrder();
            Order();
        }

        public static void CheckItemsInOrder()
        {
            Console.WriteLine();
            Tools.GetInstance().DisplayBasket();
        }

        public static void Order()
        {
            var orderNumber = new GeneratorRandom().Rand(0, 300);
            Tools.GetInstance().SaveOrder(orderNumber);
            Console.WriteLine();
            Console.WriteLine("Order successfully created, your order number: " + orderNumber.ToString());
        }
    }
}
