using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entity;
using WebGame.Domain.Response;
using WebGame.Domain.ViewModels;

namespace WebGame.Services.Interfaces
{
    public interface ITaskService
    {
        IBaseResponse<List<Tasks>> GetTasks();

        Task<IBaseResponse<TasksViewModel>> GetTask(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetTask(string term);

        Task<IBaseResponse<Tasks>> Create(TasksViewModel car);

        Task<IBaseResponse<bool>> DeleteTask(long id);

        Task<IBaseResponse<Tasks>> Edit(long id, TasksViewModel model);
    }
}
