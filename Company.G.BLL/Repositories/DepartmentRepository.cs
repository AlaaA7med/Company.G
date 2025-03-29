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
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext context ):base(context)
        {
            
        }

    }
}
