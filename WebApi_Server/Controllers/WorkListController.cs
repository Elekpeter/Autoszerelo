using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class WorkListController : ControllerBase
    {
        private readonly ILogger<WorkListController> _logger;

        public WorkListController(ILogger<WorkListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return TaskRepository.GetTasks();
        }

        [HttpPost]
        public void Post(Task task)
        {
            TaskRepository.AddTask(task);
        }

        [HttpPut]
        public void Put(Task task)
        {
            TaskRepository.UpdateTask(task);
        }
    }
}
