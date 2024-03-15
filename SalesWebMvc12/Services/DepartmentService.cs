using SalesWebMvc12.Data;
using SalesWebMvc12.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc12.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc12Context _context;

        public DepartmentService(SalesWebMvc12Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
