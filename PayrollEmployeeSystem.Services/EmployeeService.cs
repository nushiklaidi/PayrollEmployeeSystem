﻿using PayrollEmployeeSystem.Data;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
        }
            
        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }

        public Task UploadImg(TestViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}