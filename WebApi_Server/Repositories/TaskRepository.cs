using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi_Server.Repositories
{
    public class TaskRepository
    {
        public static IList<Task> GetTasks()
        {
            using (var database = new TaskContext())
            {
                var tasks = database.Tasks.OrderBy(x => x.Date).ToList();

                return tasks;
            }
        }

        public static Task GetTask(long id)
        {
            using (var database = new TaskContext())
            {
                var task = database.Tasks.Where(x => x.Id == id).FirstOrDefault();

                return task;
            }
        }

        public static void AddTask(Task task)
        {
            using (var database = new TaskContext())
            {
                database.Tasks.Add(task);

                database.SaveChanges();
            }
        }

        public static void UpdateTask(Task task)
        {
            using (var database = new TaskContext())
            {
                database.Tasks.Update(task);

                database.SaveChanges();
            }
        }
    }
}
