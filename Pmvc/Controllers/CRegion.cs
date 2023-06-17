using Pmvc.Models;
using Pmvc.Views;

namespace Pmvc.Controllers;

public class CRegion
{
    private MRegion _region = new MRegion();
    private VRegion _regionView = new VRegion();

    public void MenuGetById()
    {
        Console.WriteLine("     GetRegionByID      ");
        Console.WriteLine("------------------------");
        Console.Write("Select region By ID : ");
        int id = int.Parse(Console.ReadLine());

        var region = _region.GetByID(id);

        if (region == null)
        {
            _regionView.NotFound();
        }
        else
        {
            _regionView.GetById(region);
        }

        Console.ReadKey();
    }
    // Menu Insert Region
    public void InsertMenu()
    {
        Console.WriteLine("      Insert      ");
        Console.WriteLine("----------------- ");
        Console.Write("Add new name region : ");
        string name = Console.ReadLine();
        int isInsertSuccessful = _region.Insert(name);
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
    // Menu Update Region 
    public void UpdateMenu()
    {
        Console.WriteLine("     Update Region       ");
        Console.WriteLine("-------------------------");
        Console.Write("Input ID of the region to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Input the new name for the region: ");
        string newName = Console.ReadLine();

        int updateResult = _region.Update(id, newName);
        if (updateResult > 0)
        {
            Console.WriteLine("Data updated successfully");
        }
        else
        {
            Console.WriteLine("Failed to update data");
        }

        Console.ReadKey();
    }
    //Menu Delete Region
    public void DeleteMenu()
    {
        Console.WriteLine("           Delete Region          ");
        Console.WriteLine("----------------------------------");
        Console.Write("Input the ID of the region to delete: ");
        int id = int.Parse(Console.ReadLine());

        int deleteResult = _region.Delete(id);
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
    // Menu All Region
    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       GetAll Region      ");
            Console.WriteLine("--------------------------");

            var regions = _region.GetAll();
            _regionView.GetAll(regions);

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
