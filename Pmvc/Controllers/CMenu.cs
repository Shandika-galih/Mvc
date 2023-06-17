using Pmvc.Contexts;
using Pmvc.Models;
using System.Data.SqlClient;
namespace Pmvc.Controllers;

public class CMenu
{
    public void MainMenu()
    {
        Console.WriteLine("-----Main Menu-----");
        Console.WriteLine("                   ");
        Console.WriteLine("1. Countries");
        Console.WriteLine("2. Regions");
        Console.WriteLine("3. Locations");
        Console.WriteLine("4. Jobs");
        Console.WriteLine("5. Departments");
        Console.WriteLine("6. Employees");
        Console.WriteLine("7. Histories");
        Console.WriteLine("8. LINQ");
        Console.WriteLine("9. Exit");
        try
        {
            Console.Write(" Masukan Pilihan : ");
            int inputPilihan = Convert.ToInt32(Console.ReadLine());

            switch( inputPilihan)
            {
                case 1:
                    new CCountry().Menu();
                    break;
                case 2:
                    new CRegion().Menu();
                    break;
                case 3:
                    new CLocation().Menu();
                    break;
                case 4:
                    new CJob().Menu();
                    break;
                case 5:
                    new CDepartment().Menu();
                    break;
                case 6: 
                    new CEmployee().Menu();
                    break;
                case 7:
                    new CHistorie().Menu();
                    break;
                case 8:
                    break;
                case 9:
                    System.Environment.Exit(0);
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.Clear();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


