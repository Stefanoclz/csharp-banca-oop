namespace csharp_banca_oop
{
    internal class Banca
    {
        public string nome = "";

        public List<Cliente> clienti;

        public List<Prestito> prestiti;

        public List<ContoClassico> contiClassici;

        public List<ContoRisparmio> contiRisparmio;

        public Banca(string nome)
        {
            this.nome = nome;

            clienti = new List<Cliente>();
            prestiti = new List<Prestito>();
            contiClassici = new List<ContoClassico>();
            contiRisparmio = new List<ContoRisparmio>();
            


            Cliente user1 = new Cliente("Lorenzo", "Ariatta", "LRNRTT89L08C881X", 1900);
            Cliente user2 = new Cliente("Andrea", "Celiberti", "NDRCBR87F12C773U", 1450);
            Cliente user3 = new Cliente("Giovanni", "Brocco", "GVNBRC89L02F554Z", 1500);


            clienti.Add(user1);
            clienti.Add(user2);
            clienti.Add(user3);

            Prestito prest1 = new Prestito(user1, 50000, 710, DateOnly.Parse("19/01/2022"), DateOnly.Parse("02/08/2047"), "215L3LL0066");
            Prestito prest2 = new Prestito(user2, 250000, 980, DateOnly.Parse("05/05/2005"), DateOnly.Parse("31/12/2036"), "LI1DEDED325");
            Prestito prest3 = new Prestito(user3, 250000, 980, DateOnly.Parse("05/05/2005"), DateOnly.Parse("31/12/2036"), "LI1DEDED325");
            Prestito prest4 = new Prestito(user1, 30000, 480, DateOnly.Parse("03/07/2003"), DateOnly.Parse("14/03/2018"), "8548854L3EL10");


            prestiti.Add(prest1);
            prestiti.Add(prest2);
            prestiti.Add(prest3);
            prestiti.Add(prest4);

            ContoClassico conto1 = new ContoClassico(user1, 143000);
            ContoClassico conto2 = new ContoClassico(user2, 32000);
            ContoClassico conto3 = new ContoClassico(user3, 54000);

            contiClassici.Add(conto1);
            contiClassici.Add(conto2);
            contiClassici.Add(conto3);

            ContoRisparmio contoR1 = new ContoRisparmio(user1, 205000);
            ContoRisparmio contoR2 = new ContoRisparmio(user3, 98000);

            contiRisparmio.Add(contoR1);
            contiRisparmio.Add(contoR2);

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

        public Prestito CreaPrestito()
        {
            Console.WriteLine("A quale cliente aggiungere il prestito?");
            int scelta = ListaClienti();

            Cliente user = clienti[scelta - 1];

            Console.WriteLine("Inserisci ammontare");
            int ammontare = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci importo rata");
            int rata = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci data di inizio");
            DateOnly dataInizio = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci data di fine");
            DateOnly dataFine = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci id prestito");
            string id = Console.ReadLine();

            Prestito nuovo = new Prestito(user, ammontare, rata, dataInizio, dataFine, id);

            return nuovo;
        }

        public int ListaClienti()
        {
            Console.WriteLine("Scegli utente:");
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

        internal int ListaPrestiti()
        {
            int pos = 1;
            foreach (Prestito prestito in prestiti)
            {
                Console.Write(pos + "\t");
                prestito.Stampa();
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

        public Cliente RicercaCliente()
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
                    Cliente trovato = cliente;
                    return trovato;
                }else
                {
                    assente = true;
                }
            }
            if (assente == true)
            {
                Console.WriteLine("Spiacenti, cliente non presente nei registri");
            }

            return null;
        }

        public void RicercaPrestito()
        {
            Console.WriteLine("Inserisci il CF dell'intestatario del prestito");
            string param = Console.ReadLine();

            int totale = 0;
            double totaleTassato = 0;
            bool NonTrovato = false;
            foreach (Prestito prestito in prestiti)
            {
                Cliente check = prestito.GetIntestatario();
                if(check.CodiceFiscale == param)
                {
                    prestito.Stampa();
                    int ammontare = prestito.GetAmmontare();
                    TassoFisso tasso = new TassoFisso();
                    totale += ammontare;
                    totaleTassato += tasso.AddInteresse(ammontare);
                }
                else
                {
                    NonTrovato = true;
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Somma totale prestiti:" + totale);
            Console.WriteLine("Somma totale prestiti tassati:" + totaleTassato);

            if (NonTrovato == true)
            {
                Console.WriteLine("Non esistono prestiti legati all'utente con il CF inserito");
            }
        }

        public ContoClassico RicercaContoClassico(Cliente intestatario)
        {
            foreach(ContoClassico contoC in this.contiClassici)
            {
                if(contoC.intestatario == intestatario)
                {
                    Console.WriteLine();
                    contoC.StampaConto();
                    return contoC;
                    Console.WriteLine();
                }
            }

            return null;
        }

        public ContoRisparmio RicercaContoRisparmio(Cliente intestatario)
        {
            foreach (ContoRisparmio contoR in this.contiRisparmio)
            {
                if (contoR.intestatario == intestatario)
                {
                    Console.WriteLine();
                    contoR.StampaConto();
                    return contoR;
                    Console.WriteLine();
                }
            }

            return null;
        }
    }
}
