using Application.Dtos;
using Application.Dtos.Person;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPerson: IGenericRepository<Person>
    {
        Task<int> InsertPeople(List<PersonDto> person);
    }
}
