using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class WorkListController : ControllerBase
    {
        public List<Task> dataList = new List<Task>();


        private readonly ILogger<WorkListController> _logger;

        public WorkListController(ILogger<WorkListController> logger)
        {
            _logger = logger;
            string s = "string";
            dataList.Add(new Task(s, s, s, s));
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return dataList;
        }

        [HttpPost]
        public void Post(Task task)
        {
            dataList.Add(task);
        }

        [HttpPut]
        public void Put(Task task)
        {
            var updateTask = dataList.Find(x => x.Date == task.Date);
            updateTask = task;
        }
    }
}
