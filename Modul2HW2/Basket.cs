using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class Basket
    {
        private Product[] _basketString = Array.Empty<Product>();
        public void BasketStringLoad(string stornumber, string prodname, string prodcat, string prodprice)
        {
            var length = _basketString.Length;
            Array.Resize(ref _basketString, newSize: length + 1);
            _basketString[length] = new Product
            {
                Stornumber = stornumber,
                Prodname = prodname,
                Prodcat = prodcat,
                Prodprice = prodprice
            };
        }

        public string GetBasket()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in _basketString)
            {
                stringBuilder.AppendLine($"{item.Stornumber} {item.Prodname} {item.Prodcat} {item.Prodprice}");
            }

            return stringBuilder.ToString();
        }

        public void ClearBasket()
        {
            _basketString = Array.Empty<Product>();
        }
    }
}
