using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWeb.Services

{
    class ServiceTaskD : IServiceTaskD
    {
        IRepositoryTask newRepositoryTask = new RepositoryTask();
        public TaskDB GetTaskForId(int id)
        {
            return newRepositoryTask.GetTaskForId(id);
        }

        public IEnumerable<TaskDB> GetTasks()
        {
            return newRepositoryTask.GetTasks();
        }

        public IEnumerable<TaskDB> GetTasksForComplete(int id)
        {
            return newRepositoryTask.GetTasksForComplete(id);
        }

        public TaskDB Save(TaskDB pTask)
        {
            return newRepositoryTask.Save(pTask);
        }
    }
}
