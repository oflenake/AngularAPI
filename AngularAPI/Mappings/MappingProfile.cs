using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AngularAPI.Entities.Models;
using AngularAPI.Entities.RelatedModels;

namespace AngularAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, Employee>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.Fname))
                .ForMember(dest => dest.Lname, opt => opt.MapFrom(src => src.Lname))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender));

            CreateMap<EmployeeRelated, EmployeeRelated>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.Fname))
                .ForMember(dest => dest.Lname, opt => opt.MapFrom(src => src.Lname))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender))
                .ForMember(dest => dest.BankAccounts, opt => opt.MapFrom(src => src.BankAccounts));

            CreateMap<BankAccount, BankAccount>()
                .ForMember(dest => dest.BankAccountNumber, opt => opt.MapFrom(src => src.BankAccountNumber))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                .ForMember(dest => dest.ClientNumber, opt => opt.MapFrom(src => src.ClientNumber))
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName))
                .ForMember(dest => dest.AccountBalance, opt => opt.MapFrom(src => src.AccountBalance));
        }
    }
}
