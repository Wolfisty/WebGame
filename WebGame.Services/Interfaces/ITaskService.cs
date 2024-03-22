using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Services.Interfaces
{
    internal interface ITaskService
    {
        IBaseResponse<List<Tasks>> GetTasks();

        Task<IBaseResponse<TasksViewModel>> GetTask(long id);

        Task<BaseResponse<Dictionary<long, string>>> GetTasks(string term);

        Task<IBaseResponse<Tasks>> Create(TasksViewModel car);

        Task<IBaseResponse<bool>> DeleteTask(long id);

        Task<IBaseResponse<Tasks>> Edit(long id, TasksViewModel model);
    }
}
