using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryRouter.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace QueryRouter.QueryAdapters
{
    internal class MySQLAdapter : IDBStack
    {
        private MySqlConnection LocalConnection = new MySqlConnection();
        private Query MyQuery;

        public MySQLAdapter(Query Q)
        {
            MyQuery = Q;
        }

        public List<T> GetResult<T>()
        {
            LocalConnection.ConnectionString = MyQuery.ConnectionString;
            using (var R = new GlobalResultGenerator())
            {
                return R.GetResult<T>(LocalConnection, MyQuery);
            }
        }
    }
}
