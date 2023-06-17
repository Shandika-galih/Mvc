using Pmvc.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Models;

public class MDepartment
{
    public int id { get; set; }
    public string name { get; set; }
    public int locationId { get; set; }
    public int managerId { get; set; }

    public List<MDepartment> GetAll()
    {
        SqlConnection connection = Connection.Get();
        connection.Open();
        var department = new List<MDepartment>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_departements";

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dep = new MDepartment();
                    dep.id = reader.GetInt32(0);
                    dep.name = reader.GetString(1);
                    dep.locationId = reader.GetInt32(2);
                    dep.managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                    department.Add(dep);// Menambahkan objek Department ke dalam list

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
        return department;
    }
}
