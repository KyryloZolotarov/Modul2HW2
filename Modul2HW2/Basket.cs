using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class Basket
    {
        private List<string> BasketStor { get; set; } = new List<string>();
        public void BasketLoad(string productadded)
        {
            BasketStor.Add(productadded);
        }

        public List<string> GetBasket()
        {
            return BasketStor;
        }

        public void CLear()
        {
            BasketStor.Clear();
        }
    }
}
