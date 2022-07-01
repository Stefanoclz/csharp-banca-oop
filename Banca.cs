using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Banca
    {
        public string nome = "";

        public List<Cliente> clienti;

        public List<Prestito> prestiti;

        public Banca(string nome)
        {
            this.nome = nome;
            
            clienti = new List<Cliente>();
            prestiti = new List<Prestito>();
        }

        public void NuovoCliente(Cliente cliente)
        {
            clienti.Add(cliente);
        }

        public void NuovoPrestito(Prestito prestito)
        {
            prestiti.Add(prestito);
        }

        public static Cliente CreaCliente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();

            Console.WriteLine("Inserisci codice fiscale");
            string cf = Console.ReadLine();

            Console.WriteLine("Inserisci stipendio");
            int stipendio = Int32.Parse(Console.ReadLine());

            Cliente nuovo = new Cliente(nome, cognome, cf, stipendio);

            return nuovo;
        }

        public static Prestito CreaPrestito()
        {
            Console.WriteLine("Inserisci intestatario");
            Cliente user = Banca.CreaCliente();

            Console.WriteLine("Inserisci ammontare");
            int ammontare = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci importo rata");
            int rata = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci data di inizio");
            string dataInizio = Console.ReadLine();

            Console.WriteLine("Inserisci data di fine");
            string dataFine = Console.ReadLine();

            Console.WriteLine("Inserisci id prestito");
            string id = Console.ReadLine();

            Prestito nuovo = new Prestito(user, ammontare, rata, dataInizio, dataFine, id);

            return nuovo;
        }

        internal void ListaClienti()
        {
            foreach (Cliente cliente in clienti)
            {
                cliente.Stampa();
            }
        }
    }
}
