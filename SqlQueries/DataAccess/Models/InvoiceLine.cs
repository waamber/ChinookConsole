using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueries.DataAccess.Models
{
    class InvoiceLine
    {
        public int InvoiceLineId {get; set;}
        public int InvoiceId { get; set; }
    }
}
