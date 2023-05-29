using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    interface IServiceTask
    {

        IEnumerable<TaskDB> GetTasksForComplete(int id);
        IEnumerable<TaskDB> GetTasks();
        TaskDB GetTaskForId(int id);

        TaskDB Save(TaskDB pTask);
    }
}
