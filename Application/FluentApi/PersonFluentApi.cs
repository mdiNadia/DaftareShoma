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
    public class PersonFluentApi : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.personId);
            builder.Property(b => b.personId).ValueGeneratedNever();
            builder.Property(c => c.name).IsRequired();
            builder.Property(c => c.family).IsRequired();
        }

    }
}
