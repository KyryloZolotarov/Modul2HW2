using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW2
{
    internal class GeneratorRandom
    {
        public int Rand(int min, int max)
        {
            var rnd = new Random();
            int rand = rnd.Next(min, max);
            return rand;
        }
    }
}
