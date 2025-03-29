using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.G.DAL.Models;

namespace Company.G.BLL.Interfaces
{
    public interface IEmployeeReprository:IGenericReprository<Employee>
    {
        //Employee? GetByName(string name);

        //IEnumerable<Employee> GetAll();
        //Employee? Get(int id);
        //int Add(Employee model);
        //int Update(Employee model);
        //int Delete(Employee model);
    }
}
