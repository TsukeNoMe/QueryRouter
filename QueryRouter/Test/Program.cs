using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryRouter;
using QueryRouter.Data;
using QueryRouter.QueryAdapters;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var Q = new Query
            {
                ConnectionString = "server=localhost;uid=root;pwd=;database=voteapp",
                QueryText = @"Select * From Votes",
                Type = QueryType.Query
            };
            IRoute run = new Route();
            var R = run.ResultSet<Votes>(DbType.MySQL, Q);
            Console.Read();
            
        }
    }
}
