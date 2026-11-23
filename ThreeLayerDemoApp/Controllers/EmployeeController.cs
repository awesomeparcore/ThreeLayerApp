using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using ThreeLayerDemoApp.Models;
using DataAccessLayer.Entities;

namespace ThreeLayerDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployeesAsync(); //this makes sure the business logic gets processed before returning the view
            return View(employees);
        }

        public IActionResult Create()
        {
            return View(new DataAccessLayer.Entities.Employee());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.AddEmployeeAsync(employee); //this makes sure the business logic gets processed before returning the view
                return RedirectToAction("Index");
            }
            return View(employee);
        }

            public IActionResult Edit(int id)
            {
                var employee = employeeService.GetEmployeesAsync().Result.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.EditEmployeeAsync(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeService.Details(id);
            if (employee == null)
            {
               return NotFound();
            }
            return View(employee);
        }   

    }
}
