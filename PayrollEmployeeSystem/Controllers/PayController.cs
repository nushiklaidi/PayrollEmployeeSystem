using Microsoft.AspNetCore.Mvc;
using PayrollEmployeeSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollEmployeeSystem.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
