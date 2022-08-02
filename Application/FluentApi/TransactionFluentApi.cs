using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentApi
{
    public class TransactionFluentApi : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.HasKey(c => c.transactionId);
            builder.HasOne(c => c.Person).WithMany(c => c.transactions).HasForeignKey(c => c.personId);
        }
    }
}
