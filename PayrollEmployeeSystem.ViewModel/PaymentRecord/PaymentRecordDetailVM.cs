using PayrollEmployeeSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollEmployeeSystem.ViewModel.PaymentRecord
{
    public class PaymentRecordDetailVM
    {
        public int Id { get; set; }        
        public int EmployeeId { get; set; }
        public Entity.Employee Employee { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string NiNo { get; set; }
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }
        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        public string Year { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hourly Worked")]
        public decimal HoursWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; }
        public decimal OvertimeRate { get; set; }
        public decimal ContractualEarnings { get; set; }
        public decimal OvertimeEarnings { get; set; }
        public decimal Tax { get; set; }
        public decimal NIC { get; set; }
        public decimal? UnionFee { get; set; }
        public Nullable<decimal> SLC { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPayment { get; set; }
    }
}
