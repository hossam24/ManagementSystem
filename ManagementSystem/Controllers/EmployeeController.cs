using ManagementSystem.Models;
using ManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpRepo _employeeRepository;
        private readonly IdeptRepo ideptRepo;
        private readonly IBranchRepo branchRepo;

        public EmployeeController(IEmpRepo employeeRepository,IdeptRepo ideptRepo,IBranchRepo branchRepo)
        {
            _employeeRepository = employeeRepository;
            this.ideptRepo = ideptRepo;
            this.branchRepo = branchRepo;
        }
        public IActionResult Index()
        {
            var employees =  _employeeRepository.GetAllEmployeesAsync();
            return View(employees);
        }
        public IActionResult getbyid(int? id)
        {
           
            var employee =  _employeeRepository.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public IActionResult Create(Employee employee)
        {

            var departments =  ideptRepo.GetAllDepartmentsAsync();
            var departmentList = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var branches =  branchRepo.GetAllBranchsAsync();
            var branchList = branches.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var viewModel = new ViewModel
            {
                Departments = departmentList,
                Branches = branchList,
                Employee = employee
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult SaveCreate(Employee employee)
        {
            if (ModelState.IsValid)
            {
                 _employeeRepository.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            return  Create(employee);
        }
    
        
        
        public IActionResult Edit(int id)
        {
          

            var employee =  _employeeRepository.GetEmployeeByIdAsync(id);
            var departments = ideptRepo.GetAllDepartmentsAsync();
            var departmentList = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var branches = branchRepo.GetAllBranchsAsync();
            var branchList = branches.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            var viewModel = new ViewModel
            {
                Departments = departmentList,
                Branches = branchList,
                Employee = employee
            };

            if (employee == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.UpdateEmployeeAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }

            }
            return Edit(id);
        }


    }
}
