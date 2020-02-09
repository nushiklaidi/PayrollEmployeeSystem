using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollEmployeeSystem.Services
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
