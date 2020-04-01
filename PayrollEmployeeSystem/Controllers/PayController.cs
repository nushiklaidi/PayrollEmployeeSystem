using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.Services;
using PayrollEmployeeSystem.ViewModel.PaymentRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayService _payService;
        private readonly IMapper _mapper;

        public PayController(IPayService payService, IMapper mapper)
        {
            _payService = payService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var payRecords = _payService.GetAll()
                .Select(p => new PaymentRecordIndexVM
                {
                    Id = p.Id,
                    EmployeeId = p.EmployeeId,
                    FullName = p.FullName,
                    PayDate = p.PayDate,
                    PayMonth = p.PayMonth,
                    TaxYearId = p.TaxYearId,
                    Year = _payService.GetTaxYearById(p.TaxYearId).YearOfTax,
                    TotalEatnings = p.TotalEarnings,
                    TotalDeduction = p.TotalDeduction,
                    NetPayment = p.NetPayment,
                    Employee = p.Employee
                });

            return View(payRecords);
        }
    }
}
