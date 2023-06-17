using Pmvc.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Models;

public class MLocation
{
    public int id { get; set; }
    public string streetAddress { get; set; }
    public string postalCode { get; set; }
    public string city { get; set; }
    public string stateProvince { get; set; }
    public string countryId { get; set; }

    public List<MLocation> GetAll()
    {
        SqlConnection connection = Connection.Get();
        connection.Open();
        var location = new List<MLocation>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_location";

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var loc = new MLocation();
                    loc.id = reader.GetInt32(0);
                    loc.streetAddress = reader.GetString(1);
                    loc.postalCode = reader.GetString(2);
                    loc.city = reader.GetString(3);
                    loc.stateProvince = reader.GetString(4);
                    loc.countryId = reader.GetString(5);

                    location.Add(loc);
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
        return location;
    }
}
