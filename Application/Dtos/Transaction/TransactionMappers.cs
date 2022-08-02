using Application.Dtos;
using Application.Dtos.Transaction;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Dtos.Transaction
{
    public class TransactionMappers : Profile
    {
        public TransactionMappers()
        {
            //source-destination
            CreateMap<TransactionDto, Domain.Entities.Transaction>()
                //destination-source
                .ForMember(d => d.transactionId, o => o.MapFrom(e => e.transactionId))
                .ForMember(d => d.personId, o => o.MapFrom(e => e.personId))
                .ForMember(d => d.TransactionDate, o => o.MapFrom(e => e.TransactionDate))
                .ForMember(d => d.Price, o => o.MapFrom(e => e.Price));
        }
    }
}
