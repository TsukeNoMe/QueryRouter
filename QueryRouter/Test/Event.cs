using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Event
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }

    public class Votes
    {
        public string UserId { get; set; }
        public int InfoId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
