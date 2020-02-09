using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollEmployeeSystem.Services
{
    public interface INationalInsuranceContributionService
    {
        decimal NIContribution(decimal tatalAmount);
    }
}
