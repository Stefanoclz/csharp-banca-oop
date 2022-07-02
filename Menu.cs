using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Menu
    {

        
        public void Welcome(string nomeBanca)
        {
            Banca bank = new Banca(nomeBanca);

           // string bankName = nomeBanca;
            Console.WriteLine("********************************************************");
            Console.WriteLine($"Benvenuto nell'interfaccia della {nomeBanca} banca");
            Console.WriteLine("********************************************************");

            Console.WriteLine();

            Console.WriteLine("Menù:");
            Console.WriteLine("1. sezione utenti");
            Console.WriteLine("2. sezione prestiti");

            int selettore1 = Int32.Parse(Console.ReadLine());

            if (selettore1 == 1)
            {
                int userMenu = Menu.MenuUtente();

                if (userMenu == 1)
                {
                    Cliente nuovoCliente = Banca.CreaCliente();

                    bank.NuovoCliente(nuovoCliente);
                    Console.WriteLine("Cliente aggiunto!");
                    bank.ListaClienti();
                }
                else if (userMenu == 2)
                {
                    int modifier = bank.ListaClienti();
                    bank.NuovoCliente(bank.ModificaCliente(modifier));
                    bank.ListaClienti();
                }
                else if (userMenu == 3)
                {
                    bank.RicercaCliente();
                }
                else if (userMenu == 4)
                {
                    Welcome(bank.nome);
                }
                else
                {
                    Console.WriteLine("Menu inesistente");
                    userMenu = Menu.MenuUtente();
                }
            }
            else if (selettore1 == 2)
            {
                int userLending = Menu.MenuPrestiti();

                if (userLending == 1)
                {
                    Prestito nuovoPrestito = bank.CreaPrestito();
                    bank.NuovoPrestito(nuovoPrestito);
                    Console.WriteLine("Presito aggiunto");
                    bank.ListaPrestiti();
                }
                else if (userLending == 2)
                {
                    bank.RicercaPrestito();
                }
                else if (userLending == 3)
                {
                    Welcome(bank.nome);
                }
            }
        }

        internal static int MenuPrestiti()
        {
            Console.WriteLine("Menu Prestiti:");
            Console.WriteLine("1. Aggiungi prestito");
            Console.WriteLine("2. Ricerca prestito tramite CF");
            Console.WriteLine("3. Indietro");

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

        public static int MenuUtente()
        {
            Console.WriteLine("Menu Utente:");
            Console.WriteLine("1. Aggiungi nuovo utente");
            Console.WriteLine("2. Modifica utente");
            Console.WriteLine("3. Ricerca utente");
            Console.WriteLine("4. Indietro");

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

    }
}
