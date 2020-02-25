using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment, IMapper mapper)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            var employeeVM = _mapper.Map<List<EmployeeIndexVM>>(employees);
            return View(employeeVM);
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
                var employee = _mapper.Map<EmployeeCreateVM, Employee>(model);

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

            var employeeVM = _mapper.Map<EmployeeEditVM>(employee);

            return View(employeeVM);
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

                var editEmployee = _mapper.Map<EmployeeEditVM, Employee>(model);

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    await _employeeService.EditUploadImg(model, webRootPath, employee);
                }

                await _employeeService.UpdateAsync(editEmployee);

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

            var employeeVM = _mapper.Map<EmployeeDetailVM>(employee);         
            
            return View(employeeVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeVM = _mapper.Map<EmployeeDeleteVM>(employee);

            return View(employeeVM);
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