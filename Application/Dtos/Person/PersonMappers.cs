using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Dtos.Person
{
    public class PersonMappers : Profile
    {
        public PersonMappers()
        {
            CreateMap<PersonDto, Domain.Entities.Person>()
                .ForMember(d => d.personId, o => o.MapFrom(e => e.personId))
                .ForMember(d => d.name, o => o.MapFrom(e => e.name))
                .ForMember(d => d.family, o => o.MapFrom(e => e.family));
        }
    }
}
