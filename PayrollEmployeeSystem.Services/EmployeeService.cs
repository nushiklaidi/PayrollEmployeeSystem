using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollEmployeeSystem.Data;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.Repositories;
using PayrollEmployeeSystem.ViewModel;
using PayrollEmployeeSystem.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task CreateUploadImg(EmployeeCreateVM model, string webrootPath, Employee employee)
        {
            await _employeeRepository.CreateUploadImg(model, webrootPath, employee);
        }

        public async Task Delete(int employeeId)
        {
            await _employeeRepository.Delete(employeeId);
        }

        public async Task EditUploadImg(EmployeeEditVM model, string webrootPath, Employee employee)
        {
            await _employeeRepository.EditUploadImg(model, webrootPath, employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return _employeeRepository.GetAllEmployeesForPayroll();
        }

        public Employee GetById(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            return _employeeRepository.StudentLoanRepaymentAmount(id, totalAmount);
        }

        public decimal UnionFees(int id)
        {
            return _employeeRepository.UnionFees(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task UpdateAsync(int employeeId)
        {
            await _employeeRepository.UpdateAsync(employeeId);
        }
    }
}
