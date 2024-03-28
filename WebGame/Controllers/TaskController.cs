using WebGame.DAL;
using WebGame.DAL.Interfaces;
using WebGame.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebGame.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using WebGame.Domain.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using WebGame.Models;
using System.Diagnostics;
using WebGame.Models;
using WebGame.Services.Interfaces;

namespace WebGame.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public TaskController(ITaskService TaskService)
        {
            _taskService = TaskService;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var response = _taskService.GetTasks();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _taskService.DeleteTask(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetTasks");
            }
            return RedirectToAction("Error");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _taskService.GetTask(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(TasksViewModel viewModel)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {

                    await _taskService.Create(viewModel);
                }
                else
                {
                    await _taskService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetTasks");
        }


        [HttpGet]
        public async Task<ActionResult> GetTask(int id, bool isJson)
        {
            var response = await _taskService.GetTask(id);
            if (isJson)
            {
                return View(response.Data);
            }
            return PartialView("GetTask", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetTask(string term)
        {
            var response = await _taskService.GetTask(term);
            return Json(response.Data);
        }
    }
}