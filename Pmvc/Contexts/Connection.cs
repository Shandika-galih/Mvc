using System.Data.SqlClient;

namespace Pmvc.Contexts
{
    public class Connection
    {
        private static string connectionString = "Data Source=LAPTOP-254094N7;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static SqlConnection Get()
        {
            return new SqlConnection(connectionString);
        }
    }
}
