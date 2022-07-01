using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Menu
    {
        public static int Welcome(string nomeBanca)
        {
            string bankName = nomeBanca;
            Console.WriteLine("********************************************************");
            Console.WriteLine($"Benvenuto nell'interfaccia della {bankName} banca");
            Console.WriteLine("********************************************************");

            Console.WriteLine();

            Console.WriteLine("Menù:");
            Console.WriteLine("1. sezione utenti");
            Console.WriteLine("2. sezione prestiti");

            int selettore1 = Int32.Parse(Console.ReadLine());

            return selettore1;
        }

        internal static int MenuPrestiti()
        {
            Console.WriteLine("Menu Prestiti:");
            Console.WriteLine("1. Aggiungi prestito");
            Console.WriteLine("2. Ricerca prestito tramite CF");
            Console.WriteLine("4. Indietro");

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
