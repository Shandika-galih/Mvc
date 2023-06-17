using Pmvc.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Models;

public class MEmployee
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public DateTime hireDate { get; set; }
    public int salary { get; set; }
    public decimal comission { get; set; }
    public int managerId { get; set; }
    public string jobId { get; set; }
    public int departmentId { get; set; }

    public List<MEmployee> GetAll()
    {

        {
            SqlConnection connection = Connection.Get();
            connection.Open();
            var employee = new List<MEmployee>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new MEmployee();
                        emp.id = reader.GetInt32(0);
                        emp.firstName = reader.GetString(1);
                        emp.lastName = reader.GetString(2);
                        emp.email = reader.GetString(3);
                        emp.phoneNumber = reader.GetString(4);
                        emp.hireDate = reader.GetDateTime(5);
                        emp.salary = reader.GetInt32(6);
                        emp.comission = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7);
                        emp.managerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emp.jobId = reader.GetString(9);
                        emp.departmentId = reader.GetInt32(10);

                        employee.Add(emp);

                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return employee;
        }
    }
}
