
using Pmvc.Models;
using Pmvc.Views;

namespace Pmvc.Controllers;

public class CJob
{
    private MJob _job = new MJob();
    private VJob _jobView = new VJob();
    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       GetAll Country      ");
            Console.WriteLine("--------------------------");

            var job = _job.GetAll();
            _jobView.GetAll(job);

            Console.WriteLine("\n");
            Console.WriteLine("     Menu     ");
            Console.WriteLine("--------------");
            /*  Console.WriteLine("1. GetById");
              Console.WriteLine("2. Insert");
              Console.WriteLine("3. Update");
              Console.WriteLine("4. Delete");*/
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
                /*     case 1:
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
                         break;*/
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
