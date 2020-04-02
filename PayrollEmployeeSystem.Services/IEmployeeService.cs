using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.ViewModel;
using PayrollEmployeeSystem.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee employee);
        Employee GetById(int employeeId);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int employeeId);
        Task Delete(int employeeId);
        decimal UnionFees(int id);
        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);
        IEnumerable<Employee> GetAll();
        Task CreateUploadImg(EmployeeCreateVM model, string webrootPath, Employee employee);
        Task EditUploadImg(EmployeeEditVM model, string webrootPath, Employee employee);
        IEnumerable<SelectListItem> GetAllEmployeesForPayroll();
    }
}
