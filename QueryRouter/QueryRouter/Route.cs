using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryRouter.Data;
using QueryRouter.QueryAdapters;

namespace QueryRouter
{
    public class Route : IRoute
    {
        public List<T> ResultSet<T>(DbType Type, Query Q)
        {
            if (Q == null)
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(Q.ConnectionString))
                throw new ArgumentException("Connection string cannot be empty!");
            
            switch(Type)
            {
                case DbType.MSSQL: return new MSSQLAdapter(Q).GetResult<T>();
                case DbType.MySQL: return new MySQLAdapter(Q).GetResult<T>();
                case DbType.Sqlite: return new SqliteAdapter(Q).GetResult<T>();
                default: return null;
            }
        }
    }
}
