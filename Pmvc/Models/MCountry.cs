using Pmvc.Contexts;
using Pmvc.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pmvc.Models;

public class MCountry
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int regionId { get; set; }

    public List<MCountry> GetAll()
    {
        SqlConnection connection = Connection.Get();
        connection.Open();
        var country = new List<MCountry>();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_countries";

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) 
            { 
                while (reader.Read())
                {
                    var c = new MCountry();
                    c.Id = reader.GetString(0);
                    c.Name = reader.GetString(1);
                    c.regionId = reader.GetInt32(2);
                    country.Add(c);
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
        return country;
    }
    //Country GetById
    public MCountry GetByID(string id)
    {
        SqlConnection connection = Connection.Get();
        connection.Open();

        var country = new MCountry();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_countries WHERE id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                country = new MCountry
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    regionId = reader.GetInt32(2)
                };
            }
            else
            {
                country = new MCountry();
            }
            reader.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();

        return country;
    }

    //Insert Country
    public int Insert(string Id, string Name, int regionId)
    {
        int result = 0;
        SqlConnection connection = Connection.Get();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO tb_m_countries (id, nama, region_id) Values (@Id, @Name, @regionId)";
            cmd.Transaction = transaction;

            // Membuat parameter
            SqlParameter pId = new SqlParameter("@Id", Id);
            cmd.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter("@Name", Name);
            cmd.Parameters.Add(pName);

            SqlParameter pRegionId = new SqlParameter("@RegionId", regionId);
            cmd.Parameters.Add(pRegionId);

            result = cmd.ExecuteNonQuery();
            transaction.Commit();

        }
        catch (Exception ex)
        {
            // Rollback transaksi jika terjadi kesalahan
            transaction.Rollback();
            Console.WriteLine("Eror" + ex.Message);
        }
        connection.Close();
        return result;
    }
    // Update Country 
    public int Update(string id, string newName, int regionId)
    {
        int result = 0;

        SqlConnection connection = Connection.Get();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE tb_m_countries SET id = @id, nama = @newName, region_id = @regionId WHERE Id = @id";
            cmd.Transaction = transaction;

            SqlParameter pNewName = new SqlParameter("@newName", newName);
            cmd.Parameters.Add(pNewName);

            SqlParameter pRegionId = new SqlParameter("@regionId", regionId);
            cmd.Parameters.Add(pRegionId);

            SqlParameter pId = new SqlParameter("@id", id);
            cmd.Parameters.Add(pId);

            result = cmd.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollbackEx)
            {
                Console.WriteLine(rollbackEx.Message);
            }
        }

        connection.Close();
        return result;
    }

    // Delete Region : Region
    public int Delete(string id)
    {
        int result = 0;

        SqlConnection connection = Connection.Get();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            // Membuat instance untuk command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "DELETE FROM tb_m_countries WHERE id = @id";
            cmd.Transaction = transaction;

            // Membuat parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Char;

            // Menambahkan parameter ke command
            cmd.Parameters.Add(pId);

            // Menjalankan command
            result = cmd.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        connection.Close();
        return result;
    }
}
