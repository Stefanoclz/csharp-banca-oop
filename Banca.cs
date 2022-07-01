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

            clienti.Add(new Cliente("Lorenzo", "Ariatta", "LRNRTT89L08C881X", 1900));
            clienti.Add(new Cliente("Andrea", "Celiberti", "NDRCBR87F12C773U", 1450));
            clienti.Add(new Cliente("Giovanni", "Brocco", "GVNBRC89L02F554Z", 1500));
        }

        internal void NuovoCliente(Cliente cliente)
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

        internal int ListaClienti()
        {
            Console.WriteLine("Scegli utente da modificare:");
            int pos = 1;
            foreach (Cliente cliente in clienti)
            {
                Console.Write(pos + "\t");
                cliente.Stampa();
                pos++;
            }

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

        public Cliente ModificaCliente(int param)
        {
            param--;
            if(param <= clienti.Count() && param > 0)
            {
                clienti.RemoveAt(param);
                Cliente modificato = Banca.CreaCliente();
                return modificato;
            }
            else
            {
                Console.WriteLine("Selezione errata");
                return null;
            }
        }

        public void RicercaCliente()
        {
            Console.WriteLine("Inserisci il nome, il cognome o il codice fiscale del cliente da cercare");
            string cerca = Console.ReadLine();

            bool assente = false;

            foreach (Cliente cliente in clienti)
            {
                
                if(cerca == cliente.Nome || cerca == cliente.Cognome || cerca == cliente.CodiceFiscale)
                {
                    Console.WriteLine("Utente trovato:");
                    cliente.Stampa();
                    break;
                }else
                {
                    assente = true;
                }
            }
            if (assente == true)
            {
                Console.WriteLine("Spiaze, cliente non presente nei registri");
            }
        }
    }
}
