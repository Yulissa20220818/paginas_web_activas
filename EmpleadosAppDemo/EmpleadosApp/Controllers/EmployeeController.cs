using EmpleadosApp.Data;
using EmpleadosApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeData employeeData = new EmployeeData();

            return View(employeeData.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                EmployeeData employeeData = new EmployeeData();
                employeeData.Add(employeeModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employeeModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            EmployeeData employeeData = new EmployeeData();
            //var employee = employeeData.GetAll().FirstOrDefault(employee => employee.Id == id);
            var employee = employeeData.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {
                EmployeeData employeeData = new EmployeeData();
                employeeData.Edit(employeeModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employeeModel);
            }
        }
   
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        EmployeeData = new EmployeeData();
        var employee = EmployeeData.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Viem(employee);
    }

    [HttpPost]

    public IActionResult Delete(EmployeeModel employee)
    {
        try
        {
            EmployeeData employeeData = new EmployeeData();
            employeeData.Delete(employee.Id);

            return RedirecToAction(nameof(Index));
        }

        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;

            return ErrorViewModel(employee);
        }
    }
}
