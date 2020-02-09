using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PayrollEmployeeSystem.Entity;
using PayrollEmployeeSystem.Services;
using PayrollEmployeeSystem.ViewModel.Employee;

namespace PayrollEmployeeSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll()
                .Select(employee => new EmployeeIndexVM
                { 
                    Id = employee.Id,
                    EmployeeNo = employee.EmployeeNo,
                    ImageUrl =  employee.ImageUrl,
                    FullName = employee.FullName,
                    Gender = employee.Gender,
                    Designation = employee.Designation,
                    City = employee.City,
                    DateJoined = employee.DateJoined
                }).ToList();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    PostCode = model.PostCode,
                    Designation = model.Designation
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    await _employeeService.CreateUploadImg(model, webRootPath, employee);
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditVM()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                PostCode = employee.PostCode,
                Designation = employee.Designation
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.NationalInsuranceNo = model.NationalInsuranceNo;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.DateJoined = model.DateJoined;
                employee.Designation = model.Designation;
                employee.PaymentMethod = model.PaymentMethod;
                employee.StudentLoan = model.StudentLoan;
                employee.UnionMember = model.UnionMember;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.PostCode = model.PostCode;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    await _employeeService.EditUploadImg(model, webRootPath, employee);

                    //var uploadDir = @"images/employee";
                    //var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    //var extenstion = Path.GetExtension(model.ImageUrl.FileName);
                    //var webRootPath = _hostingEnvironment.WebRootPath;
                    //fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extenstion;
                    //var path = Path.Combine(webRootPath, uploadDir, fileName);
                    //await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    //employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }        

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailVM model = new EmployeeDetailVM()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                Email = employee.Email,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                ImageUrl = employee.ImageUrl,
                PostCode = employee.PostCode
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteVM()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };
            return View(model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteVM model)
        {
            await _employeeService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}