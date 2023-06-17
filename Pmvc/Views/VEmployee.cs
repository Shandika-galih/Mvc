using Pmvc.Controllers;
using Pmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Views
{
    public class VEmployee
    {
        public void GetAll(List<MEmployee> employees)
        {
            foreach (MEmployee emp in employees)
            {
                Console.WriteLine("ID : " + emp.id + ", First Name : " + emp.firstName + ", Last Name : " + emp.lastName + ", Email : " + emp.email + ", Phone Number : " + emp.phoneNumber + ", Hire Date ID : " + emp.hireDate + ", Salary :  " + emp.salary + ", Comission : " + emp.comission + ", Manager ID : " + emp.managerId + "Job ID : " + emp.jobId + ", Department ID : " + emp.departmentId);

            }
        }
    }
}
