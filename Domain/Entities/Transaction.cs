using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {

        public int transactionId { get; set; }
        public int personId { get; set; }
        public Person Person { get; set; }
        public DateTime TransactionDate{ get; set; }
        public decimal Price { get; set; }
    }
}
