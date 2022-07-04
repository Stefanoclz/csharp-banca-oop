using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    public abstract class Conto
    {

        Cliente intestatario;
        public int totaleConto;

        public abstract void Preleva();

        public abstract void Deposita();

        public abstract void StampaConto();

    }
}
