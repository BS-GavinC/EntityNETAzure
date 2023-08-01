// See https://aka.ms/new-console-template for more information
using EntityNetAzureCorrection1.Context;
using EntityNetAzureCorrection1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

//Dans program.cs

//ecrire un programme qui permet
//- D'enregistrer un nouveau user (entrez l'email, pwd et pseudo facultatif)
//- De lister les users V
//- De Modifier le pseudo d'un user existant
ShowMenu();

void ShowMenu()
{
    int selection;

    bool BadValue = false;

    do
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("1. Lister les utilisateurs.");
        Console.WriteLine("2. Creer nouvel utilisateur.");
        Console.WriteLine("3. Modifier un pseudo.");
        Console.WriteLine("0. Quitter.");
        Console.WriteLine("---------------------------");
        if (BadValue)
        {
            Console.WriteLine("Valeur incorrect, reessayez.");
        }
        selection = CustomIntReadLine("Veuillez faire votre selection :");

        BadValue = false;
        

        switch (selection)
        {
            case 1:
                ListerUser();
                break;
            case 2:
                RegisterUser();
                break;
            case 3:
                UpdatePseudo();
                break;
            case 0:
                Console.WriteLine("Merci d'etre venu ! A la prochaine !");
                break;
            default:
                Console.Clear();
                BadValue = true;
                break;
        }

    } while(selection != 0);
}

void ListerUser()
{
    using(DatabaseContext dbContext = new DatabaseContext())
    {
        List<User> users = dbContext.Users.ToList();
        Console.WriteLine("---------------------------");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine("---------------------------");
    }
    Console.WriteLine("Appuyez sur une touche pour continuer.");
    Console.ReadKey();
    Console.Clear();
}

void RegisterUser()
{
    User user = new User();
    Console.WriteLine("---------------------------");
    user.Email = CustomStringReadLine("Entrez un Email : ", 5);
    user.Password = CustomStringReadLine("Entrez un Password : ", 8);
    user.Pseudo = CustomStringReadLine("Entrez un pseudo : ");

    using(DatabaseContext db = new DatabaseContext())
    {
        db.Users.Add(user);
        db.SaveChanges();
        Console.WriteLine("Valeur bien ajoutée.");
        Console.WriteLine("---------------------------");
    }
    Console.WriteLine("Appuyez sur une touche pour continuer.");
    Console.ReadKey();
    Console.Clear();
}

void UpdatePseudo()
{
    ListerUser();
    Console.WriteLine("---------------------------");
    int selection = CustomIntReadLine("Selectionnez l'id du user à modifier :");

    using(DatabaseContext db = new DatabaseContext())
    {
        User? user;

        do
        {
            user = db.Users.Find(selection);

            if (user == null)
            {
                selection = CustomIntReadLine("L'id ne correspond à aucun user, veuillez reessayer :");
            }

        } while (user == null);

        user.Pseudo = CustomStringReadLine("Entrez le nouveau pseudo :");

        db.SaveChanges();
        Console.WriteLine("Value bien modifié.");

        Console.WriteLine("---------------------------");
    }
    Console.WriteLine("Appuyez sur une touche pour continuer.");
    Console.ReadKey();
    Console.Clear();
}

string CustomStringReadLine(string message, int minLenght = 0)
{
    string subMessage = minLenght > 0 ? "(Longueur minimum : " + minLenght +" )" : "" ;
    Console.WriteLine($"{message} {subMessage}");
    string value;

    do
    {
        value = Console.ReadLine();
        if (value.Length < minLenght)
        {
            Console.WriteLine("Valeur incorrect, reessayez");
        }
    }
    while (value.Length < minLenght);

    return value;
}

int CustomIntReadLine(string message)
{
    Console.WriteLine(message);

    int value;

    string stringValue;

    bool Result;

    do
    {
        stringValue = Console.ReadLine();

        Result = int.TryParse(stringValue, out value);

        if (!Result)
        {
            Console.WriteLine("Valeur incorrect, reessayez");
        }
    }
    while (!Result);

    return value;
}
