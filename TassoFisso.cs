using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class TassoFisso : Interesse
    {
        public override double AddInteresse(int ammontare)
        {
            double tasso = 4.5;

            double interesse = ammontare * (tasso / 100);

            double totale = ammontare + interesse;

            return totale;
        }
    }
}
