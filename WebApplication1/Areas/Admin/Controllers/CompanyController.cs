using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebApp.DataAccess.Repository.IRepository;
using WebApp.Models.Models;
using WebApp.Models.Models.ViewModels;
using WebApp.Utilities;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0) 
            { 
                return View(new Company());
            }
            else 
            {
                Company companyObj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {

                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                    TempData["success"] = "Company created successfully";
                }

                else 
                {
                    _unitOfWork.Company.Update(companyObj);
                    TempData["success"] = "Company updated successfully";
                }

                _unitOfWork.Save();
            }
            else 
            {
                TempData["error"] = "Company creation failed";
                return View(companyObj);
            }

            return RedirectToAction("Index");
        }

        #region
        [HttpGet]
        public IActionResult GetAll(int id) 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyForDelete = _unitOfWork.Company.GetFirstOrDefault(u=>u.Id == id);
            if(companyForDelete == null)
            {
                return Json(new { success = false, message = "Error, company was not deleted" });
            }

            _unitOfWork.Company.Delete(companyForDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Company was deleted succesfully" });
        }
        #endregion
    }
}
