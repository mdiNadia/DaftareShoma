using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Transaction
{
    public class TransactionDto
    {
        public int transactionId { get; set; }
        public int personId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Price { get; set; }
    }
}
