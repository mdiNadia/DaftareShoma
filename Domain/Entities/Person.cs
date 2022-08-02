using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person
    {
        public int personId { get; set; }
      
        public string name { get; set; }
       
        public string family { get; set; }

        public ICollection<Transaction> transactions { get; set; }
    }
}
