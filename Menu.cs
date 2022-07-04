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
                Console.Clear();

                int userMenu = Menu.MenuUtente();

                if (userMenu == 1)
                {
                    Cliente nuovoCliente = Banca.CreaCliente();

                    bank.NuovoCliente(nuovoCliente);
                    Console.WriteLine("Cliente aggiunto!");
                    bank.ListaClienti();
                    Console.WriteLine("1. Torna a Menu Utente");
                    Console.WriteLine("2. Torna a Home");
                    int exit = Int32.Parse(Console.ReadLine());
                    if (exit == 1)
                    {
                        MenuUtente();
                    } else if(exit == 2)
                    {
                        Welcome(bank.nome);
                    }
                }
                else if (userMenu == 2)
                {
                    int modifier = bank.ListaClienti();
                    bank.NuovoCliente(bank.ModificaCliente(modifier));
                    bank.ListaClienti();
                    Console.WriteLine("1. Torna a Menu Utente");
                    Console.WriteLine("2. Torna a Home");
                    int exit = Int32.Parse(Console.ReadLine());
                    if (exit == 1)
                    {
                        MenuUtente();
                    }
                    else if (exit == 2)
                    {
                        Welcome(bank.nome);
                    }
                }
                else if (userMenu == 3)
                {
                    Cliente find = bank.RicercaCliente();
                    if (find == null)
                    {
                        userMenu = MenuUtente();
                    }
                    foreach (ContoClassico contoC in bank.contiClassici)
                    {
                        if(contoC.intestatario == find)
                        {
                            //Console.WriteLine($"Trovato Conto Classico intestato al cliente {find.Nome} {find.Cognome}");
                            contoC.StampaConto();
                        }            
                    }

                    foreach(ContoRisparmio contoR in bank.contiRisparmio)
                    {
                        if(contoR.intestatario == find)
                        {
                            //Console.WriteLine($"Trovato Conto Risparmio intestato al cliente {find.Nome} {find.Cognome}");
                            contoR.StampaConto();
                        }
                    }

                    int contopoint = MenuConto();
                    if(contopoint == 1)
                    {
                        Console.WriteLine("Che conto vuoi aggiungere?");
                        Console.WriteLine("1. Conto Classico");
                        Console.WriteLine("2. Conto Risparmio");
                        int type = Int32.Parse(Console.ReadLine());
                        if(type == 1)
                        {

                            ContoClassico nuovo = new ContoClassico(find, 0);
                            Console.WriteLine("Conto Classico creato!");
                            Console.WriteLine("Saldo attuale: 0 Euro");
                            Console.WriteLine("Vuoi aggiungere credito?");
                            Console.WriteLine("Digita \"SI\" per aggiungere credito al conto");
                            string add = Console.ReadLine();
                            if(add == "SI")
                            {
                                nuovo.Deposita();
                            }
                            else
                            {
                                contopoint = MenuConto();
                            }

                            nuovo.StampaConto();
                        }
                        else if(type == 2)
                        {
                            ContoRisparmio nuovo = new ContoRisparmio(find, 0);
                            Console.WriteLine("Conto Risparmio creato!");
                            Console.WriteLine("Saldo attuale: 0 Euro");
                            Console.WriteLine("Vuoi aggiungere credito?");
                            Console.WriteLine("Digita \"SI\" per aggiungere credito al conto");
                            string add = Console.ReadLine();
                            if (add == "SI")
                            {
                                nuovo.Deposita();
                            }
                            else
                            {
                                contopoint = MenuConto();
                            }

                            nuovo.StampaConto();
                        } else
                        {
                            Console.WriteLine("Selezione errata!");
                            contopoint = MenuConto();
                        }

                    }else if(contopoint == 2)
                    {
                        ContoClassico findContoC = bank.RicercaContoClassico(find);
                        ContoRisparmio findContoR = bank.RicercaContoRisparmio(find);

                        if(findContoC != null && findContoR != null)
                        {
                            Console.WriteLine("Sono stati trovati 2 diversi tipi di conto, da quale vuoi prelevare?");
                            findContoC.StampaConto();
                            findContoR.StampaConto();
                            Console.WriteLine("1. Conto Classico");
                            Console.WriteLine("2. Conto Risparmio");
                            int sceltaConto = Int32.Parse(Console.ReadLine());

                            if(sceltaConto == 1)
                            {
                                findContoC.Preleva();
                            }
                            else if(sceltaConto == 2)
                            {
                                findContoR.Preleva();
                            }else
                            {
                                Console.WriteLine("Scelta errata!");
                                contopoint = MenuConto();
                            }
                        }
                        else if(findContoC != null && findContoR == null)
                        {
                            findContoC.Preleva();
                        }
                        else if(findContoC == null && findContoR != null)
                        {
                            findContoR.Preleva();
                        } else
                        {
                            Console.WriteLine("Non sono stati trovati conti intestati al cliente");
                        }
                    }
                    else if(contopoint == 3)
                    {
                        ContoClassico findContoC = bank.RicercaContoClassico(find);
                        ContoRisparmio findContoR = bank.RicercaContoRisparmio(find);

                        if (findContoC != null && findContoR != null)
                        {
                            Console.WriteLine("Sono stati trovati 2 diversi tipi di conto, in quale vuoi depositare?");
                            findContoC.StampaConto();
                            findContoR.StampaConto();
                            Console.WriteLine("1. Conto Classico");
                            Console.WriteLine("2. Conto Risparmio");
                            int sceltaConto = Int32.Parse(Console.ReadLine());

                            if (sceltaConto == 1)
                            {
                                findContoC.Deposita();
                            }
                            else if (sceltaConto == 2)
                            {
                                findContoR.Deposita();
                            }
                            else
                            {
                                Console.WriteLine("Scelta errata!");
                                contopoint = MenuConto();
                            }
                        }
                        else if (findContoC != null && findContoR == null)
                        {
                            findContoC.Deposita();
                        }
                        else if (findContoC == null && findContoR != null)
                        {
                            findContoR.Deposita();
                        }
                        else
                        {
                            Console.WriteLine("Non sono stati trovati conti intestati al cliente");
                        }
                    }
                    else if(contopoint == 4)
                    {
                        contopoint = MenuConto();
                    }
                    else
                    {
                        Console.WriteLine("Selezione errata!");
                        contopoint = MenuConto();
                    }
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
                Console.Clear();

                int userLending = Menu.MenuPrestiti();

                if (userLending == 1)
                {
                    Prestito nuovoPrestito = bank.CreaPrestito();
                    bank.NuovoPrestito(nuovoPrestito);
                    Console.WriteLine("Presito aggiunto");
                    bank.ListaPrestiti();
                    Console.WriteLine("1. Torna a Menu Prestiti");
                    Console.WriteLine("2. Torna a Home");
                    int exit = Int32.Parse(Console.ReadLine());
                    if (exit == 1)
                    {
                        MenuPrestiti();
                    }
                    else if (exit == 2)
                    {
                        Welcome(bank.nome);
                    }
                }
                else if (userLending == 2)
                {
                    bank.RicercaPrestito();
                    int exit = Int32.Parse(Console.ReadLine());
                    if (exit == 1)
                    {
                        MenuPrestiti();
                    }
                    else if (exit == 2)
                    {
                        Welcome(bank.nome);
                    }
                }
                else if (userLending == 3)
                {
                    Welcome(bank.nome);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Selezione errata, prego riprovare");
                Welcome(bank.nome);
            }
        }

        internal static int MenuPrestiti()
        {
            Console.Clear();
            Console.WriteLine("Menu Prestiti:");
            Console.WriteLine("1. Aggiungi prestito");
            Console.WriteLine("2. Ricerca prestito tramite CF");
            Console.WriteLine("3. Indietro");

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

        public static int MenuUtente()
        {
            Console.Clear();
            Console.WriteLine("Menu Utente:");
            Console.WriteLine("1. Aggiungi nuovo utente");
            Console.WriteLine("2. Modifica utente");
            Console.WriteLine("3. Ricerca utente");
            Console.WriteLine("4. Indietro");

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

        public static int MenuConto()
        {
            Console.WriteLine("Menu Conto:");
            Console.WriteLine("1. Aggiungi Conto");
            Console.WriteLine("2. Preleva dal conto");
            Console.WriteLine("3. Deposita sul conto");
            Console.WriteLine("4. Indietro");

            int selettore = Int32.Parse(Console.ReadLine());
            return selettore;
        }

    }
}
