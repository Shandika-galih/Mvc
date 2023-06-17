using Pmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Views;

public class VHistorie
{
    public void GetAll(List<MHistorie> histories)
    {
        foreach (MHistorie history in histories) 
        {
            Console.WriteLine("Employee_ID : " + history.employeeId + ", Start_Date : " + history.startDate + ", End_Date : " + history.endDate + ",  Department ID : " + history.departmentId + ", Job_ID : " + history.jobId);
        }
    }
}
