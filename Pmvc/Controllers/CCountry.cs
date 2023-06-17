using Pmvc.Models;
using Pmvc.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Controllers;

public class CCountry
{
    private MCountry _country = new MCountry();
    private VCountry _countryView = new VCountry();

    public void MenuGetById()
    {
        Console.WriteLine("     GetCountryByID      ");
        Console.WriteLine("------------------------");
        Console.Write("Select country By ID : ");
        string id = Console.ReadLine();

        var crnty = _country.GetByID(id);

        if (crnty == null)
        {
            _countryView.NotFound();
        }
        else
        {
            _countryView.GetById(crnty);
        }

        Console.ReadKey();
    }
    public void InsertMenu()
    {
        Console.WriteLine("      Insert      ");
        Console.WriteLine("----------------- ");
        Console.Write("Add new ID Country : ");
        string Id = Console.ReadLine();
        Console.Write("Add new name Country : ");
        string name = Console.ReadLine();
        Console.Write("Add new ID Country : ");
        int regionId = int.Parse(Console.ReadLine());

        int isInsertSuccessful = _country.Insert(Id, name, regionId);
        if (isInsertSuccessful > 0)
        {
            Console.WriteLine("Data added successfully");
        }
        else
        {
            Console.WriteLine("Data failed to add");
        }

        Console.ReadKey();
    }
    public void UpdateMenu()
    {
        Console.WriteLine("     Update Country      ");
        Console.WriteLine("-------------------------");

        Console.Write("Input the ID of the country to update: ");
        string newId = Console.ReadLine();
        Console.Write("Input the new name for the country: ");
        string newName = Console.ReadLine();
        Console.Write("Enter the region ID : ");
        int regionId = Convert.ToInt32(Console.ReadLine());

        int updateResult = _country.Update(newId, newName, regionId);
        if (updateResult > 0)
        {
            Console.WriteLine("Data updated successfully");
        }
        else
        {
            Console.WriteLine("Failed to update data");
        }
        Console.WriteLine("Press enter to return to the Main Menu");
        Console.ReadKey();
    }
    public void DeleteMenu()
    {
        Console.WriteLine("           Delete Region          ");
        Console.WriteLine("----------------------------------");
        Console.Write("Input the ID of the region to delete: ");
        string id = Console.ReadLine();

        int deleteResult = _country.Delete(id);
        if (deleteResult > 0)
        {
            Console.WriteLine("Data deleted successfully");
        }
        else
        {
            Console.WriteLine("Failed to delete data");
        }

        Console.ReadKey();
    }

    // Menu All Country
    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       GetAll Country      ");
            Console.WriteLine("--------------------------");

            var country = _country.GetAll();
            _countryView.GetAll(country);

            Console.WriteLine("\n");
            Console.WriteLine("     Menu     ");
            Console.WriteLine("--------------");
            Console.WriteLine("1. GetById");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");

            Console.Write("Select Menu : ");
            int InputPilihan;
            if (!int.TryParse(Console.ReadLine(), out InputPilihan))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            switch (InputPilihan)
            {
                case 1:
                    MenuGetById();
                    break;
                case 2:
                    InsertMenu();
                    break;
                case 3:
                    UpdateMenu();
                    break;
                case 4:
                    DeleteMenu();
                    break;
                case 5:
                    Console.Clear();
                    new CMenu().MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
