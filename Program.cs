﻿// See https://aka.ms/new-console-template for more information

using csharp_banca_oop;

Banca bank = new Banca("Lupin");

int entry = Menu.Welcome(bank.nome);

if(entry == 1)
{
    int userMenu = Menu.MenuUtente();

    if(userMenu == 1)
    {
        Cliente nuovoCliente = Banca.CreaCliente();

        bank.NuovoCliente(nuovoCliente);
        Console.WriteLine("Cliente aggiunto!");
        bank.ListaClienti();
    }
    else if(userMenu == 2)
    {
        int modifier = bank.ListaClienti();
        bank.NuovoCliente(bank.ModificaCliente(modifier));
        bank.ListaClienti();
    }
    else if(userMenu == 3)
    {
        bank.RicercaCliente();
    }
    else if(userMenu == 4)
    {
        entry = Menu.Welcome(bank.nome);
    }
    else
    {
        Console.WriteLine("Menu inesistente");
        userMenu = Menu.MenuUtente();
    }
}
else if(entry == 2)
{
    int userLending = Menu.MenuPrestiti();
}

