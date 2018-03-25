using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryRouter.Data;

namespace QueryRouter.QueryAdapters
{
    internal class SqliteAdapter : IDBStack
    {
        private SQLiteConnection LocalConnection = new SQLiteConnection();
        private Query MyQuery;

        public SqliteAdapter(Query Q)
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
