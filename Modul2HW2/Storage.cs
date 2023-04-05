using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class Storage
    {
        private List<string> ProductsList { get; set; } = new List<string>();
        public void StorLoad(string productInfo)
        {
            ProductsList.Add(productInfo);
        }

        public List<string> GetStorage()
        {
            return ProductsList;
        }
    }
}
