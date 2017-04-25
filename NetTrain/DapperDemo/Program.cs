using Dapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            //IDbConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EFDemo;Integrated Security=True;MultipleActiveResultSets=True");

            //DapperInsert(connection);
            //DapperQuery(connection);

            NlogDemo();
            Console.ReadLine();
        }

        static void NlogDemo()
        {
            logger.Info("This is nlog info demo.");
            logger.Error("This is nlog error demo.");
        }

        static void DapperInsert(IDbConnection connection)
        {
            User insertUser = new User()
            {
                Name = "Test Insert."
            };
            var result = connection.Execute("Insert into Person values (@Name)", insertUser);
            Console.WriteLine("Test dapper insert successfully.");
        }

        static void DapperQuery(IDbConnection connection)
        {
            var query = connection.Query<User>("select * from Person where Name=@Namet", new { Namet = "jay" });
        }
    }
}
