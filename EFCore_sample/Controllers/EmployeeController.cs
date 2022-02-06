using EFCore_sample.Contexts;
using EFCore_sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_sample.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly ILogger<EmployeeController> _logger;
        private EmployeeDbContext _employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<IActionResult> Index()
        {
            //var contacts = await _employeeDbContext.Employees.ToListAsync();
            //var result = _employeeDbContext.Employees.Include(s => s.EmployeeAddress)
            //        .ToListAsync<Employee>();

            //Inner join
            var employeeList = await _employeeDbContext.Employees.
                      Join(_employeeDbContext.Addresses,
                      o => o.Id,
                      i => i.EmployeeId,
                      (o, i) =>
                      new Employee
                      {
                          Id = o.Id,
                          EmployeeName = o.EmployeeName,
                          Skill = o.Skill,
                          Email = o.Email,
                          Salary = o.Salary,
                          Address = i.AddressDetail
                      }).ToListAsync();
            //var leftJoinemplist = await _employeeDbContext.Employees.
            //                    Join(_employeeDbContext.Addresses.DefaultIfEmpty(),
            //                    //p => p.Id,
            //                    //b => b.EmployeeId,
            //                    (p, b) =>
            //                    new
            //                    {
            //                        Id = p.Id,
            //                        EmployeeName = p.EmployeeName,
            //                        Skill = p.Skill,
            //                        Email = p.Email,
            //                        Salary = p.Salary,
            //                        Address = b.AddressDetail
            //                    }).ToListAsync();

            //Left Join
            var a = _employeeDbContext.Employees.GroupJoin
                  (_employeeDbContext.Addresses,
                  employee => employee.Id,
                  address => address.EmployeeId,
                  (employee, address) => new { employee, address })
                  .SelectMany(s => s.address.DefaultIfEmpty(),
                              (s, address) =>
                              new Employee
                              {
                                  Id = s.employee.Id,
                                  EmployeeName=s.employee.EmployeeName,
                                  Skill=s.employee.Skill,
                                  Email=s.employee.Email,
                                  Salary=s.employee.Salary,
                                  Address=address.AddressDetail
                                  //address
                              }).ToList();
            return View(a);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeDbContext.Add(employee);
                    await _employeeDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exist = await _employeeDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _employeeDbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        exist.EmployeeName = employee.EmployeeName;
                        exist.Skill = employee.Skill;
                        exist.Email = employee.Email;
                        exist.Salary = employee.Salary;
                        await _employeeDbContext.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _employeeDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _employeeDbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        _employeeDbContext.Remove(exist);
                        await _employeeDbContext.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
