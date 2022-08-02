using Application.Dtos.Transaction;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Dapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Transaction : GenericRepository<Domain.Entities.Transaction>, ITransaction
    {
        private readonly DataContext _context;
        private readonly IPerson _person;
        private readonly IMapper _mapper;

        public Transaction(DataContext context, IConfiguration configuration, IPerson person,IMapper mapper) : base(context, configuration)
        {
            this._context = context;
            this._person = person;
            this._mapper = mapper;
        }
   
        public async Task<int> InsertTransaction(List<TransactionDto> transaction)
        {
            try
            {
                List<Domain.Entities.Transaction> listToInsert = _mapper.Map<List<Domain.Entities.Transaction>>(transaction);
                _context.Database.OpenConnection();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Transactions ON");
                InsertList(listToInsert);
                await SaveEntityChangeAsync();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Transactions OFF");
                _context.Database.CloseConnection();
                return 200;
                //string connectionString = _configuration.GetConnectionString("DefaultConnection");
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    List<Domain.Entities.Transaction> listToInsert = _mapper.Map<List<Domain.Entities.Transaction>>(transaction);
                //    connection.Query("SET IDENTITY_INSERT Transactions ON");
                //    InsertList(listToInsert);
                //    await SaveEntityChangeAsync();
                //    connection.Query("SET IDENTITY_INSERT Transactions OFF");
                //    return 200;
                //}


               
            }
            catch (Exception err)
            {
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { error = err.Message });

            }

        }

        public async Task<IEnumerable<PersonDailyTransactionDto>> UsersDailyTransactionsReportAsync()
        {
            try
            {
                var data = await GetQueryList().Include(c => c.Person).GroupBy(c => new
                {
                    personId = c.personId,
                    TransactionDate = c.TransactionDate.Date

                }).Select(g => new PersonDailyTransactionDto
                {
                    personId = g.Key.personId,
                    date = g.Key.TransactionDate,
                    fullname = g.Select(f => (f.Person.name + f.Person.family)).FirstOrDefault(),
                    price = g.Select(f => f.Price).FirstOrDefault(),
                    total = g.Sum(f => f.Price)

                }).ToListAsync();

             

                return data;
            }
            catch (Exception err)
            {
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { error = err.Message });

            }
        }
    }
}
