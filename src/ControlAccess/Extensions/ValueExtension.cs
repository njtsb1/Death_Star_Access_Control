using System.Data.SqlClient;

namespace ControlAcess.Extensions
{
    public static class ValueExtension
    {

        public static T GetValueOrDefault<T>(this SqlDataReader reader, string field)
        {
            try
            {
                return (T)reader[field];
            }
            catch
            {
                return default(T);
            }
        }

    }
}
