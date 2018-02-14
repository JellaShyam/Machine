using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AMS_EventEntity
    {
        public int Id { get; set; }
        public System.DateTime EventDateTime { get; set; }
        public string SiteId { get; set; }
    }
}
