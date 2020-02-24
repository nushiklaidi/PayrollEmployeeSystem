using AutoMapper;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Employee ViewModel
            CreateMap<Employee, EmployeeIndexVM>().ReverseMap();
            CreateMap<Employee, EmployeeEditVM>().ReverseMap();
        }        
    }
}
