﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G.BLL.Interfaces;
using Company.G.DAL.Data.Contexts;
using Company.G.DAL.Models;

namespace Company.G.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyDbContext _context;
        public DepartmentRepository(CompanyDbContext context)
        {
            _context = context;
            
        }

        public IEnumerable<Department> GetAll()
        {
           return _context.Departments.ToList();    
        }
        public Department? Get(int id)
        {
            return _context.Departments.Find(id);
        }

        public int Add(Department model)
        {
            _context.Departments.Add(model);
           return  _context.SaveChanges();
        }
        public int Update(Department model)
        {
            _context.Departments.Update(model);
            return _context.SaveChanges();
        }

        public int Delete(Department model)
        {
            _context.Departments.Remove(model);
            return  _context.SaveChanges();
        }

    }
}
