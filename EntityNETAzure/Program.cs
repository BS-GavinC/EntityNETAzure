// See https://aka.ms/new-console-template for more information
using EntityNETAzure;
using EntityNETAzure.Context;
using EntityNETAzure.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using(DatabaseContext db = new DatabaseContext())
{
    Voiture voit = db.Voitures.Include(x => x.Drivers).First();

    //voit.Drivers = List<Person>(douglas, dougounou)

    Console.WriteLine(voit.Drivers[0].Cars[0].Model);

    db.SaveChanges();
}


Console.ReadLine();

//Voiture voiture = db.Voitures.Include(x => x.CarBrand).First();

//if (voiture != null)
//{
//    Console.WriteLine("Voiture existe");

//    if (voiture.CarBrand != null)
//    {
//        Console.WriteLine("Brand existe");
//        Console.WriteLine(voiture.CarBrand.Name);
//    }
//    else
//    {
//        Console.WriteLine("Brand existe pas");
//    }
//}
//else
//{
//    Console.WriteLine("Voiture existe pas");
//}