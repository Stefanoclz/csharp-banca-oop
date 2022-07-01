using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Cliente
    {
        public Cliente(string nome, string cognome, string cf, int stipendio)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = cf;
            Stipendio = stipendio;

        }

        string Nome { get; set; }
        string Cognome { get; set; }
        string CodiceFiscale { get; set; }
        int Stipendio { get; set; }

        internal void Stampa()
        {
            Console.WriteLine($"nome: {this.Nome} | cognome: {this.Cognome} | codice fiscale: {this.CodiceFiscale} | stipendio: {this.Stipendio}");
        }
    }
}
