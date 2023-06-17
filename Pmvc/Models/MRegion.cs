using Pmvc.Contexts;
using System.Data;
using System.Data.SqlClient;

namespace Pmvc.Models; 
public class MRegion
{
    public int Id { get; set; }
    public string Name { get; set; }


    public List<MRegion> GetAll()
    {
        SqlConnection connection = Connection.Get();
        connection.Open();
        var regions = new List<MRegion>();
        try
        {
            //Membuat instance untuk command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_regions";

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                while (reader.Read())
                {
                    var region = new MRegion();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                    regions.Add(region);

                }
            }
            else
            {
                Console.WriteLine("Data not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        connection.Close();
        return regions;
    }

    //Region GetById
    public MRegion GetByID(int id)
    {
        SqlConnection connection = Connection.Get();
        connection.Open();

        var region = new MRegion();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM tb_m_regions WHERE id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                region = new MRegion
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
            }
            else
            {
                region = new MRegion();
            }
            reader.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        connection.Close();

        return region;
    }

    //Insert Region
    public int Insert(string name)
    {
        int result = 0;
        SqlConnection connection = Connection.Get();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO tb_m_regions (nama) Values (@Name)";
            cmd.Transaction = transaction;

            // Membuat parameter
            SqlParameter paramName = new SqlParameter("@Name", SqlDbType.VarChar);
            paramName.Value = name;
            cmd.Parameters.Add(paramName);

            // Eksekusi perintah
            result = cmd.ExecuteNonQuery();

            // Commit transaksi jika berhasil
            transaction.Commit();

        }
        catch (Exception ex)
        {
            // Rollback transaksi jika terjadi kesalahan
            transaction.Rollback();
            Console.WriteLine("Eror" + ex.Message);
        }
        connection.Close ();
        return result;
    }
    // Update Region : Region
    public int Update(int id, string newName)
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
            cmd.CommandText = "UPDATE tb_m_regions SET nama = @newName WHERE Id = @id";
            cmd.Transaction = transaction;

            // Membuat parameter
            SqlParameter pNewName = new SqlParameter();
            pNewName.ParameterName = "@newName";
            pNewName.Value = newName;
            pNewName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

            // Menambahkan parameter ke command
            cmd.Parameters.Add(pNewName);
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
    // Delete Region : Region
    public int Delete(int id)
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
            cmd.CommandText = "DELETE FROM tb_m_regions WHERE Id = @id";
            cmd.Transaction = transaction;

            // Membuat parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

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