using Pmvc.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmvc.Models
{
    public class MJob
    {
        public string id { get; set; }
        public string title { get; set; }
        public int minSalary { get; set; }
        public int maxSalary { get; set; }

        public List<MJob> GetAll()
        {
            SqlConnection connection = Connection.Get();
            connection.Open();
            var jobs = new List<MJob>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new MJob();
                        job.id = reader.GetString(0);
                        job.title = reader.GetString(1);
                        job.minSalary = reader.GetInt32(2);
                        job.maxSalary = reader.GetInt32(3);

                        jobs.Add(job);// Menambahkan objek Department ke dalam list
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
            return jobs;
        }
    }

}
