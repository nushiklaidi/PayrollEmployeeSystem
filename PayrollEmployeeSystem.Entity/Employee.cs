using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollEmployeeSystem.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        [Required]
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
