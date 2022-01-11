using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AdministratorClient.DataProviders
{
    public class TaskDataProvider
    {
        private const string _url = "http://localhost:5000/api/task";

        public static IEnumerable<Task> GetTasks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var tasks = JsonConvert.DeserializeObject<IEnumerable<Task>>(rawData);
                    return tasks;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateTask(Task task)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(task);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateTask(Task task)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(task);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
