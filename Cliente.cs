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

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public int Stipendio { get; set; }

        internal void Stampa()
        {
            Console.WriteLine($"nome: {this.Nome} | cognome: {this.Cognome} | codice fiscale: {this.CodiceFiscale} | stipendio: {this.Stipendio}");
        }
    }
}
