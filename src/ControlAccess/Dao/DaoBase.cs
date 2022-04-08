
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ControlAcess.Dao
{
    public abstract class DaoBase: IDisposable
    {
        protected readonly SqlConnection con;

        protected DaoBase()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-QG1083UH\SQLEXPRESS;Initial Catalog=DeathStar;Integrated Security=True;Connect Timeout=30");
        }

        protected async Task Insert(string command)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        protected async Task Select(string command, Action<SqlDataReader> treatmentReading)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            treatmentReading(dr);
            con.Close();
        }

        public void Dispose()
        {
            con?.Close();
            con?.Dispose();
        }
    }
}
