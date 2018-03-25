using QueryRouter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace QueryRouter.QueryAdapters
{
    internal class MSSQLAdapter : IDBStack
    {
        private SqlConnection LocalConnection = new SqlConnection();
        private Query MyQuery;

        public MSSQLAdapter(Query Q)
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
