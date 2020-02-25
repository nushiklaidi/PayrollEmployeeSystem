using Microsoft.EntityFrameworkCore;
using PayrollEmployeeSystem.Data;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private decimal studentLoanAmount;
        private decimal fee;

        private ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
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
            return _context.Employees.AsNoTracking().Where(e => e.Id == employeeId).FirstOrDefault();
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
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount > 1750 && totalAmount < 2000)
            {
                studentLoanAmount = 15m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2000 && totalAmount < 2250)
            {
                studentLoanAmount = 38m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2500 && totalAmount < 2500)
            {
                studentLoanAmount = 60m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 2500)
            {
                studentLoanAmount = 83m;
            }
            else
            {
                studentLoanAmount = 0m;
            }
            return studentLoanAmount;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);
            if (employee.UnionMember == UnionMember.Yes)
            {
                fee = 10m;
            }
            else
            {
                fee = 0m;
            }
            return fee;
        }

        public async Task CreateUploadImg(EmployeeCreateVM model, string webrootPath, Employee employee)
        {
            var uploadDir = @"images/employee";
            var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
            var extenstion = Path.GetExtension(model.ImageUrl.FileName);
            var webRootPath = webrootPath;
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extenstion;
            var path = Path.Combine(webRootPath, uploadDir, fileName);
            await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
            employee.ImageUrl = "/" + uploadDir + "/" + fileName;
        }

        public async Task EditUploadImg(EmployeeEditVM model, string webrootPath, Employee employee)
        {
            var uploadDir = @"images/employee";
            var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
            var extenstion = Path.GetExtension(model.ImageUrl.FileName);
            var webRootPath = webrootPath;
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extenstion;
            var path = Path.Combine(webRootPath, uploadDir, fileName);
            await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
            employee.ImageUrl = "/" + uploadDir + "/" + fileName;
        }
    }
}
