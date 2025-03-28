﻿using Company.G.BLL.Interfaces;
using Company.G.BLL.Repositories;
using Company.G.DAL.Models;
using Company.G.PL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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

        //------------------

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code=model.Code, 
                    Name=model.Name, 
                    CreateAt=model.CreateAt
                };
                var count=_departmentRepository.Add(department);
                if (count > 0) 
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        //------------------

        [HttpGet]
        public IActionResult Details(int? id,string viewName="Details") 
        {
            if (id is null) return BadRequest("Invalid Id ");

            var department = _departmentRepository.Get(id.Value);

            if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department With Id : {id} is not found" });

            return View(viewName, department);
        }

        //------------------

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id ");

            //var department = _departmentRepository.Get(id.Value);

            //if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department With Id : {id} is not found" });

            return Details(id,"Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest();

                var count = _departmentRepository.Update(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var department = new Department()
        //        {
        //            Id=id,
        //            Code = model.Code,
        //            Name = model.Name,
        //            CreateAt = model.CreateAt
        //        };
        //        var count = _departmentRepository.Update(department);
        //        if (count > 0)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(model);
        //}


        //------------------

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id ");

            //var department = _departmentRepository.Get(id.Value);

            //if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department With Id : {id} is not found" });

            return Details(id,"Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id) return BadRequest();

                var count = _departmentRepository.Delete(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }

    }
}
