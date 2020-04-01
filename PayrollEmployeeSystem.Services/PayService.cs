using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollEmployeeSystem.Data;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Services
{
    public class PayService : IPayService
    {
        private IPayRepository _payRepository;
        public PayService(IPayRepository payRepository)
        {
            _payRepository = payRepository;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            return _payRepository.ContractualEarnings(contractualHours, hoursWorked, hourlyRate);
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _payRepository.CreateAsync(paymentRecord);
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            return _payRepository.GetAll();
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            return _payRepository.GetAllTaxYear();
        }

        public PaymentRecord GetById(int id)
        {
            return _payRepository.GetById(id);
        }

        public TaxYear GetTaxYearById(int id)
        {
            return _payRepository.GetTaxYearById(id);
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            return _payRepository.NetPay(totalEarnings, totalDeduction);
        }

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return _payRepository.OvertimeEarnings(overtimeRate, overtimeHours);
        }

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            return _payRepository.OverTimeHours(hoursWorked, contractualHours);
        }

        public decimal OverTimeRate(decimal hourlyRate)
        {
            return _payRepository.OverTimeRate(hourlyRate);
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
        {
            return _payRepository.TotalDeduction(tax, nic, studentLoanRepayment, unionFees);
        }

        public decimal TotalEarings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            return _payRepository.TotalEarings(overtimeEarnings, contractualEarnings);
        }
    }
}
