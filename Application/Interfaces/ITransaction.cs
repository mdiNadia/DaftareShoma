using Application.Dtos.Transaction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransaction:IGenericRepository<Transaction>
    {

        Task<int> InsertTransaction(List<TransactionDto> transaction);
        Task<IEnumerable<PersonDailyTransactionDto>> UsersDailyTransactionsReportAsync();
    }
}
