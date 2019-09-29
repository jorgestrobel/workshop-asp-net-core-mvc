using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        //o readonly eh pra ter certeza que este atributo nao sera alterado
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }   

        public async Task<List<Department>> FindAllAsync()
        {
            //await avisa ao compilador que isso eh uma chamada assincrona                          
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        //public List<Department> FindAll()
        //{
        //    return _context.Department.OrderBy(x => x.Name).ToList();
        //}
    }
}
