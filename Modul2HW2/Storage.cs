using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class Storage
    {
        private Product[] _storageString = Array.Empty<Product>();
        public void StoragetStringLoad(string stornumber, string prodname, string prodcat, string prodprice)
        {
            var length = _storageString.Length;
            Array.Resize(ref _storageString, newSize: length + 1);
            _storageString[length] = new Product
            {
                Stornumber = stornumber,
                Prodname = prodname,
                Prodcat = prodcat,
                Prodprice = prodprice
            };
        }

        public string GetStringStorage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in _storageString)
            {
                stringBuilder.AppendLine($"{item.Stornumber} {item.Prodname} {item.Prodcat} {item.Prodprice}");
            }

            return stringBuilder.ToString();
        }

        public void StoragetStringLoadFromFile(string line)
        {
            string stornumber = string.Empty;
            string prodname = string.Empty;
            string prodcat = string.Empty;
            string prodprice = string.Empty;
            int i = 0;
            string[] linetemp = line.Split();
            stornumber = linetemp[i];
            i++;
            prodname = linetemp[i];
            i++;
            prodcat = linetemp[i];
            i++;
            prodprice = linetemp[i];
            var length = _storageString.Length;
            Array.Resize(ref _storageString, newSize: length + 1);
            _storageString[length] = new Product
            {
            Stornumber = stornumber,
            Prodname = prodname,
            Prodcat = prodcat,
            Prodprice = prodprice
            };
        }
    }
}
