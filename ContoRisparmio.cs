using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class ContoRisparmio : Conto
    {
        public Cliente intestatario;
        public int totaleConto;

        public ContoRisparmio(Cliente intestatario, int totaleConto)
        {
            this.intestatario = intestatario;
            this.totaleConto = totaleConto;
        }

        public override void Preleva()
        {
            Console.WriteLine("Quanto vuoi prelevare?");
            int prelievo = Int32.Parse(Console.ReadLine());

            if (prelievo < this.totaleConto && this.totaleConto > 1000)
            {
                this.totaleConto = this.totaleConto - prelievo;
                Console.WriteLine($"Prelievo effettuato, hai ritirato {prelievo} Euro");
            }
            else
            {
                Console.WriteLine("Prelievo disabilitato per scarsità di fondi sul conto");
            }

            StampaConto();
        }

        public override void StampaConto()
        {
            Console.WriteLine($"Conto Risparmio intestato a: {intestatario.Nome} {intestatario.Cognome} | Totale sul conto: {this.totaleConto} Euro");
        }

        public override void Deposita()
        {
            Console.WriteLine("Quanto vuoi depositare?");
            int deposito = Int32.Parse(Console.ReadLine());

            if(deposito < 5000 && deposito > 0)
            {
                this.totaleConto += deposito;
                Console.WriteLine($"Deposito effettuato! Hai depositato {deposito} Euro");
                StampaConto();
            }
            else
            {
                Console.WriteLine("Puoi depositare al massimo 5000 Euro per questo tipo di conto!");
                Deposita();
            }
            
        }
    }
}
