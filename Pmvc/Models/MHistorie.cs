using Pmvc.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Models;

public class MHistorie
{
    public DateTime startDate { get; set; }
    public int employeeId { get; set; }
    public DateTime endDate { get; set; }
    public int departmentId { get; set; }
    public string jobId { get; set; }

    public List<MHistorie> GetAll()
    {
        {
            SqlConnection connection = Connection.Get();
            connection.Open();
            var history = new List<MHistorie>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_tr_histories";

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var h = new MHistorie();
                        h.startDate = reader.GetDateTime(0);
                        h.employeeId = reader.GetInt32(1);
                        h.endDate = reader.GetDateTime(2);
                        h.departmentId = reader.GetInt32(3);
                        h.jobId = reader.GetString(4);

                        history.Add(h);

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
            return history;
        }
    }
}
