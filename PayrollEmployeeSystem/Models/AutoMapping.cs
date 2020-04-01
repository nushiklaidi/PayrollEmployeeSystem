using AutoMapper;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollEmployeeSystem.ViewModel.PaymentRecord;

namespace PayrollEmployeeSystem.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Employee ViewModel
            CreateMap<Employee, EmployeeIndexVM>().ReverseMap();
            CreateMap<Employee, EmployeeCreateVM>().ReverseMap();
            CreateMap<Employee, EmployeeEditVM>().ReverseMap();
            CreateMap<Employee, EmployeeDetailVM>().ReverseMap();
            CreateMap<Employee, EmployeeDeleteVM>().ReverseMap();

            //PaymentRecord ViewModel
            CreateMap<PaymentRecord, PaymentRecordIndexVM>().ReverseMap();
        }        
    }
}
