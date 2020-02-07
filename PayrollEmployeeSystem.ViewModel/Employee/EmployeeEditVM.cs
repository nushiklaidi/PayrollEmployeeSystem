using Microsoft.AspNetCore.Http;
using PayrollEmployeeSystem.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayrollEmployeeSystem.ViewModel.Employee
{
    public class EmployeeEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Number is required"), RegularExpression(@"^[A-Z] {3,3} [0-9] {3}$")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "First Name Is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middel Name")]
        public string MiddleName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
        [Required(ErrorMessage = "Job Role is Required")]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, Display(Name = "NI No.")]
        public string NationalInsuranceNo { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
    }
}
