using Application.Dtos;
using Application.Dtos.Person;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Person : GenericRepository<Domain.Entities.Person>, IPerson
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Person(DataContext context, IConfiguration configuration, IMapper mapper) : base(context, configuration)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<int> InsertPeople(List<PersonDto> person)
        {
            try
            {
              
                List<Domain.Entities.Person> listToInsert = _mapper.Map<List<Domain.Entities.Person>>(person);
                
                InsertList(listToInsert);
                await SaveEntityChangeAsync();
               
                return 200;
            }
            catch (Exception err)
            {
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { error = err.Message });

            }

        }
    }
}
