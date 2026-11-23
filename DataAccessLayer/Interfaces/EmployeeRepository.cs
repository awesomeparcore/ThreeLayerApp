using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository //implementing the interace, meaning we have to implement all of the methods that exist in it
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        //Implement GetEmployeesAsync method from our IEmployeeRepository interface
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            await _context.Employees.ToListAsync();
        }

        public async Task EditEmployeeAsync(Employee employee)
        {
            var existing = await _context.Employees.FindAsync(employee.Id);
            if (existing == null)
            {
                return;
            }

            _context.Entry(existing).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();
        }

        public Task<Employee?> Details(int id)
        {
            return _context.Employees.FindAsync(id).AsTask();
        }
    }
}
