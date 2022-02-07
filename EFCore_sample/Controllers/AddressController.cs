using EFCore_sample.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore_sample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_sample.Controllers
{
    public class AddressController : Controller
    {
        private EmployeeDbContext _employeeDbContext;

        public AddressController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        // GET: AddressController
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new();
            employees = await (from emp in _employeeDbContext.Employees select emp).ToListAsync();
            //var empList =  _employeeDbContext.Employees.Select(x => new Itemlist { Value = x.Id, Text = x.EmployeeName }).ToList();
            ViewBag.empList = employees;
            return View();
        }

        // GET: AddressController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: AddressController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        var exist = _employeeDbContext.Addresses.Where(x => x.EmployeeId == employee.Id).FirstOrDefault();
                        Address address = new();
                        if (exist != null)
                        {
                            exist.EmployeeId = employee.Id;
                            exist.AddressDetail = employee.Address;
                             await _employeeDbContext.SaveChangesAsync();
                        }
                        else
                        {
                            address.EmployeeId = employee.Id;
                            address.AddressDetail = employee.Address;
                            _employeeDbContext.Addresses.Add(address);
                            await _employeeDbContext.SaveChangesAsync();

                        }

                        return RedirectToAction("Index", "Employee");
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
