using Dapper;
using QueryRouter.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRouter.QueryAdapters
{
    internal class GlobalResultGenerator : IResult, IDisposable
    {
        private IDbConnection C;

        public void Dispose()
        {
            C.Close();
        }

        public List<T> GetResult<T>(IDbConnection Connection,Query Q)
        {
            C = Connection;

            if (string.IsNullOrEmpty(Q.QueryText))
                throw new ArgumentException("The query cannot be empty!");

            var CommandT = Q.Type == QueryType.Procedure ? CommandType.StoredProcedure : CommandType.Text;
            var Params = new DynamicParameters();

            if (Q.Parameters != null)
                if (Q.Parameters.Count > 0)
                    foreach (var Param in Q.Parameters)
                    {
                        Params.Add($"@{Param.Key}", Param.Value);
                    }
          
            return Connection.Query<T>(Q.QueryText, Params, commandType: CommandT).ToList();


        }
    }
}
