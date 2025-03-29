using Company.G.BLL.Interfaces;
using Company.G.BLL.Repositories;
using Company.G.DAL.Models;
using Company.G.PL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.G.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReprository _employeeReprository;

        public EmployeeController(IEmployeeReprository employeeReprository)
        {
            _employeeReprository = employeeReprository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeReprository.GetAll();
            return View(employees);
        }
        //-----------------------

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid) 
            {
                var employee = new Employee()
                { 
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email, 
                    Salary = model.Salary,
                    Address = model.Address,
                    IsActive = model.IsActive,  
                    IsDeleted = model.IsDeleted,    
                    CreateAt=model.CreateAt,
                    Phone = model.Phone,
                    HiringDate = model.HiringDate,

                };
                var count = _employeeReprository.Add(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));   
                }
            }
            return View(model);
        }
        //-----------------------
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null) return BadRequest("Invalid Id ");

            var employee = _employeeReprository.Get(id.Value);

            if (employee is null) return NotFound(new { StatusCode = 404, Message = $" Employee With Id : {id} is not found" });

            return View(viewName, employee);
        }

        //------------------

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id != employee.Id) return BadRequest();

                var count = _employeeReprository.Update(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }


        //------------------

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            

            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id != employee.Id) return BadRequest();

                var count = _employeeReprository.Delete(employee);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }
    }
}
