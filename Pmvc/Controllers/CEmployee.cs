using Pmvc.Models;
using Pmvc.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Controllers;

public class CEmployee
{
    private MEmployee _employees = new MEmployee();
    private VEmployee _employeesView = new VEmployee();
    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       GetAll Departmens      ");
            Console.WriteLine("--------------------------");

            var employees = _employees.GetAll();
            _employeesView.GetAll(employees);

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

