using Pmvc.Controllers;
using Pmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Views;

public class VDepartment
{
    public void GetAll(List<MDepartment> departmens)
    {
        foreach (MDepartment department in departmens) 
        {
            Console.WriteLine("Id : " + department.id + ", Department Name : " + department.name + ", Location ID : " + department.locationId + ", Manager ID : " + department.managerId);
        }

    }
}
