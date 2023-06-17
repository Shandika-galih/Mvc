using Pmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Views;

public class VJob
{
    public void GetAll(List<MJob> jobs)
    {
        foreach (MJob job in jobs)
        {
            {
                Console.WriteLine("");
                Console.WriteLine("ID : " + job.id + ", Title : " + job.title + ", Min Salary : " + job.minSalary + ",  Max Salary : " + job.maxSalary);
            }
        }
            
    }
}
