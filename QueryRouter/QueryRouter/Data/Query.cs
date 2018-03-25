using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRouter.Data
{
    public class Query
    {
        public string ConnectionString { get; set; }
        public string QueryText { get; set; }
        public Dictionary<string,string> Parameters { get; set; }
        public QueryType Type { get; set; }
    }
}
