using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Prestito
    {
        Cliente intestatario;

        int Ammontare { get; set; }
        int Rata { get; set; }
        string DataInizio { get; set; }
        string DataFine { get; set; }
        string Id { get; set; }

        public Prestito(Cliente intestatario, int ammontare, int rata, string dataInizio, string dataFine, string id)
        {
            this.intestatario = intestatario;
            Ammontare = ammontare;
            Rata = rata;
            DataInizio = dataInizio;
            DataFine = dataFine;
            Id = id;
        }

        internal void Stampa()
        {
            Console.WriteLine($"Intestatario: {this.intestatario} | ammontare: {this.Ammontare} | Rata: {this.Rata} | data inizio: {this.DataInizio} | data fine: {this.DataFine} | id: {this.Id}");
        }
    }
}
