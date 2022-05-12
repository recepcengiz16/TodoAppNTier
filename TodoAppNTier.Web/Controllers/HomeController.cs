using Microsoft.AspNetCore.Mvc;
using TodoAppNtier.Common.ResponseObjects;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.Business.Mapping;
using TodoAppNTier.DTO.WorkDTOs;
using TodoAppNTier.Web.ControllerExtensions;

namespace TodoAppNTier.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {   
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var workList= await _workService.GetAll();
            return View(workList.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDTO createDTO)
        {
           var response= await _workService.Create(createDTO);
            return this.ResponseRedirectToAction(response,"Index");


        }

        public async Task<IActionResult> Update(int id)
        {
            var response= await _workService.GetById(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDTO updateDTO)
        {
            var response= await _workService.Update(updateDTO);

           return this.ResponseRedirectToAction(response,"Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response= await _workService.Remove(id);

            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}