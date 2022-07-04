using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class ContoClassico : Conto
    {
        public Cliente intestatario;
        public int totaleConto;

        public ContoClassico(Cliente intestatario, int totaleConto)
        {
            this.intestatario = intestatario;
            this.totaleConto = totaleConto;
        }

        public override void Preleva()
        {
            Console.WriteLine("Quanto vuoi prelevare?");
            int prelievo = Int32.Parse(Console.ReadLine());

            if(prelievo < this.totaleConto && this.totaleConto > 0)
            {
                this.totaleConto = this.totaleConto - prelievo;
                Console.WriteLine($"Prelievo effettuato, hai ritirato {prelievo} Euro");
            }

            StampaConto();
        }

        public override void StampaConto()
        {
            Console.WriteLine($"Conto Classico intestato a: {intestatario.Nome} {intestatario.Cognome} | Totale sul conto: {this.totaleConto} Euro");
        }

        public override void Deposita()
        {
            Console.WriteLine("Quanto vuoi depositare?");
            int deposito = Int32.Parse(Console.ReadLine());

            this.totaleConto += deposito;
            Console.WriteLine($"Deposito effettuato! Hai depositato {deposito} Euro");
            StampaConto();
        }
    }
}
