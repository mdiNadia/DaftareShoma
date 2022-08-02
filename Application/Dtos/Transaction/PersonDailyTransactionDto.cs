using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Transaction
{
    public class PersonDailyTransactionDto
    {
        public int personId { get; set; }

        public string fullname { get; set; }

        public DateTime date { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
    }
}
