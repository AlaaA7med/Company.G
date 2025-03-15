using Company.G.BLL.Interfaces;
using Company.G.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.G.PL.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments= _departmentRepository.GetAll();
            return View(departments);
        }
    }
}
