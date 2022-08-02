using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context,  IConfiguration _configuration)
        {
            //if (!await context.Transactions.AnyAsync())
            //{
            //    string targetFolder = Path.Combine("../../Application", "Queries", "Transactions.sql");
            //    FileInfo file = new FileInfo(targetFolder);
            //    string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        string sqlQuery = file.OpenText().ReadToEnd();
            //        SqlCommand cmd = new SqlCommand(sqlQuery, con);
            //        await con.OpenAsync();
            //        await cmd.ExecuteReaderAsync();
            //        await con.CloseAsync();
            //    }
            //}

        }

    }
}
