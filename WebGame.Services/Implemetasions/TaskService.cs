using WebGame.DAL.Interfaces;
using WebGame.Domain.Entity;
using WebGame.Domain.Enum;
using WebGame.Domain.Response;
using WebGame.Services.Interfaces;
using WebGame.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using WebGame.Domain.ViewModels;
using Microsoft.Identity.Client;
using static WebGame.Service.Implementations.TaskService;
using System.Runtime.ConstrainedExecution;  
using Microsoft.EntityFrameworkCore;
using WebGame.Domain.Extensios;
using static System.Reflection.Metadata.BlobBuilder;
using WebGame.Services.Interfaces;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace WebGame.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<Tasks> _taskRepository;

        public TaskService(IBaseRepository<Tasks> TaskRepository)
        {
            _taskRepository = TaskRepository;
        }

        public async Task<IBaseResponse<TasksViewModel>> GetTask(long id)
        {
            try
            {
                var task = await _taskRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (task == null)
                {
                    return new BaseResponse<TasksViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.DbNotFound
                    };
                }

                var data = new TasksViewModel()
                {
                    Id = task.Id,
                    Content = task.Content,
                    Answer = task.Answer,
                    Img = task.Img,
                    Category = task.Category,
                    Section = task.Section,
                };

                return new BaseResponse<TasksViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<TasksViewModel>()
                {
                    Description = $"[GetTask] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Dictionary<long, string>>> GetTask(string term)
        {
            var baseResponse = new BaseResponse<Dictionary<long, string>>();
            try
            {
                var task = await _taskRepository.GetAll()
                    .Select(x => new TasksViewModel()
                    {
                        Id = x.Id,
                        Content = x.Content,
                        Answer = x.Answer,
                        Img = x.Img,
                        Category = x.Category,
                        Section = x.Section,
                    })
                    .Where(x => EF.Functions.Like(x.Content, $"%{term}%"))
                    .ToDictionaryAsync(x => x.Id, t => t.Content);

                baseResponse.Data = task;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<long, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Tasks>> Create(TasksViewModel model)
        {
            try
            {
                var task = new Tasks()
                {
                    Id = model.Id,
                    Content = model.Content,
                    Answer = model.Answer,
                    Img = model.Img,
                    Category = model.Category,
                    Section = model.Section,
                };
                await _taskRepository.Create(task);

                return new BaseResponse<Tasks>()
                {
                    StatusCode = StatusCode.OK,
                    Data = task
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Tasks>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteTask(long id)
        {
            try
            {
                var Tasks = await _taskRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (Tasks == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User not found",
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }

                await _taskRepository.Delete(Tasks);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteTasks] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Tasks>> Edit(long id, TasksViewModel model)
        {
            try
            {
                var task = await _taskRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (task == null)
                {
                    return new BaseResponse<Tasks>()
                    {
                        Description = "Tasks not found",
                        StatusCode = StatusCode.NotFound
                    };
                }

                task.Id = task.Id;
                task.Content = task.Content;
                task.Answer = task.Answer;
                task.Img = task.Img;
                task.Category = task.Category;
                task.Section = task.Section;
                await _taskRepository.Update(task);


                return new BaseResponse<Tasks>()
                {
                    Data = task,
                    StatusCode = StatusCode.OK,
                };
                // TypeTasks
            }
            catch (Exception ex)
            {
                return new BaseResponse<Tasks>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Tasks>> GetTasks()
        {
            try
            {

                var tasks = _taskRepository.GetAll().ToList();
                if (!tasks.Any())
                {
                    return new BaseResponse<List<Tasks>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Tasks>>()
                {
                    Data = tasks,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Tasks>>()
                {
                    Description = $"[GetTasks] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
